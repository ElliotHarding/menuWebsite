using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;

public partial class Aspx_UserSettings : System.Web.UI.Page
{
    BackEnd backEnd = new BackEnd();

    //Function called when user details are updated
    private void userDetailsUpdated()
    {
        //todo
    }

    //Called when page loads
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
            populateData();
        }
    }


    /*
    Load controls with currentUser data
    Only editable data (specified by the controls id)
    Returns true if sucsessfully populated controls otherwise returns false
    */
    private void populateData()
    {
        //Get current user ID and validate
        string currentUserID = Session["currentUserID"].ToString();
        if (currentUserID == null)
        {
            Errors.InnerText = "Not logged in!";
            return;
        }

        //Get current user & validate
        User currentUser = backEnd._storage.getUserById(currentUserID);
        if (currentUser == null)
        {
            Errors.InnerText = "Not logged in!";
            return;
        }

        //populate HTML controls with user data
        foreach (TableAttribute attribute in currentUser.GetTableAttributes())
        {
            
        }
    }

    //Function called when user presses 'submit' to save their account settings changes
    protected void OnSubmit(object sender, EventArgs e)
    {
        User newDetails = backEnd._storage.getUserById(Session["currentUserID"].ToString());

        //Update attributes via html
        foreach (TableAttribute attribute in newDetails.GetTableAttributes())
        {
            if (!newDetails.setAttributeValue(attribute.id, Request.Form["ctl00$Main_Content_Placeholder$" + attribute.id]))
            {
                Errors.InnerText = "Back end error! Code:5576";
                return;
            }
        }

        //Validate new details
        string inputValidationFail = backEnd._inputValiddation.validateUser(newDetails);
        if (inputValidationFail != "SUCCESS")
        {
            Errors.InnerText = inputValidationFail;
            return;
        }

        //Run update command
        if (!newDetails.updateInDatabase())
        {
            Errors.InnerText = "Back end error! Code:5577";
            return;
        }

        userDetailsUpdated();
    }

    protected void LogOut(object sender, EventArgs e)
    {
        Session["currentUserID"] = null;
        Response.Redirect("../Welcome/Login.aspx");
    }
}