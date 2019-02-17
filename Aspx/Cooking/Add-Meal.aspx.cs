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
            DebugLogger.put_a_breakpoint_inside_this_function(ee);
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

        //Code generated meal attributes go here
        if (!newMeal.setAttributeValue("id", backEnd._storage.generateUniqueMealID()) ||
            !newMeal.setAttributeValue("owner_user_id", Session["currentUserID"].ToString()) ||
            !newMeal.setAttributeValue("meal_name", meal_name.Value) ||
            !newMeal.setAttributeValue("is_halal", is_halal.Value) ||
            !newMeal.setAttributeValue("is_vegan", is_vegan.Value) ||
            !newMeal.setAttributeValue("is_vegiterian", is_vegiterian.Value) || 
            !newMeal.setAttributeValue("contains_gluten", contains_gluten.Value) ||
            !newMeal.setAttributeValue("contains_milk", contains_milk.Value) ||
            !newMeal.setAttributeValue("ingredients_list", ingredients_list.Value) ||
            !newMeal.setAttributeValue("estimated_calories", estimated_calories.Value) ||
            !newMeal.setAttributeValue("picture_id", picture_id.Value) ||
            !newMeal.setAttributeValue("price", price.Value) ||
            !newMeal.setAttributeValue("collection_time", collection_time.Value) ||
            !newMeal.setAttributeValue("number_of_portions_avaliable", number_of_portions_avaliable.Value)
            )
        {
            Errors.InnerText = "Back end error! Code #6652";
            return;
        }
        

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