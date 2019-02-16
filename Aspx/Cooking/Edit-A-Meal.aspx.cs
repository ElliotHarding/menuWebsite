using System;
using System.Web.UI.HtmlControls;

public partial class Aspx_EditMeal : System.Web.UI.Page
{
    static BackEnd backEnd = new BackEnd();

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

    //Function called when meal has been successfully edited
    private void mealEdited()
    {
        //todo
    }

    private void configureMeal()
    {
        Meal mealShown = getCurrentMeal();
        if(mealShown == null)
        {
            return;
        }

        //populate HTML controls with meal data
        foreach (TableAttribute attribute in mealShown.GetTableAttributes())
        {
            HtmlInputText attributeControl = (HtmlInputText)updateMealForm.FindControl(attribute.id);
            if (attributeControl != null)
            {
                attributeControl.Value = attribute.value;
            }
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

        //read html values into meal
        foreach (TableAttribute attribute in newDetails.GetTableAttributes())
        {
            string value = Request.Form["ctl00$Main_Content_Placeholder$" + attribute.id];
            if(value != null)
            {
                if (!newDetails.setAttributeValue(attribute.id, value))
                {
                    Errors.InnerText = "Back end error. Code #7898";
                    return;
                }
            }            
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