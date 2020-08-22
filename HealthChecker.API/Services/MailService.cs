using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HealthChecker.API.Services
{
    public class MailService
    {
        private static string username = "xxx@xxx.com";
        private static string password = "password";
        private static string from = "xxx@xxx.com";


        public static void SendMail(string toMail, string subject, string body)
        {
            ///Send from local directory
            //var client = new SmtpClient
            //{
            //    DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
            //    PickupDirectoryLocation = @"c:\myMailFolder"
            //};

            var message = new MailMessage();
            message.To.Add(new MailAddress(toMail));
            message.From = new MailAddress(from);
            message.Subject = subject;
            message.Body = body;
            message.IsBodyHtml = true;
            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = username,
                    Password = password
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
        }
    }
}
