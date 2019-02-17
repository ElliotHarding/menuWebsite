using System;
using System.Collections.Generic;

public partial class Aspx_ViewChef : System.Web.UI.Page
{
    BackEnd backEnd = new BackEnd();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Check client is recongnised, otherwise redirect to login page
        try
        {
            if (Session["currentUserID"].ToString() == null || Session["currentUserID"].ToString() == "") Response.Redirect("../Welcome/login.aspx");
        }
        catch (Exception ee)
        {
            DebugLogger.put_a_breakpoint_inside_this_function(ee);
            Response.Redirect("../Welcome/login.aspx");
        }

        displayChef();
    }

    //Populate aspx/html with chef
    private void displayChef()
    {
        TableAttributeList chefToDisplay = getCurrentChef();
        if (chefToDisplay == null)
        {
            Errors.InnerText = "Error! No chef found to display.";
            return;
        }

        name.InnerText = chefToDisplay.getAttribute("name");
        rating.Text = chefToDisplay.getAttribute("rating") + "/5";

        ChefImage.ImageUrl = chefToDisplay.getAttribute("picture_id");

        populateChefsMeals(chefToDisplay.getAttribute("id"));
    }


    private void populateChefsMeals(string chefID)
    {
        //Run sql query, and attempt to fill results
        string searchString = "SELECT * FROM [MEAL] WHERE owner_user_id = '" + chefID + "';";
        List<Meal> meals = backEnd._storage.getListOfMeals(searchString);

        if (meals.Count > 0)
        {
            foreach (Meal meal in meals)
            {
                Aspx_MealButton newMealButton = (Aspx_MealButton)LoadControl(Globals.MealButtonInclude);
                newMealButton.populate(meal);

                if (SearchBox.Value != null && SearchBox.Value != "")
                {
                    if (meal.getAttribute("meal_name").Contains(SearchBox.Value)// ||
                      //meal.getAttribute("meal_rating").Contains(SearchBox.Value))
                       )
                    //todo can users search for any other meal attriutes in order to find a meal?
                    {
                        MealList.Controls.Add(newMealButton);
                    }
                }
                else
                {
                    MealList.Controls.Add(newMealButton);
                }
            }
        }
    }

    //Returns the meal currently being shown (meal in context)
    TableAttributeList getCurrentChef()
    {
        string id;
        try
        {
            id = backEnd.GetUserSession(Session["currentUserID"].ToString(), "USER_IN_CONTEXT");
        }
        catch (Exception e)
        {
            DebugLogger.put_a_breakpoint_inside_this_function(e);
            return null;
        }

        return backEnd._storage.getUserById(id);
    }
}