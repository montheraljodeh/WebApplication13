using learn.core1.DTO;
using learn.core1.Repoisitory;
using learn.core1.service;
using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;

using System.Text;

namespace learn.infra1.service
{
    public class emailclass : IEmailservice
    {
        private readonly Iemp_apirepositiorycs emp;
        public emailclass(Iemp_apirepositiorycs emp)
        {
            this.emp = emp;
        }

        public string GetEmail(empverifiy e)
        {
            bool result = emp.checkemailisexist(e);
            if (result == false)
            {
                return "email is invalid";

            }
            else if (result == true)
            {
                Random rand = new Random();
                e.verficationcode =Convert.ToString( rand.Next(1000, 9999));
                emp.checkverify(e);
                MimeMessage message = new MimeMessage();
                BodyBuilder builder = new BodyBuilder();
                MailboxAddress from = new MailboxAddress("User", "newqroma@gmail.com");

                MailboxAddress to = new MailboxAddress("user", e.email);

                builder.HtmlBody = "<h1>"+e.verficationcode+"</h1>";

                message.Body = builder.ToMessageBody();
                message.From.Add(from);
                message.To.Add(to);
                message.Subject ="checking";
                using (var item = new SmtpClient())
                {
                    item.Connect("smtp.gmail.com", 587, false);
                    item.Authenticate("newqroma@gmail.com", "cfodqutfkmzlouut");
                    item.Send(message);
                    item.Disconnect(true);


                }

                return "true";     
            }
            return "true";
        }

    
    }
}
