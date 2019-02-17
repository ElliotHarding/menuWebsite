public class BackEnd
{
    //Validation
    public InputValidation _inputValiddation = new InputValidation();

    //Database management
    public Storage _storage = new Storage();

    //Other helpfull functions
    public HelpfullFunctions _helpfullFunctions = new HelpfullFunctions();

    //Saves a user session value
    //returns true if value was successfully set
    public bool SetUserSession(string userID, string memory, string value)
    {
        if (!validMemoryType(memory))
            return false;

        string updateCommand = "UPDATE [UserMemory] " +
            "SET " + memory + " = '" + value + "' " +
            "WHERE id = '" + userID + "' ";

        return (_storage.RunCommand(updateCommand));
    }

    //Gets a user memory value, if the memory tag is not recongnised,
    //returns null
    public string GetUserSession(string userID, string memory)
    {
        string returnString = null;

        if (!validMemoryType(memory))
            return returnString;

        string selectCommand = "SELECT " + memory + " FROM [UserMemory] WHERE id = '" + userID + "';";

        return (_storage.getString(selectCommand));
    }

    private bool validMemoryType(string memory)
    {
        if (
            memory == "LOGGED_IN" ||
            memory == "PREVIOUS_PAGE" ||
            memory == "MEAL_IN_CONTEXT" ||
            memory == "ORDER_IN_CONTEXT" ||
            memory == "USER_IN_CONTEXT"
          )
        {
            return true;
        }
        return false;
    }
}