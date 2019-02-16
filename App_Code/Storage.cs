using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

public class Storage
{
    private const string m_c_connectionString = @"Data Source=den1.mssql7.gear.host; Database=menudatabase; User=menudatabase; Password='Ss6y7-?5dgjN';";

    public List<Order> getListOfOrders(string selectCommand = "NO COMMAND RETURNS ALL ELEMENTS")
    {
        List<Order> Attributes = new List<Order>();

        if(selectCommand == "NO COMMAND RETURNS ALL ELEMENTS")
        {
            selectCommand = "SELECT * FROM [ORDER]";
        }

        try
        {
            using (SqlConnection conn = new SqlConnection(m_c_connectionString))
            {
                conn.Open();

                using (SqlDataReader reader = new SqlCommand(selectCommand, conn).ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Attributes.Add(new Order(reader));
                    }
                }
            }
        }
        catch (Exception e)
        {
            DebugLogger.put_a_breakpoint_inside_this_function();
        }

        return Attributes;
    }

    public bool isUserAdmin(string currentUserID)
    {
        return true;
        //todo when is_admin exists uncomment this
        /*
        if (currentUserID == null || currentUserID == "")
            return false;

        User user = getUserById(currentUserID);
        return (user.getAttribute("is_admin") == "true"); */
    }

    public List<Meal> getListOfMeals(string selectCommand = "NO COMMAND RETURNS ALL ELEMENTS")
    {
        List<Meal> Attributes = new List<Meal>();

        if (selectCommand == "NO COMMAND RETURNS ALL ELEMENTS")
        {
            selectCommand = "SELECT * FROM [Meal]";
        }

        try
        {
            using (SqlConnection conn = new SqlConnection(m_c_connectionString))
            {
                conn.Open();

                using (SqlDataReader reader = new SqlCommand(selectCommand, conn).ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Attributes.Add(new Meal(reader));
                    }
                }
            }
        }
        catch (Exception e)
        {
            DebugLogger.put_a_breakpoint_inside_this_function();
        }

        return Attributes;
    }

    public List<User> getListOfUsers(string selectCommand = "NO COMMAND RETURNS ALL ELEMENTS")
    {
        List<User> Attributes = new List<User>();

        if (selectCommand == "NO COMMAND RETURNS ALL ELEMENTS")
        {
            selectCommand = "SELECT * FROM [User]";
        }

        try
        {
            using (SqlConnection conn = new SqlConnection(m_c_connectionString))
            {
                conn.Open();

                using (SqlDataReader reader = new SqlCommand(selectCommand, conn).ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Attributes.Add(new User(reader));
                    }
                }
            }
        }
        catch (Exception e)
        {
            DebugLogger.put_a_breakpoint_inside_this_function();
        }

        return Attributes;
    }

    public DataTable runSelectCommand(string selectCommand)
    {
        DataTable dt = new DataTable();

        try
        {
            using (SqlConnection conn = new SqlConnection(m_c_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(selectCommand, conn);
                cmd.Connection = conn;

                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                    return dt;
                }
            }
        }
        catch (Exception e)
        {
            DebugLogger.put_a_breakpoint_inside_this_function();
        }

        return dt;
    }

    /*
        Runs an SQL command on the server,
        Returns true if execution of command was successfull
    */
    public bool RunCommand(string command)
    {
        try
        {
            using (SqlConnection conn = new SqlConnection(m_c_connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(command, conn);
                cmd.ExecuteNonQuery();
            }
        }
        catch (Exception e)
        {
            DebugLogger.put_a_breakpoint_inside_this_function();
            return false;
        }

        return true;
    }

    public Order getOrderById(string id)
    {
        string selectCommand = "SELECT * FROM [Order] WHERE id = '" + id + "';";

        try
        {
            return getListOfOrders(selectCommand)[0];
        }
        catch (Exception e)
        {
            DebugLogger.put_a_breakpoint_inside_this_function();
            return null;
        }
    }

    public User getUserById(string id)
    {
        string selectCommand = "SELECT * FROM [User] WHERE id = '" + id + "';";

        try
        {
            return getListOfUsers(selectCommand)[0];
        }
        catch (Exception e)
        {
            DebugLogger.put_a_breakpoint_inside_this_function();
            return null;
        }
    }

    public Meal getMealById(string id)
    {
        string selectCommand = "SELECT * FROM [Meal] WHERE id = '" + id + "';";

        try
        {
            return getListOfMeals(selectCommand)[0];
        }
        catch (Exception e)
        {
            DebugLogger.put_a_breakpoint_inside_this_function();
            return null;
        }
    }

    public bool loginUser(string userID)
    {
        string command = "UPDATE [User] SET logged_in = 'true' WHERE id ='" + userID + "';";
        return RunCommand(command);
    }

    public bool logoutUser(string userID)
    {
        string command = "UPDATE [User] SET logged_in = 'false' WHERE id ='" + userID + "';";
        return RunCommand(command);
    }

    public bool doesEmailExist(string email)
    {
        string command = "SELECT * FROM [User] WHERE contact_email = '" + email + "';";
        List<User> user = getListOfUsers(command);

        if (user.Count > 0)
        {
            return true;
        }
        return false;
    }

    public bool doesNameExist(string name)
    {
        string cmd = "SELECT * FROM [User] WHERE name = '" + name.ToLower() + "';";
        List<User> user = getListOfUsers(cmd);

        if (user.Count > 0)
        {
            return true;
        }
        return false;
    }

    public string generateUniqueUserID()
    {
        List<User> allUsers = getListOfUsers();
        if (allUsers.Count > 0)
        {
            return (allUsers.Count + 1).ToString();
        }
        return "0";        
    }

    public string generateUniqueOrderID()
    {
        List<Order> orders = getListOfOrders();
        if(orders.Count > 0)
        {
            return (orders.Count + 10).ToString();
        }
        return "0";
    }
}