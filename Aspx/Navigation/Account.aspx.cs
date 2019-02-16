﻿using System;

public partial class Aspx_UserAccount : System.Web.UI.Page
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
    }
}