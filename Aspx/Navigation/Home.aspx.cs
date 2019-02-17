using System;


public partial class Aspx_HomePage : System.Web.UI.Page
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

    protected void Account_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Navigation/Account.aspx");
    }

    protected void Cook_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Cooking/Add-Meal.aspx");
    }

    protected void Eat_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Eat/Search-By-Meals.aspx");
    }
}