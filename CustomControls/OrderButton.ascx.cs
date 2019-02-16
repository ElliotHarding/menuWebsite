using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Aspx_OrderButton : System.Web.UI.UserControl
{
    private Order shownOrder = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        name.Text = "Not Loaded";
        date.Text = "Not Loaded";
        picture.ImageUrl = "Not Loaded";
    }

    //Used to populate control, returns true if succeeded
    public bool populate(Order order)
    {
        shownOrder = order;

        //Get attributes, check not null
        string _name = order.getAttribute("meal_name");
        string _date = "todo"/*order.getAttribute("date"); todo add */;
        string _picture = "todo"/*meal.getAttribute("imgLocation")*/;//todo add img url to meal table
        if (_name == null || _date == null || _picture == null) return false;

        //Fill html with values
        name.Text = _name;
        date.Text = _date;
        picture.ImageUrl = _picture;

        return true;
    }

    protected void viewButton_Click(object sender, EventArgs e)
    {
        if (shownOrder != null)
        {
            Session["selectedOrder"] = shownOrder.getAttribute("id");
            Response.Redirect("../View/Order.aspx");
        }
    }
}