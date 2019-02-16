using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public static class DebugLogger
{
    static int x = 0;

    public static void put_a_breakpoint_inside_this_function()
    {
        /*Stick a break point in this function and whenever a error occurs,
        this should be called :) */
        x++;
    }

    public static void put_a_breakpoint_inside_this_function(Exception e)
    {
        /*Stick a break point in this function and whenever a error occurs,
        this should be called :) */
        x++;
    }
}