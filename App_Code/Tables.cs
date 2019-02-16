using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

public enum TableType
{
    MealTable,
    UserTable,
    OrderTable,
    NullTable //<-- keep this here
}

public class User : TableAttributeList
{
    private void SetTableInfo()
    {
        this.m_tableAttributes.Add(new TableAttribute("id"));//Primary key
        this.m_tableAttributes.Add(new TableAttribute("name"));
        this.m_tableAttributes.Add(new TableAttribute("password"));
        this.m_tableAttributes.Add(new TableAttribute("full_name"));
        this.m_tableAttributes.Add(new TableAttribute("address_line_1"));
        this.m_tableAttributes.Add(new TableAttribute("address_line_2"));
        this.m_tableAttributes.Add(new TableAttribute("address_city"));
        this.m_tableAttributes.Add(new TableAttribute("address_post_code"));
        this.m_tableAttributes.Add(new TableAttribute("address_description"));
        this.m_tableAttributes.Add(new TableAttribute("date_of_birth"));
        this.m_tableAttributes.Add(new TableAttribute("additional_info"));
        this.m_tableAttributes.Add(new TableAttribute("logged_in"));
        this.m_tableAttributes.Add(new TableAttribute("contact_email"));
        this.m_tableAttributes.Add(new TableAttribute("contact_phone"));
        this.m_tableAttributes.Add(new TableAttribute("rating"));
        //this.m_tableAttributes.Add(new TableAttribute("picture_id"));
        //this.m_tableAttributes.Add(new TableAttribute("is_admin"));

        m_tableName = "[User]";
    }

    public User()
    {
        SetTableInfo();
    }

    public User(SqlDataReader reader)
    {
        SetTableInfo();
        fillFromReader(reader);
    }
}

public class Meal : TableAttributeList
{
    private void SetTableInfo()
    {
        this.m_tableAttributes.Add(new TableAttribute("id"));//Primary key
        this.m_tableAttributes.Add(new TableAttribute("owner_user_id"));
        this.m_tableAttributes.Add(new TableAttribute("meal_name"));
        this.m_tableAttributes.Add(new TableAttribute("is_halal"));
        this.m_tableAttributes.Add(new TableAttribute("is_vegan"));
        this.m_tableAttributes.Add(new TableAttribute("is_vegiterian"));
        this.m_tableAttributes.Add(new TableAttribute("contains_milk"));
        this.m_tableAttributes.Add(new TableAttribute("contains_gluten"));
        this.m_tableAttributes.Add(new TableAttribute("ingredients_list"));
        this.m_tableAttributes.Add(new TableAttribute("estimated_calories"));
        this.m_tableAttributes.Add(new TableAttribute("picture_id"));
        this.m_tableAttributes.Add(new TableAttribute("price"));
        this.m_tableAttributes.Add(new TableAttribute("collection_time"));
        this.m_tableAttributes.Add(new TableAttribute("number_of_portions_avaliable"));

        m_tableName = "[Meal]";
    }

    public Meal()
    {
        SetTableInfo();
    }

    public Meal(SqlDataReader reader)
    {
        SetTableInfo();
        fillFromReader(reader);
    }
}

public class Order : TableAttributeList
{
    private void SetTableInfo()
    {
        this.m_tableAttributes.Add(new TableAttribute("id"));//Primary key
        this.m_tableAttributes.Add(new TableAttribute("meal_id"));
        this.m_tableAttributes.Add(new TableAttribute("meal_orderer_id"));
        this.m_tableAttributes.Add(new TableAttribute("num_portions_ordered"));
        this.m_tableAttributes.Add(new TableAttribute("active"));

        m_tableName = "[Order]";
    }

    public Order()
    {
        SetTableInfo();
    }

    public Order(SqlDataReader reader)
    {
        SetTableInfo();
        fillFromReader(reader);
    }
}

