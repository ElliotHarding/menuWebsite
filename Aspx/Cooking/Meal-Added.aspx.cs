using System;

public partial class Aspx_AfterMealAdditionPage : System.Web.UI.Page
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

    protected void Another_Click(object sender, EventArgs e)
    {
        Response.Redirect("Add-Meal.aspx");
    }

    protected void Home_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Navigation/Home.aspx");
    }
}