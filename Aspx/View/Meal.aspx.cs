using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

public partial class Aspx_ViewMeal : System.Web.UI.Page
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

        if (!IsPostBack)
        {
            configureMeal();
        }       
    }

    //Function called when a user orders a meal
    protected void orderMeal(object sender, EventArgs e)
    {
        string portions = Portions.Value;
        if (portions == null || !backEnd._inputValiddation.onlyNumbers(portions))
        {
            Errors.InnerText = "Can't order meal. Unrecognized number of meals";
            return;
        }

        //Get and verify meal in context
        TableAttributeList mealShown = getCurrentMeal();
        if (mealShown == null)
        {
            Errors.InnerText = "Error! No meal to display.";
            return;
        }

        string userId = Session["currentUserID"].ToString();
        if (userId == null)
        {
            Errors.InnerText = "Can't order meal! Not signed in!";
            return;
        }

        if (mealShown.getAttribute("owner_user_id") == userId)
        {
            Errors.InnerText = "Can't order meal. It belongs to you!";
            return;
        }

        Order newOrder = new Order();
        newOrder.setAttributeValue("id", backEnd._storage.generateUniqueOrderID());
        newOrder.setAttributeValue("meal_id", mealShown.getAttribute("id"));
        newOrder.setAttributeValue("meal_orderer_id", userId);
        newOrder.setAttributeValue("num_portions_ordered", portions);
        newOrder.setAttributeValue("active", "false");

        //add to basket
        if (!newOrder.insertIntoDatabase())
        {
            Errors.InnerText = "Failed to add to basket! Database error.";
            return;
        }

        if(Session["previousPage"].ToString() != null)
        {
            Response.Redirect(Session["previousPage"].ToString());
        }

        Errors.InnerText = "Order saved to basket. But something went wrong...";
    }

    //Populate aspx with currentMeal
    private void configureMeal()
    {
        //Get and verify meal in context
        TableAttributeList mealShown = getCurrentMeal();
        if (mealShown == null)
        {
            Errors.InnerText = "Error! No meal to display.";
            return;
        }

        try
        {
            meal_name.InnerText = mealShown.getAttribute("meal_name");
            is_halal.Text = mealShown.getAttribute("is_halal");
            is_vegan.Text = mealShown.getAttribute("is_vegan");
            is_vegiterian.Text = mealShown.getAttribute("is_vegiterian");
            contains_gluten.Text = mealShown.getAttribute("contains_gluten");
            contains_milk.Text = mealShown.getAttribute("contains_milk");
            ingredients_list.Text = mealShown.getAttribute("ingredients_list");
            estimated_calories.Text = mealShown.getAttribute("estimated_calories");
            price.Text = mealShown.getAttribute("price");
            collection_time.Text = mealShown.getAttribute("collection_time");
            number_of_portions_avaliable.Text = mealShown.getAttribute("number_of_portions_avaliable");
            //todo picture_id.Value
        }
        catch (Exception e)
        {
            Errors.InnerText = "Can't configure meal! Database error";
            return;
        }

        MealImage.ImageUrl = Globals.ImagesStorage + mealShown.getAttribute("picture_id") + ".jpg";
    }

    //Returns the meal currently being shown (meal in context)
    private TableAttributeList getCurrentMeal()
    {
        string mealid = Session["selectedMeal"].ToString();
        
        if(mealid == null)
        {
            return null;
        }

        return backEnd._storage.getMealById(mealid);
    }
}