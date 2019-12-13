using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace VehicleConfiguration.WPF.Helper
{
    public static class EmailHelper
    {
        public static void Mail(string sendMailAdress, string subject, string body)
        {
            SmtpClient client = new SmtpClient();
            MailAddress from = new MailAddress("arac.olustur@gmail.com");
            MailAddress to = new MailAddress("arac.olustur@gmail.com");//bizim mail adresi
            MailMessage msg = new MailMessage(from, to);
            msg.IsBodyHtml = true;
            msg.Subject = subject;
            msg.Body = body;
            msg.CC.Add(sendMailAdress);//herkes görür
            NetworkCredential info = new NetworkCredential("arac.olustur@gmail.com", "Arac.Olustur1");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Credentials = info;
            client.UseDefaultCredentials = true;
            client.Send(msg);

        }
    }
}
