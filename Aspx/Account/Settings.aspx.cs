using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;

public partial class Aspx_UserSettings : System.Web.UI.Page
{
    BackEnd backEnd = new BackEnd();

    //Function called when user details are updated
    private void userDetailsUpdated()
    {
        Successes.InnerText = "Updated!";
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
            DebugLogger.put_a_breakpoint_inside_this_function(ee);
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
        name.Value = currentUser.getAttribute("name");
        password.Value = currentUser.getAttribute("password");
        full_name.Value = currentUser.getAttribute("full_name");
        address_line_1.Value = currentUser.getAttribute("address_line_1");
        address_line_2.Value = currentUser.getAttribute("address_line_2");
        address_city.Value = currentUser.getAttribute("address_city");
        address_post_code.Value = currentUser.getAttribute("address_post_code");
        address_description.Value = currentUser.getAttribute("address_description");
        date_of_birth.Value = currentUser.getAttribute("date_of_birth");
        additional_info.Value = currentUser.getAttribute("additional_info");
        contact_email.Value = currentUser.getAttribute("contact_email"); 
        contact_phone.Value = currentUser.getAttribute("contact_phone");

        //todo picture....
    }

    //Function called when user presses 'submit' to save their account settings changes
    protected void OnSubmit(object sender, EventArgs e)
    {
        User newDetails = backEnd._storage.getUserById(Session["currentUserID"].ToString());
        if (newDetails == null)
        {
            Errors.InnerText = "Database error! Code #2203";
            return;
        }

        string input_picture_id = "todo";

        if (
            !newDetails.setAttributeValue("name", name.Value) ||
            !newDetails.setAttributeValue("password", password.Value) ||
            !newDetails.setAttributeValue("full_name", full_name.Value) ||
            !newDetails.setAttributeValue("address_line_1", address_line_1.Value) ||
            !newDetails.setAttributeValue("address_line_2", address_line_2.Value) ||
            !newDetails.setAttributeValue("address_city", address_city.Value) ||
            !newDetails.setAttributeValue("address_post_code", address_post_code.Value) ||
            !newDetails.setAttributeValue("address_description", address_description.Value) ||
            !newDetails.setAttributeValue("date_of_birth", date_of_birth.Value) ||
            !newDetails.setAttributeValue("additional_info", additional_info.Value) ||
            !newDetails.setAttributeValue("contact_email", contact_email.Value) ||
            !newDetails.setAttributeValue("contact_phone", contact_phone.Value) ||
            !newDetails.setAttributeValue("picture_id", input_picture_id)

            //!newDetails.setAttributeValue("id", newDetails.getAttribute("id")) ||
            //!newDetails.setAttributeValue("logged_in", newDetails.getAttribute("logged_in")) ||
            //!newDetails.setAttributeValue("rating", newDetails.getAttribute("rating")) ||
            //!newDetails.setAttributeValue("is_admin", newDetails.getAttribute("is_admin"))
            )
        {
            Errors.InnerText = "Database error! Code #2203";
            return;
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