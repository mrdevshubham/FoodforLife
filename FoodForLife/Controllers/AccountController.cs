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
        

        public ActionResult Home(string Id)
        {
            if (Id == RequestStatus.NEW || Id == RequestStatus.PENDING || Id == RequestStatus.COMPLETED)
            {
                ViewBag.RequestStatus = Id;
                List<clsDonationDetails> lstDonationDetails = new List<clsDonationDetails>();
                lstDonationDetails = (new DonorBAL()).GetDonorBAL(Id);
                return View(lstDonationDetails);
            }
            else
            {
                return RedirectToAction("Home",new { Id = RequestStatus.NEW });
            }
        }

    }
}