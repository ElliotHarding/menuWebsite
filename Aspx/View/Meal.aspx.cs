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

        //populate HTML controls with meal data
        //foreach (TableAttribute attribute in mealShown.GetTableAttributes())
        //{
        //    HtmlInputText attributeControl = (HtmlInputText)viewMealForm.FindControl(attribute.id);
        //    if (attributeControl != null)
        //    {
        //        attributeControl.Value = attribute.value;
        //    }
        //}

        attribute1.Value = mealShown.getAttribute("meal_name");
        attribute2.Value = mealShown.getAttribute("contains_gluten");
        attribute3.Value = mealShown.getAttribute("estimated_calories");

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