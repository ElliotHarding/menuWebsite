using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Aspx_Eat_Search_By_Chefs : System.Web.UI.Page
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
            DebugLogger.put_a_breakpoint_inside_this_function(ee);
            Response.Redirect("../Welcome/login.aspx");
        }

        ViewChefs();
    }

    protected void ViewChefs()
    {
        bool orderByDistance = false;
        bool orderByRating = false;
        bool orderByName = false;
        //todo
        string searchString = "SELECT * FROM [User] "; //WHERE isChef = 'true' ";

        //get search word, if exists apply as filter
        if (orderByDistance)
        {
            searchString += "ORDER BY **TODO**;";
        }
        else if (orderByRating)
        {
            searchString += "ORDER BY **TODO**;";
        }
        else if (orderByName)
        {
            searchString += "ORDER BY **TODO**;";
        }

        //Run sql query, and attempt to fill results
        List<User> chefs = backEnd._storage.getListOfUsers(searchString);
        if (chefs.Count > 0)
        {
            foreach (User chef in chefs)
            {
                Aspx_ChefButton newChefButton = (Aspx_ChefButton)LoadControl(Globals.ChefButtonInclude);
                newChefButton.populate(chef);

                if (SearchBox.Value != null && SearchBox.Value != "")
                {
                    if (chef.getAttribute("name").Contains(SearchBox.Value) //||
                                                                            //chef.getAttribute("rating").Contains(SearchBox.Value) )
                       )
                    //todo can users search for any other chef attriutes in order to find a chef?
                    {
                        ChefsList.Controls.Add(newChefButton);
                    }
                }

                //If we're not searching using a keyword then might as well show all results
                else
                {
                    ChefsList.Controls.Add(newChefButton);
                }
            }
        }
        else
        {
            Errors.InnerText = "Failed to populate chefs! Error code #1902";
        }
    }
}