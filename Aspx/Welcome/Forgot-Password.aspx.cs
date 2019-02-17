using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Aspx_ForgotPassword : System.Web.UI.Page
{
    BackEnd backEnd = new BackEnd();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Hide navigation bar options because not logged in
        Master.FindControl("navBarHomeButton").Visible = false;
        Master.FindControl("navBarEatButton").Visible = false;
        Master.FindControl("navBarAccountButton").Visible = false;
        Master.FindControl("navBarLoginPageButton").Visible = true;
    }

    //Function called if reset email is sent correctly
    private void emailSent()
    {
        Successes.InnerText = "Sent!";
    }

    protected void sendRestLink(object sender, EventArgs e)
    {
        string email = emailInput.Value;

        if (backEnd._storage.doesEmailExist(email))
        {
            if(backEnd._helpfullFunctions.sendAccountResetEmail(email))
            {
                emailSent();
            }
            else
            {
                Errors.InnerText = "Failed to send email! Error code #9901";
            }
        }
        else
        {
            Errors.InnerText = "The email entered is not in our database!";
        }
    }
}