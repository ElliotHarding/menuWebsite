using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

public class HelpfullFunctions
{
   
    //Sends text to a validated email
    public bool sendEmail(string email, string subject, string[] body)
    {
        return true;

        ////todo get sender email (should be like company email)
        //const string emailSender = "";

        //MailMessage mail = new MailMessage(emailSender, email);
        //SmtpClient client = new SmtpClient();
        //client.Port = 25;
        //client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //client.UseDefaultCredentials = false;
        //client.Host = "smtp.gmail.com";
        //mail.Subject = subject;
        //mail.Body = body;

        //try
        //{
        //    client.Send(mail);
        //    return true;
        //}
        //catch (Exception e)
        //{
        //    DebugLogger.logError(e, "Sending email to client");
        //    return false;
        //}
    }

    public bool sendVerificationEmail(TableAttributeList user)
    {
        string[] emailBody = FileReader.readFile("verifyEmail.txt");

        emailBody.ToList<string>().Add("\n");
        emailBody.ToList<string>().Add(generateVerificationLink(user));

        return sendEmail(user.getAttribute("email"), "Verify email", emailBody);
    }

    public bool sendAccountResetEmail(string email)
    {
        if (email == null) return false;

        //todo get user account acociated with email
        User user = new User();
        try
        {
            user = new Storage().getListOfUsers("SELECT * FROM USER WHERE contact_email = '" + email + "';")[0];
        }
        catch(Exception e)
        {
            return false;
        }
      

        return sendEmail(user.getAttribute("email"), "Verify email", generateRestEmailText(user));
    }

    //Function that generates the text sent via email
    //to the client whom whishes to have their account password reset
    private string[] generateRestEmailText(TableAttributeList user)
    {
        string[] returnString = { "This text gets sent to the email as a reset email.", "" };

        //todo

        return returnString;
    }

    private string generateVerificationLink(TableAttributeList user)
    {
        //todo on security update cant just use id, maybe hash function?
        return Globals.websiteURL + "/$verify=" + user.getAttribute("id");
    }
}