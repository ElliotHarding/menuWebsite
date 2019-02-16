using System.Collections.Generic;
using System.Text.RegularExpressions;

public class InputValidation/*
If you're looking for database validation
better off looking in Storage Class*/
{

    //Returns true if stringBeingUsed contains no sql
    //Returns false otherwise
    public bool sqlSecurityCheck(string stringBeingUsed)
    {
        /*
        Found this post on stack overflow: 
        (It basically says we should program our framework
        so sql injections don't do any harm, theres no real way of parsing injection
        from user input)
        */
        return true;
    }

    public string validateUser(TableAttributeList user)
    {
        List<string> failReasons = new List<string>();

        //Gonna change this up in a later fix

        //Check for sneaky sql
        foreach (TableAttribute userAttribute in user.GetTableAttributes())
        {
            if (!sqlSecurityCheck(userAttribute.value))
            {
                failReasons.Add(userAttribute.id.ToString() + "Contains fuckin sql");
            }
        }

        string full_name = user.getAttribute("full_name");//onlyCharsAndNumbers(therefore noLinks) watchYourProfanity
        string name = user.getAttribute("name");//onlyCharsAndNumbers(therefore noLinks) watchYourProfanity
        string address_line_1 = user.getAttribute("address_line_1");//own function called down below
        string address_line_2 = user.getAttribute("address_line_2");//own function called down below
        string address_city = user.getAttribute("address_city");//own function called down below
        string address_post_code = user.getAttribute("address_post_code");//own function called down below
        string address_description = user.getAttribute("address_description");//onlyCharsAndNumbers(therefore noLinks) watchYourProfanity
        string date_of_birth = user.getAttribute("date_of_birth");//input shoud probably allready be validated
        string additional_info = user.getAttribute("additional_info");//onlyCharsAndNumbers(therefore noLinks) watchYourProfanity 
        string contact_email = user.getAttribute("contact_email");//own function
        string contact_phone = user.getAttribute("contact_phone");//own function 

        if (contact_phone == null || validatePhoneNumber(contact_phone))
        {
            failReasons.Add("Phone number is unrecognized");
        }
        if (contact_email == null || validateEmail(contact_email))
        {
            failReasons.Add("Unrecognized email");
        }
        if (name == null || !onlyCharsAndNumbers(name))
        {
            failReasons.Add("Username can only contains numbers and letters");
        }
        if (contact_phone == null || !onlyCharsAndNumbers(full_name))
        {
            failReasons.Add("Name can only contains numbers and letters");
        }
        if (contact_phone == null || !onlyCharsAndNumbers(address_description))
        {
            failReasons.Add("Address description can only contains numbers and letters");
        }
        if (contact_phone == null || !onlyCharsAndNumbers(additional_info))
        {
            failReasons.Add("Additional info can only contains numbers and letters");
        }
        if (name == null || !watchYourProfanity(name))
        {
            failReasons.Add("Username contains profanity");
        }
        if (full_name == null || !watchYourProfanity(full_name))
        {
            failReasons.Add("Your name contains profanity");
        }
        if (address_description == null || !watchYourProfanity(address_description))
        {
            failReasons.Add("address_description");
        }
        if (additional_info == null || !watchYourProfanity(additional_info))
        {
            failReasons.Add("Additional info contains profanity");
        }
        if (additional_info == null || !noLinks(additional_info))
        {
            failReasons.Add("Additional info contains url links");
        }
        if (address_description == null || !noLinks(address_description))
        {
            failReasons.Add("Address description info contains url links");
        }
        if (!validateAddress(address_line_1, address_line_2, address_city, address_post_code))
        {
            failReasons.Add("Unrecognized address");
        }

        if (failReasons.Count == 0)
        {
            return "SUCCESS";
        }
        else
        {
            string errorReasons = "";
            foreach (string error in failReasons)
            {
                errorReasons += error + "\n";
            }
            return errorReasons;
        }
    }

    //Validates a meal.
    //returns string with "SUCCESS" OR a list of error reasons split by a ','
    //Warning! this does not validate the meals photo(s) as the tableAttributeList only contains the id of the photo(s)!
    public string validateMeal(TableAttributeList meal)
    {
        List<string> failReasons = new List<string>();

        //Check for sneaky sql
        foreach (TableAttribute userAttribute in meal.GetTableAttributes())
        {
            if (! sqlSecurityCheck(userAttribute.value))
            {
                failReasons.Add(userAttribute.id.ToString() + "Contains sneaky sql code!");
            }
        }

        string meal_name = meal.getAttribute("meal_name");
        string ingredients_list = meal.getAttribute("ingredients_list");
        string estimated_calories = meal.getAttribute("estimated_calories");
        string price = meal.getAttribute("price");
        string collection_time = meal.getAttribute("collection_time");
        string number_of_portions_avaliable = meal.getAttribute("number_of_portions_avaliable");

        if (stringIsBoolean(meal.getAttribute("is_halal")))
        {
            failReasons.Add("Make sure is_halal is 'yes' or 'no'");
        }
        if (stringIsBoolean(meal.getAttribute("is_vegan")))
        {
            failReasons.Add("Make sure is_vegan is 'yes' or 'no'");
        }
        if (stringIsBoolean(meal.getAttribute("is_vegiterian")))
        {
            failReasons.Add("Make sure is_vegiterian is 'yes' or 'no'");
        }
        if (stringIsBoolean(meal.getAttribute("contains_milk")))
        {
            failReasons.Add("Make sure contains_milk is 'yes' or 'no'");
        }
        if (!stringIsBoolean(meal.getAttribute("contains_gluten")))
        {
            failReasons.Add("Make sure contains_gluten is 'yes' or 'no'");
        }


        if (!noLinks(meal_name))
        {
            failReasons.Add("Meal name contains links");
        }
        if (!noLinks(ingredients_list))
        {
            failReasons.Add("Ingredients list contains url links");
        }
        if (!watchYourProfanity(ingredients_list))
        {
            failReasons.Add("Ingredients list contains profanity");
        }
        if (!watchYourProfanity(meal_name))
        {
            failReasons.Add("Meal name contains profanity");
        }
        if (!onlyNumbers(estimated_calories))
        {
            failReasons.Add("Estimated calories should only contain numbers");
        }
        if (!onlyNumbers(price))
        {
            failReasons.Add("Price contains unwanted characters");
        }
        if (!onlyNumbers(number_of_portions_avaliable) && number_of_portions_avaliable.Length < 3 /*up to 99 meals*/)
        {
            failReasons.Add("Number of portions is too large or contains characters");
        }
        if (!validTime(collection_time))
        {
            failReasons.Add("Invalid collection time");
        }

        if (failReasons.Count == 0)
        {
            return "SUCCESS";
        }
        else
        {
            string errorReasons = "";
            foreach (string error in failReasons)
            {
                errorReasons += error + "\n";
            }
            return errorReasons;
        }
    }

    //Returns true if testString's length is between min and max (inclusive)
    private bool lengthCheck(string testString, int min, int max)
    {
        if (testString.Length >= max || testString.Length <= min)
        {
            return false;
        }
        return true;
    }

    private bool validateAddress(string address_line_1, string address_line_2, string address_city, string address_post_code)
    {
        //todo
        //i suggest we the google maps api, but need to make an account and i cbf right now

        //string fullAddress = address_line_1 + address_line_2 + address_city + address_post_code;
        //string url = "https://maps.googleapis.com/maps/api/geocode/json?address=%" + fullAddress + "&key=" + MyStaticMethods.GOOGLE_API_KEY;
        //object result = new WebClient().DownloadString(url);
        //string json = result.ToString();
        return true;
    }

    //returns true if string has no links inside
    private bool noLinks(string testString)
    {
        if (
            testString.Contains("www.") ||
            testString.Contains("https://") ||
            testString.Contains("http://") ||
            testString.Contains(".com") ||
            testString.Contains(".onion")

            //please add more if you can think of any
            )
        {
            return false;
        }

        return true;
    }

    //Returns true if no profanity, returns false if someones a bad boy
    public bool watchYourProfanity(string testString) //TEMP CHANGE BACK TO PRIVATE
    {
        foreach (string badWord in FileReader.readFile(Globals.profanityFile))
        {
            if (testString.Contains(badWord))
            {
                return false;
            }
        }

        return true;
    }

    //returns true if time-string is valid, returns false otherwise
    private bool validTime(string time)
    {
        //todo - might not need to do this...

        // DateTime dateTime = new DateTime();

        return true;
    }

    //returns true if string is valid phone number
    private bool validatePhoneNumber(string phoneNumber)
    {
        if (phoneNumber == null || phoneNumber.Length < 5)
            return false;

        if ((phoneNumber[0] == '+'))
        {
            if (onlyNumbers(phoneNumber.Substring(1)))
            {
                return (lengthCheck(phoneNumber, 12, 13));
            }
            return false;
        }
        else
        {
            if (onlyNumbers(phoneNumber))
            {
                return (lengthCheck(phoneNumber, 10, 11));
            }
            return false;
        }
    }

    //returns true if string is valid email
    private bool validateEmail(string email)
    {
        //https://stackoverflow.com/questions/1365407/c-sharp-code-to-validate-email-address
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    //returns true if test string only contains chars (no symbols or numbers)
    private bool onlyChars(string testString)
    {
        return Regex.IsMatch(testString, @"^[a-zA-Z]+$"); ;
    }

    //returns ture if test string only contains a bool (0 or 1)
    private bool stringIsBoolean(string testString)
    {
        return (testString == "yes" || testString == "no");
    }

    //returns true if test string only contains chars and numbers
    //
    //currently not used anywhere, might delete this later
    //update this comment if it gets used please
    //
    private bool onlyCharsAndNumbers(string testString)
    {
        return Regex.IsMatch(testString, @"^[a-zA-Z0-9]+$");
    }

    //Returns true if test string only contains numbers 
    public bool onlyNumbers(string testString)
    {
        foreach (char c in testString)
        {
            if (c < '0' || c > '9')
                return false;
        }
        return true;
    }
}