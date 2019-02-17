using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Aspx_ViewOrder : System.Web.UI.Page
{
    BackEnd backEnd = new BackEnd();
    TableAttributeList orderShown = null;

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

        displayOrder();
    }

    private void displayOrder()
    {
        orderShown = getCurrentOrder();
        if (orderShown == null)
        {
            ErrorDisplay.InnerText = "Error! No order to display.";
            return;
        }

        num_portions_ordered.Text = orderShown.getAttribute("num_portions_ordered");
        meal_name.Text = backEnd._storage.getMealById(orderShown.getAttribute("meal_id")).getAttribute("meal_name");
        active.Text = orderShown.getAttribute("active");
    }

    //Returns the meal currently being shown (meal in context)
    TableAttributeList getCurrentOrder()
    {
        string id;
        try
        {
            id = backEnd.GetUserSession(Session["currentUserID"].ToString(), "ORDER_IN_CONTEXT");
        }
        catch (Exception e)
        {
            DebugLogger.put_a_breakpoint_inside_this_function(e);
            return null;
        }

        return backEnd._storage.getOrderById(id);
    }
}