using System;

public partial class Aspx_MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void Home_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Navigation/Home.aspx");
    }

    protected void Eat_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Eat/Search-By-Meals.aspx");
    }

    protected void Account_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Navigation/Account.aspx");
    }
}
