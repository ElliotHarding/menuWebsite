using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Aspx_ChefButton : System.Web.UI.UserControl
{
    private User shownChef = null;

    public Aspx_ChefButton()
    {

    }

    //Used to populate control, returns true if succeeded
    public bool populate(User chef)
    {
        shownChef = chef;

        //Get attributes, check not null
        string _name = chef.getAttribute("name");
        string _rating = chef.getAttribute("rating") + "/5";
        string _picture = chef.getAttribute("imgLocation");

        //Fill html with values
        name.Text = _name;
        rating.Text = _rating;
        picture.ImageUrl = _picture;

        return true;
    }

    protected void viewButton_Click(object sender, EventArgs e)
    {
        if (shownChef != null)
        { 
            Session["selectedChef"] = shownChef.getAttribute("id");
            Response.Redirect("../View/Chef.aspx");
        }
    }
}