﻿using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Aspx_ForgotPassword : System.Web.UI.Page
{
    BackEnd backEnd = new BackEnd();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Hide navigation bar options because on LoginPage
        Master.FindControl("navigationbar").Visible = false;
    }

    //Function called if reset email is sent correctly
    private void emailSent()
    {
        //todo
        //perhaps change 'send' button text to 're-send'
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