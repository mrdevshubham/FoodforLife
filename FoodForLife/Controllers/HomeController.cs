using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodForLife.Business;
using FoodForLife.Model;
using System.Web.Security;

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
    }
}