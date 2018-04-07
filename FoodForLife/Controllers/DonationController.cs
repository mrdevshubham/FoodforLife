using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FoodForLife.Model;
using FoodForLife.Business;


namespace FoodForLife.Controllers
{
    public class DonationController : Controller
    {
        // GET: Donation
        public ActionResult List(string RequestStatus)
        {
            List<clsDonationDetails> lstDonationDetails = new List<clsDonationDetails>();
            lstDonationDetails = (new DonorBAL()).GetDonorBAL(RequestStatus);
            return View(lstDonationDetails);
        }


        public ActionResult DonationDetails(long Id)
        {
            clsDonationDetails oclsDonationDetails = new clsDonationDetails();
            oclsDonationDetails = (new DonorBAL()).GetDonorDetailsBAL(Id);
            return View(oclsDonationDetails);
        }

    }
}