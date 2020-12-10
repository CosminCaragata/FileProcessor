using System;
using System.Net;
using System.Net.Mail;

namespace _2FAProject
{
    public class MailService
    {

        public static void Send2faMail(string toMail, string pin)
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("test2fa314@gmail.com");
                message.To.Add(new MailAddress(toMail));
                message.Subject = "Pin number";                
                message.Body = "Your pin is " + pin;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("test2fa314@gmail.com", "cosmin1234");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.Send(message);
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }

        }

    }
}
