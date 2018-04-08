using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodForLife.Model;
using System.Net.Mail;
using System.Net;

namespace FoodForLife.Business
{
    public class Emailer
    {

        public bool SendEmailToDonorOnDonation(clsEmail oclsEmail)
        {
            try
            {
                string mailBodyhtml =
            "<p>Thanks for Donating.</p>";

                var msg = new MailMessage(oclsEmail.FromEmail, oclsEmail.ToEmail, "Hello", mailBodyhtml);

                msg.IsBodyHtml = true;
                var smtpClient = new SmtpClient(oclsEmail.Smtp, oclsEmail.Port);
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential(oclsEmail.Username, oclsEmail.password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(msg);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            

        }






    }
}
