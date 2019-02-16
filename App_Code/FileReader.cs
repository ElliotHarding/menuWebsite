using System;
using System.Drawing;
using System.Xml;

public static class FileReader
{

    //Function to read a file into an array of strings (line by line)
    public static string[] readFile(string fileName)
    {
        try
        {
            string[] fileLines = System.IO.File.ReadAllLines(fileName);
            return fileLines;
        }
        catch(Exception e)
        {
            DebugLogger.put_a_breakpoint_inside_this_function(e);
            return new String[0];
        }     
    }

    public static  void SaveImage_NOT_IMPLEMENTED()
    {
       //todo
    }

    static class xml
    {
        public static string getSingleElementFromFile(string fileName, string element)
        {
            return getElementFromFile(fileName, element).InnerText;
        }

        public static XmlNode getElementFromFile(string fileName, string element)
        {
            if (!fileName.EndsWith(".xml"))
            {
                return null;
            }

            XmlDocument document = new XmlDocument();
            document.Load(fileName);

            return document.DocumentElement.SelectSingleNode(element);
        }
    }   
}