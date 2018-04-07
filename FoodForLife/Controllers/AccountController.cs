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

        ResponseMessage oResponse = new ResponseMessage();

        public ActionResult Home(string Id)
        {
            if (Id == RequestStatus.NEW || Id == RequestStatus.PENDING || Id == RequestStatus.COMPLETED)
            {
                ViewBag.RequestStatus = Id;
                HomeModel oHomeModel = new HomeModel();
                oHomeModel.lstDonationDetails = (new DonorBAL()).GetDonorBAL(Id);
                oHomeModel.lstVendors = (new VendorBAL().GetVendorBAL(0));
                return View(oHomeModel);
            }
            else
            {
                return RedirectToAction("Home",new { Id = RequestStatus.NEW });
            }
        }


        public ActionResult AssignVendor(long RequestId, long VendorId)
        {
            oResponse.Result = "Success";
            oResponse.Message = "Vendor assigned successfully.";
            return Json(new { oResponse });

        }




    }
}