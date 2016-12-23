using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace News.Business.Components.Managers
{
    public class Mailer
    {
        SmtpClient sc = new SmtpClient("localhost", 50350);

        public static Mailer Current
        { get { return new Mailer(); } }

        public virtual bool SendMessage()
        {
            try
            {
                var msg = new MailMessage();
                msg.From = new MailAddress("02bodia20@ukr.net");
                msg.To.Add("b.semenets@sana-commerce.com");
                msg.Subject = "Message from News System";
                msg.Body = "This email sent by the News system";
                msg.IsBodyHtml = true;

                //sc.Send(msg);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
