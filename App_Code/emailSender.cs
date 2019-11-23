using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Web;
using System.Web.Configuration;
using System.Net.Configuration;

/// <summary>
/// Summary description for emailSender
/// </summary>
public class emailSender
{
    string emailId = WebConfigurationManager.AppSettings["userName"];
    string emails;
    public emailSender()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //public static void sendEmail()
    //{
    //    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
    //    smtpClient.Credentials = new System.Net.NetworkCredential("soalatise@softcodes.com.ng", "dice@465$10m");
    //    smtpClient.UseDefaultCredentials = true;
    //    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
    //    smtpClient.EnableSsl = true;
    //    MailMessage mail = new MailMessage();

    //    //Setting From , To and CC
    //    mail.From = new MailAddress("soalatise@softcodes.com.ng", "MyWeb Site");
    //    mail.To.Add(new MailAddress("drexyno@gmail.com"));
    //    mail.CC.Add(new MailAddress("simones_001@hotmail.com"));
    //    smtpClient.Send(mail);


    //}
    
    public static void SendEmail(string subject,string messages, string senderemail,string password)
    {
        try
        {
            string strHostName = GetServerIP();
            MailMessage msg = new MailMessage(senderemail, password);
            msg.Subject = subject;
            msg.Body = messages;
            SmtpClient smClient = new SmtpClient();
            smClient.Send(msg);
        }
        catch (Exception ex)
        {

        }
    }
    public static void SendEmail(string messages)
    {
        try
        {
            string strHostName = GetServerIP();
            MailMessage msg = new MailMessage("soalatise@softcodes.com.ng", "eaorhokpe@softcodes.com.ng");
            msg.Subject = "API Upload Error Message";
            msg.Body = messages;
            SmtpClient smClient = new SmtpClient();
            smClient.Send(msg);
        }
        catch (Exception ex)
        {

        }
    }
    //Finish this And ewe are fine.
    public static void ReceiveEmail(string messages,string sender,string receiver,string subject)
    {
        try
        {
            string strHostName = GetServerIP();
            MailMessage msg = new MailMessage(sender, receiver);
            msg.Subject = subject;
            msg.Body = messages;
            SmtpClient smClient = new SmtpClient();
            smClient.Send(msg);
        }
        catch (Exception ex)
        {

        }
    }
    public static string GetServerIP()
    {
        try
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress address in ipHostInfo.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    return address.ToString();
            }
        }
        catch (Exception ex)
        {


        }
        return string.Empty;
    }
    public static void SendEmails(string messages,string fromemail,string toemail)
    {
        try
        {
            string strHostName = GetServerIP();
            MailMessage msg = new MailMessage(fromemail, toemail);
            msg.Subject = "API Upload Error Message";
            msg.Body = messages;
            SmtpClient smClient = new SmtpClient();
            smClient.Send(msg);
        }
        catch (Exception ex)
        {

        }
    }
}