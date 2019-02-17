using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Aspx_SignUp : System.Web.UI.Page
{
    BackEnd backEnd = new BackEnd();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Hide navigation bar options because on sign up
        Master.FindControl("navigationbar").Visible = false;
    }

    protected void signUpButtonClicked(object sender, EventArgs e)
    {
        //Read form attributes into user object
        User newUser = new User();

        //add unique ID for user
        string input_id = backEnd._storage.generateUniqueUserID();
        string input_name = name.Value;

        //Get image //todo
        Stream imageIn = photo_upload.FileContent;
        string input_picture_id = "no-image";

        if (!newUser.setAttributeValue("id", input_id) ||
            !newUser.setAttributeValue("name", name.Value) ||
            !newUser.setAttributeValue("password", password.Value) ||
            !newUser.setAttributeValue("full_name", full_name.Value) ||
            !newUser.setAttributeValue("address_line_1", address_line_1.Value) ||
            !newUser.setAttributeValue("address_line_2", address_line_2.Value) ||
            !newUser.setAttributeValue("address_city", address_city.Value) ||
            !newUser.setAttributeValue("address_post_code", address_post_code.Value) ||
            !newUser.setAttributeValue("address_description", address_description.Value) ||
            !newUser.setAttributeValue("date_of_birth", date_of_birth.Value) ||
            !newUser.setAttributeValue("additional_info", additional_info.Value) ||
            !newUser.setAttributeValue("contact_email", contact_email.Value) ||
            !newUser.setAttributeValue("contact_phone", contact_phone.Value) ||
            !newUser.setAttributeValue("picture_id", input_picture_id) ||
            !newUser.setAttributeValue("logged_in", "false") ||
            !newUser.setAttributeValue("rating", Globals.NewUsersRating) ||
            !newUser.setAttributeValue("is_admin", "false")
            )
        {
            Errors.InnerText = "Database error! Code #2203";
            return;
        }

        //Validation
        string inputValidationErrors = backEnd._inputValiddation.validateUser(newUser);
        if (inputValidationErrors != "SUCCESS")
        {
            Errors.InnerText = inputValidationErrors;
            return;
        }

        //check if user already exists
        if (backEnd._storage.doesNameExist(input_name))
        {
            Errors.InnerText = "User already exists!";
            return;
        }

        //If validated, send new user to database 
        if(!newUser.insertIntoDatabase())
        {
            Errors.InnerText = "Database error! Code #2210";
            return;
        }

        if (!backEnd._storage.loginUser(input_id))
        {
            Errors.InnerText = "Database error! Code #2211";
            return;
        }

        //Send email verification
        backEnd._helpfullFunctions.sendVerificationEmail(newUser);

        //save currentUserID
        Session["currentUserID"] = input_id;

        //navigate to homePage
        Response.Redirect("../Navigation/Home.aspx");
    }
}
