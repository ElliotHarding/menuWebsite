using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Aspx_Eat_Search_By_Meals : System.Web.UI.Page
{
    BackEnd backEnd = new BackEnd();

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        //Check client is recongnised, otherwise redirect to login page
        try
        {
            if (Session["currentUserID"].ToString() == null || Session["currentUserID"].ToString() == "") Response.Redirect("../Welcome/login.aspx");
        }
        catch (Exception ee)
        {
            Response.Redirect("../Welcome/login.aspx");
        }


        ViewMeals();
    }

    protected void ViewMeals()
    {
        bool orderByDistance = false;
        bool orderByRating = false;
        bool orderByName = false;
        bool onlyVegan = false;
        bool onlyHalal = false;
        bool onlyVegiterian = false;
        bool noMilk = false;
        bool noLactose = false;
        bool noCheese = false;

        string searchString = "SELECT * FROM [Meal] ";

        //get food type filer, if exists apply as filter
        string foodTypeFilter = getFoodType();
        if (foodTypeFilter != null && foodTypeFilter != "")
        {
            searchString += "WHERE **TODO** = '" + foodTypeFilter + "' ";
        }

        if (orderByDistance)
        {
            searchString += "ORDER BY **TODO**;";
        }
        else if (orderByRating)
        {
            searchString += "ORDER BY **TODO**;";
        }
        else if (orderByName)
        {
            searchString += "ORDER BY **TODO**;";
        }

        //Run sql query, and attempt to fill results
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
        else
        {
            Errors.InnerText = "Failed! Can't populate meals. Error code #1123";
        }
    }

    private string getFoodType()
    {
        //todo
        return null;
    }
}