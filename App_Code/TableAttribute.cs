using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class TableAttribute
{
    public String id;
    public String value;
    public TableAttribute(String id_)
    {
        id = id_;
    }
    public TableAttribute(string id_, string value_)
    {
        id = id_;
        value = value_;
    }
}