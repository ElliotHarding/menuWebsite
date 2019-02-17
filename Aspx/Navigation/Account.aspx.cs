using System;

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
            DebugLogger.put_a_breakpoint_inside_this_function(ee);
            Response.Redirect("../Welcome/login.aspx");
        }
    }

    protected void Orders_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Account/Orders.aspx");
    }

    protected void Meals_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Account/Meals.aspx");
    }

    protected void Settings_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Account/Settings.aspx");
    }
}