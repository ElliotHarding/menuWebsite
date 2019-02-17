using System;
using System.Web.UI.HtmlControls;

public partial class Aspx_EditMeal : System.Web.UI.Page
{
    static BackEnd backEnd = new BackEnd();

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
        if (!IsPostBack)
        {
            configureMeal();
        }
    }

    private void configureMeal()
    {
        Meal mealShown = getCurrentMeal();
        if(mealShown == null)
        {
            return;
        }

        try
        {
            meal_name.Value = mealShown.getAttribute("meal_name");
            is_halal.Value = mealShown.getAttribute("is_halal");
            is_vegan.Value = mealShown.getAttribute("is_vegan");
            is_vegiterian.Value = mealShown.getAttribute("is_vegiterian");
            contains_gluten.Value = mealShown.getAttribute("contains_gluten");
            contains_milk.Value = mealShown.getAttribute("contains_milk");
            ingredients_list.Value = mealShown.getAttribute("ingredients_list");
            estimated_calories.Value = mealShown.getAttribute("estimated_calories");
            price.Value = mealShown.getAttribute("price");
            collection_time.Value = mealShown.getAttribute("collection_time");
            number_of_portions_avaliable.Value = mealShown.getAttribute("number_of_portions_avaliable");
            //todo picture_id.Value
        }
        catch (Exception e)
        {
            Errors.InnerText = "Can't configure meal! Database error";
            return;
        }
    }

    //Function called when 'edit meal' button is clicked
    //Intention is to read html of meals data and update it
    protected void editMeal(object sender, EventArgs e)
    {
        //Get the meal in context to update
        Meal mealShown = getCurrentMeal();
        Meal newDetails = mealShown;
        if (newDetails == null)
        {
            Errors.InnerText = "Back end error. Code #7897";
            return;
        }

        //Code generated meal attributes go here
        if (!newDetails.setAttributeValue("id", backEnd._storage.generateUniqueMealID()) ||
            !newDetails.setAttributeValue("owner_user_id", Session["currentUserID"].ToString()) ||
            !newDetails.setAttributeValue("meal_name", meal_name.Value) ||
            !newDetails.setAttributeValue("is_halal", is_halal.Value) ||
            !newDetails.setAttributeValue("is_vegan", is_vegan.Value) ||
            !newDetails.setAttributeValue("is_vegiterian", is_vegiterian.Value) ||
            !newDetails.setAttributeValue("contains_gluten", contains_gluten.Value) ||
            !newDetails.setAttributeValue("contains_milk", contains_milk.Value) ||
            !newDetails.setAttributeValue("ingredients_list", ingredients_list.Value) ||
            !newDetails.setAttributeValue("estimated_calories", estimated_calories.Value) ||
            !newDetails.setAttributeValue("picture_id", picture_id.Value) ||
            !newDetails.setAttributeValue("price", price.Value) ||
            !newDetails.setAttributeValue("collection_time", collection_time.Value) ||
            !newDetails.setAttributeValue("number_of_portions_avaliable", number_of_portions_avaliable.Value)
            )
        {
            Errors.InnerText = "Back end error! Code #6652";
            return;
        }

        //Validate new details
        string inputValidationErrors = backEnd._inputValiddation.validateMeal(newDetails);
        if (inputValidationErrors != "SUCCESS")
        {
            Errors.InnerText = inputValidationErrors;
            return;
        }

        //update meal
        if (!newDetails.updateInDatabase())
        {
            Errors.InnerText = "Back end error. Code #7899";
            return;
        }

        Successes.InnerText = "Updated!";
    }

    //Returns the meal currently being shown (meal in context)
    Meal getCurrentMeal()
    {
        string id = Session["selectedMeal"].ToString();

        if(id == null)
        {
            return null;
        }

        return backEnd._storage.getMealById(id);
    }
}