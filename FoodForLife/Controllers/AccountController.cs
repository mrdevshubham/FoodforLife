using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FoodForLife.Business;
using FoodForLife.Model;

namespace FoodForLife.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        

        public ActionResult Home()
        {
            List<clsDonationDetails> lstDonationDetails = new List<clsDonationDetails>();
            lstDonationDetails = (new DonorBAL()).GetDonorBAL(0);
            return View(lstDonationDetails);
        }

    }
}