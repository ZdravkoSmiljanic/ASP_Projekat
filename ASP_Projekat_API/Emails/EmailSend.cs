using ASP_Projekat_Application.Email;
using Castle.Core.Smtp;
using System.Net.Mail;

namespace ASP_Projekat_API.Emails
{
    public class EmailSend: IEmailSend
    {
 

        public void Send(MailMessages message)
        {
            System.Console.WriteLine("Sending email:");
            System.Console.WriteLine("To: " + message.To);
            System.Console.WriteLine("From: " + message.From);
            System.Console.WriteLine("Title: " + message.Title);
            System.Console.WriteLine("Body: " + message.Body);
        }
    }
}
