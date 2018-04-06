using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodForLife.Data;

namespace FoodForLife.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

           

            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            bool Res = (new LoginDAL()).Authenticate(email, password);
            return Json( new { Result = "" } );
        }

        public ActionResult Donor()
        {
            return View();
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