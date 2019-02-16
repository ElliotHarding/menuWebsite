using System;
using System.Collections.Generic;

public partial class Aspx_UserOrders : System.Web.UI.Page
{
    BackEnd backEnd = new BackEnd();

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);

        //Check client is recongnised, otherwise redirect to login page
        try
        {
            if (Session["currentUserID"].ToString() == null || Session["currentUserID"].ToString() == "") Response.Redirect("../Welcome/login.aspx");
        }
        catch (Exception ee)
        {
            Response.Redirect("../Welcome/login.aspx");
        }

        //Run sql query, and attempt to fill MealList with meals
        string selectCommand = "SELECT * FROM [Order] WHERE meal_orderer_id = '" + Session["currentUserID"].ToString() + "';";
        List<Order> usersOrders = backEnd._storage.getListOfOrders(selectCommand);

        if (usersOrders.Count > 0)
        {
            foreach (Order order in usersOrders)
            {
                Aspx_OrderButton newOrderButton = (Aspx_OrderButton)LoadControl(Globals.OrderButtonInclude);
                newOrderButton.populate(order);
                OrderList.Controls.Add(newOrderButton);
            }
        }
        else
        {
            infoMessage.InnerText = "No orders to display.";
        }
    }
}