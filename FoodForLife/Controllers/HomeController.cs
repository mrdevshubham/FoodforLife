using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodForLife.Business;
using FoodForLife.Model;

namespace FoodForLife.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string email, string password)
        {
            if (!string.IsNullOrEmpty(email) || !string.IsNullOrEmpty(password))
                return Json(new { Result = "Failure", Message = "Either Email or Password field is blank, Please fill all the details." });
            else
            {
                clsUser oclsUser = new clsUser();
                bool IsValidUser = (new LoginBAL()).Authenticate(email, password, ref oclsUser);
                Session["user"] = oclsUser;
                if (IsValidUser)
                    return Json(new { Result = "Success" });
                else
                    return Json(new { Result = "Failure", Message = "The Email/Password combination is not correct." });
            }
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