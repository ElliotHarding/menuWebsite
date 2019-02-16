using System;

public partial class Aspx_AddMealPage : System.Web.UI.Page
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
            Response.Redirect("../Welcome/login.aspx");
        }

    }

    //Function is run after a succesfull meal addition to database
    protected void afterSuccessfulMealAddition()
    {
        Response.Redirect("Meal-Added.aspx");
    }

    //Called when submit button for add meal form is clicked
    protected void addMeal(object sender, EventArgs e)
    {
        Meal newMeal = new Meal();
        foreach (TableAttribute attribute in newMeal.GetTableAttributes())
        {
            if(!newMeal.setAttributeValue(attribute.id, Request.Form["ctl00$Main_Content_Placeholder$" + attribute.id]))
            {
                Errors.InnerText = "Back end error! Code #6654";
                return;
            }
        }

        //Code generated meal attributes go here
        newMeal.setAttributeValue("owner_user_id", Session["currentUserID"].ToString());

        //validation
        string inputValidationErrors = backEnd._inputValiddation.validateMeal(newMeal);
        if (inputValidationErrors != "SUCCESS")
        {
            Errors.InnerText = inputValidationErrors;
            return;
        }

        //If validated, send new meal to database 
        if (!newMeal.insertIntoDatabase())
        {
            Errors.InnerText = "Back end error! Code #6655";
            return;
        }

        afterSuccessfulMealAddition();
    }

    //Check there are no other meals with the same data as the new meal
    //Returns true if meal is not in database
    //Returns false if meal is in database
    private bool mealIsUnique(TableAttributeList meal)
    {
        //todo
        return true;
    }
}