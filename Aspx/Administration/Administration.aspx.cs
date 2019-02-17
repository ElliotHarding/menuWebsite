using System;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Aspx_Administration : System.Web.UI.Page
{
    BackEnd backEnd = new BackEnd();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Check client is recongnised, otherwise redirect to login page
        try
        {
            if (!backEnd._storage.isUserAdmin(Session["currentUserID"].ToString()))
                Response.Redirect("../Welcome/login.aspx");
        }
        catch (Exception ee)
        {
            DebugLogger.put_a_breakpoint_inside_this_function(ee);
            Response.Redirect("../Welcome/login.aspx");
        }

        if (!IsPostBack)
        {
             //todo only show to admins
            showToOnlyAdmin.Visible = true;

            populateGrids();
        }
    }  

    private void populateGrids()
    {
        UsersGridView.DataSource = backEnd._storage.runSelectCommand("SELECT * FROM [USER]");
        UsersGridView.DataBind();

        MealsGridView.DataSource = backEnd._storage.runSelectCommand("SELECT * FROM [Meal]");
        MealsGridView.DataBind();

        ActiveOrdersGridView.DataSource = backEnd._storage.runSelectCommand("SELECT * FROM [Order]");
        ActiveOrdersGridView.DataBind();
    }
}

