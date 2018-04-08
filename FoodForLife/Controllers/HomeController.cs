using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodForLife.Business;
using FoodForLife.Model;
using System.Web.Security;
using System.Configuration;

namespace FoodForLife.Controllers
{
    public class HomeController : Controller
    {
        ResponseMessage oResponse = new ResponseMessage();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return Json(new { Result = "Failure", Message = "Either Email or Password field is blank, Please fill all the details." });
            else
            {
                clsUser oclsUser = new clsUser();
                bool IsValidUser = (new LoginBAL()).Authenticate(email, password, ref oclsUser);
                FormsAuthentication.SetAuthCookie(oclsUser.Email, false);
                Session["UserInfo"] = oclsUser;
                if (IsValidUser)
                    return Json(new { Result = "Success" });
                else
                    return Json(new { Result = "Failure", Message = "The Email/Password combination is not correct." });
            }
        }

        public ActionResult SignOut()
        {
            FormsAuthentication.SetAuthCookie("Email", false);
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }

        public ActionResult Donor()
        {
            return View();
        }

        /*Section to save Donation Details*/
        [HttpPost]
        public ActionResult SaveDonation(clsDonationDetails oclsDonationDetails)
        {
            var isSuccess = (new DonorBAL()).SaveDonorDetailsBAL(oclsDonationDetails, ref oResponse);
            if (isSuccess)
            {
                clsEmail oclsEmail = GetEmailSettings();
                oclsEmail.ToEmail = oclsDonationDetails.EmailId;

                bool isMailsent = (new Emailer()).SendEmailToDonorOnDonation(oclsEmail);

                oclsEmail.ToEmail = oclsEmail.AdminEmail;
                bool isMailsenttoadmin = (new Emailer()).SendEmailToAdminOnDonationReceiving(oclsEmail);

                ViewBag.Code = 1;
                ViewBag.Message = "Your request has been saved successfully, Thank you for your contribution.";
                return View("~/Views/Home/Donor.cshtml");
            }
            else
            {
                ViewBag.Code = 0;
                ViewBag.Message = oResponse.Message;
                return View("~/Views/Home/Donor.cshtml");
            }
        }


        public ActionResult Admin()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }


        public clsEmail GetEmailSettings()
        {
            clsEmail oclsemail = new clsEmail();
            oclsemail.Smtp = Convert.ToString(ConfigurationManager.AppSettings["smtp"]);
            oclsemail.Port = Convert.ToInt32(ConfigurationManager.AppSettings["port"]);
            oclsemail.Username = Convert.ToString(ConfigurationManager.AppSettings["username"]);
            oclsemail.password = Convert.ToString(ConfigurationManager.AppSettings["password"]);
            oclsemail.FromEmail = Convert.ToString(ConfigurationManager.AppSettings["from"]);
            oclsemail.AdminEmail = Convert.ToString(ConfigurationManager.AppSettings["adminemail"]);
            oclsemail.EnableSSL = Convert.ToBoolean(ConfigurationManager.AppSettings["enablessl"]);

            return oclsemail;
        }



    }
}