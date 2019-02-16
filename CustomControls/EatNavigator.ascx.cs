using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CustomControls_EatNavigator : System.Web.UI.UserControl
{
    protected void Meals_Click(object sender, EventArgs e)
    {
        Response.Redirect("Search-By-Meals.aspx");
    }
    protected void Chefs_Click(object sender, EventArgs e)
    {
        Response.Redirect("Search-By-Chefs.aspx");
    }
}