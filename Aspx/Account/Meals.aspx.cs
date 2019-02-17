using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Aspx_UserMeals : System.Web.UI.Page
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
            DebugLogger.put_a_breakpoint_inside_this_function(ee);
            Response.Redirect("../Welcome/login.aspx");
        }

        //Run sql query, and attempt to fill MealList with meals
        string selectCommand = "SELECT * FROM [Meal] WHERE owner_user_id = '" + Session["currentUserID"].ToString() + "';";
        List<Meal> usersMeals = backEnd._storage.getListOfMeals(selectCommand);

        if (usersMeals.Count > 0)
        {
            foreach (Meal meal in usersMeals)
            {
                Aspx_MealButton newMealButton = (Aspx_MealButton)LoadControl(Globals.MealButtonInclude);
                newMealButton.populate(meal);
                MealList.Controls.Add(newMealButton);
            }
        }
        else
        {
            infoMessage.InnerText = "No meals to display.";
        }
    }
}