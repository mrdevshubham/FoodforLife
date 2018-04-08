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
                oclsEmail.Subject = "Feed4Life : Thanks For Donation!";
                oclsEmail.Body = @"Hi Donor,<br/>
                Thank you so much for submitting your details on Feed4Life portal to donate the leftover food from your celebration.<br/>
                One of our admin member will contact you soon to finalize the logistic details.<br/>
                Thank you again. Your contribution to the society counts.<br/><br/>
                Regards<br/>
                Feed4Life family
                ";
                return SendMail(oclsEmail);
            }
            catch (Exception ex)
            {
                return false;
            }
            

        }


        public bool SendEmailToAdminOnDonationReceiving(clsEmail oclsEmail)
        {
            try
            {
                oclsEmail.Subject = "Feed4Life : New Donation Received!";
                oclsEmail.Body = @"Hi Admin,<br/>
                A new request has been assigned to you. Please login into Feed4Life portal to view it.<br/><br/>
                Regards<br/>
                Feed4Life family
                ";
                return SendMail(oclsEmail);
            }
            catch (Exception ex)
            {
                return false;
            }


        }


        public bool SendMail(clsEmail oclsEmail)
        {
            string mailBodyhtml =
            oclsEmail.Body;
            var msg = new MailMessage(oclsEmail.FromEmail, oclsEmail.ToEmail, oclsEmail.Subject, mailBodyhtml);

            msg.IsBodyHtml = true;
            var smtpClient = new SmtpClient(oclsEmail.Smtp, oclsEmail.Port);
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new NetworkCredential(oclsEmail.Username, oclsEmail.password);
            smtpClient.EnableSsl = true;
            smtpClient.Send(msg);
            return true;
        }






    }
}
