using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net.Mail;
using System.Net;

namespace Store.Common
{
    public class SendMail
    {
        public void sendMail(string toEmail,string subject,string content)
        {
            var fromEmai = ConfigurationManager.AppSettings["FromEmail"].ToString();
            var emailDisplay = ConfigurationManager.AppSettings["EmailDisplay"].ToString();
            var fromEmailPwd = ConfigurationManager.AppSettings["FromEmailPwd"].ToString();
            var smtpHost = ConfigurationManager.AppSettings["SMTPHost"].ToString();
            var smtpPort = ConfigurationManager.AppSettings["SMTPPort"].ToString();

            bool enableSSL=bool.Parse(ConfigurationManager.AppSettings["EnableSSL"].ToString());

            string body = content;
            MailMessage mess=new MailMessage(new MailAddress(fromEmai,emailDisplay),new MailAddress(toEmail));
            mess.Body = body;
            mess.Subject = subject;
            mess.IsBodyHtml = true;

            var client= new SmtpClient();
            client.Credentials = new NetworkCredential(fromEmai, fromEmailPwd);
            client.EnableSsl = enableSSL;
            client.Host = smtpHost;
            client.Port = !string.IsNullOrEmpty(smtpPort) ? Convert.ToInt32(smtpPort) : 0;
            client.Send(mess);
        }
    }
}