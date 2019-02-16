using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public class TableAttributeList
{

    //-------------------------------- MEMBERS ----------------------------------------

    public TableAttributeList() { }
    protected List<TableAttribute> m_tableAttributes = new List<TableAttribute>();
    protected BackEnd backEnd = new BackEnd();
    public string m_tableName; 

    protected void fillFromReader(SqlDataReader reader)
    {
        foreach (TableAttribute attribute in m_tableAttributes)
        {
            attribute.value = reader[attribute.id].ToString();
        }
    }

    public List<TableAttribute> GetTableAttributes()
    {
        return m_tableAttributes;
    }

    public string getAttribute(string attributeID)
    {
        string returnAttribute = null;
        if(m_tableAttributes != null)
        {
            foreach (TableAttribute attribute in m_tableAttributes)
            {
                if (attribute.id == attributeID)
                {
                    return attribute.value;
                }
            }
        }        
        return returnAttribute;
    }

    public bool setAttributeValue(string attributeID, string value)
    {
        foreach (TableAttribute attribute in m_tableAttributes)
        {
            if (attribute.id == attributeID)
            {
                attribute.value = value;
                return true;
            }
        }

        DebugLogger.put_a_breakpoint_inside_this_function();
        return false;
    }

    //Returns true if action was successfull
    public bool insertIntoDatabase()
    {
        return backEnd._storage.RunCommand(insertCommand());
    }

    //Returns true if action was successfull
    public bool updateInDatabase()
    {
        return backEnd._storage.RunCommand(updateCommand());
    }

    //Returns true if action was successfull
    public bool deleteFromDatabase()
    {
        return backEnd._storage.RunCommand(deleteCommand());
    }

    private string insertCommand()
    {
        string IDs = "(";
        string values = "(";

        foreach (TableAttribute attribute in m_tableAttributes)
        {
            IDs += attribute.id + ",";
            values += "'" + attribute.value + "'" + ",";
        }

        //Get rid of last ','
        IDs = IDs.Substring(0, IDs.Length - 1);
        values = values.Substring(0, values.Length - 1);

        IDs += ")";
        values += ")";

        return "INSERT INTO " + m_tableName + IDs + " VALUES " + values + ";";
    }

    private string updateCommand()
    {
        string middle = "";

        foreach (TableAttribute attribute in m_tableAttributes)
        {
            middle += attribute.id + " = '" + attribute.value + "',";
        }

        middle = middle.Substring(0, middle.Length - 1);

        return "UPDATE " + m_tableName + " SET " + middle + " " + whereClause() + ";";
    }

    private string deleteCommand()
    {
        return "DELETE FROM " + m_tableName + " " + whereClause();
    }

    //Returns sql where statement which specifies the specific object
    private string whereClause()
    {
        return "WHERE id = '" + getAttribute("id") + "' ";
    }
}