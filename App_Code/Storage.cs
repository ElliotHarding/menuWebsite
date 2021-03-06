﻿using System;
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
            DebugLogger.put_a_breakpoint_inside_this_function(e);
        }

        return Attributes;
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
            DebugLogger.put_a_breakpoint_inside_this_function(e);
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
            DebugLogger.put_a_breakpoint_inside_this_function(e);
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
            DebugLogger.put_a_breakpoint_inside_this_function(e);
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
            DebugLogger.put_a_breakpoint_inside_this_function(e);
            return false;
        }

        return true;
    }

    public string getString(string selectCommand)
    {
        string returnString = null;
        try
        {
            using (SqlConnection conn = new SqlConnection(m_c_connectionString))
            {
                conn.Open();

                using (SqlDataReader reader = new SqlCommand(selectCommand, conn).ExecuteReader())
                {
                    if (reader.Read())
                    {
                        returnString = reader.ToString();
                    }
                }
            }
        }
        catch (Exception e)
        {
            DebugLogger.put_a_breakpoint_inside_this_function(e);
        }
        return returnString;
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
            DebugLogger.put_a_breakpoint_inside_this_function(e);
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
            DebugLogger.put_a_breakpoint_inside_this_function(e);
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
            DebugLogger.put_a_breakpoint_inside_this_function(e);
            return null;
        }
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

    public bool isUserAdmin(string currentUserID)
    {
        if (currentUserID == null || currentUserID == "")
            return false;

        User user = getUserById(currentUserID);
        return (user.getAttribute("is_admin") == "true");
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

    public string generateUniqueMealID()
    {
        List<Meal> meals = getListOfMeals();
        if (meals.Count > 0)
        {
            return (meals.Count + 10).ToString();
        }
        return "0";
    }
}