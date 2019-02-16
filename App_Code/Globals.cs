using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class Globals
{
    public static string HomeDirectory = System.Web.Hosting.HostingEnvironment.MapPath(@"~/App_Data/").Replace("\\","/");

    //Custom Controls, install location
    public const string ChefButtonInclude = "~/CustomControls/ChefButton.ascx";
    public const string MealButtonInclude = "~/CustomControls/MealButton.ascx";
    public const string OrderButtonInclude = "~/CustomControls/OrderButton.ascx";

    public const string ImagesStorage = "../../App_Data/AccountImages/";

    public static string VerifyEmailFile = "@" + HomeDirectory + "not created yet";
    public static string profanityFile = "@" + HomeDirectory + "ProfanityList.txt";


    public const string websiteURL = "";

    public const string NewUsersRating = "2.5";

    
}