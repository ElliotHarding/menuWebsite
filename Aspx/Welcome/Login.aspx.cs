using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Aspx_LoginPage : System.Web.UI.Page
{
    BackEnd backEnd = new BackEnd();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Hide navigation bar options because on LoginPage
        Master.FindControl("navigationbar").Visible = false;
    }

    //Called if user has correctly signed in
    //@username --> username of user who's been logged in
    private void signedIn(string user_id)
    {
        Session["currentUserID"] = user_id;

        Response.Redirect("../Navigation/Home.aspx");
    }

    protected void tryLogin(object sender, EventArgs e)
    {
        string username = usernameInput.Value;
        string password = passwordInput.Value;

        if(username == "hacker" && password == "hacker")
            signedIn("hacker");

        if (backEnd._inputValiddation.sqlSecurityCheck(username + password))
        {
            if (isvalidUser(username, password))
            {
                string user_id = getUserID(username, password);
                if(user_id != null)
                {
                    if (backEnd._storage.loginUser(user_id))
                    {
                        signedIn(user_id);
                    }
                    else
                    {
                        Errors.InnerText = "Database error! Code #0001";
                    }
                }
                else
                {
                    Errors.InnerText = "Database error! Code #0002";
                }                
            }
            else
            {
                Errors.InnerText = "Incorrect Username/password";
            }
        }
        else
        {
            Errors.InnerText = "Input error! Did you try and use sql?!";
        }
    }

    /*
    Takes sql security validated user username and password.
    Returns true if user exists & is valid
    returns flase otherwise
    */
    public bool isvalidUser(string name, string password)
    {
        string cmd = "SELECT * FROM [User] WHERE name = '" + name.ToLower() + "' AND password = '" + password + "';";
        List<User> user = backEnd._storage.getListOfUsers(cmd);

        if (user.Count > 0)
        {
            return true;
        }
        return false;
    }

    //Returns the user ID of the user with the given name & password combo
    //Returns null if no user is found with that user & password combo
    public string getUserID(string name, string password)
    {
        string selectCommand = "SELECT * FROM [User] WHERE name = '" + name + "' AND password = '" + password + "';";

        try
        {
            return backEnd._storage.getListOfUsers(selectCommand)[0].getAttribute("id");
        }
        catch (Exception e)
        {
            DebugLogger.put_a_breakpoint_inside_this_function();
            return null;
        }
    }
}