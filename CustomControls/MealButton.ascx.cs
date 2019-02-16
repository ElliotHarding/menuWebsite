using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Aspx_MealButton : System.Web.UI.UserControl
{
    public Meal shownMeal = null;

    public Aspx_MealButton()
    {
    }   

    //Used to populate control, returns true if succeeded
    public bool populate(Meal meal)
    {
        shownMeal = meal;

        //Get attributes, check not null
        string _name = meal.getAttribute("meal_name");
        string _rating = "todo"/*meal.getAttribute("rating") + "/5" */;//todo add rating to meal table
        string _picture = "todo"/*meal.getAttribute("imgLocation")*/;//todo add img url to meal table
        if (_name == null || _rating == null || _picture == null) return false;

        //Fill html with values
        name.Text = _name;
        rating.Text = _rating;
        picture.ImageUrl = _picture;

        return true;
    }

    public void viewButton_Click(object sender, EventArgs e)
    {
        if (shownMeal != null)
        {
            Session["selectedMeal"] = shownMeal.getAttribute("id");

            if (Session["currentUserID"].ToString() == shownMeal.getAttribute("owner_user_id"))
            {
                Response.Redirect("../Cooking/Edit-A-Meal.aspx");
            }
            else
            {
                Session["previousPage"] = Request.CurrentExecutionFilePath;
                Response.Redirect("../View/Meal.aspx");
            }
        }
    }
}