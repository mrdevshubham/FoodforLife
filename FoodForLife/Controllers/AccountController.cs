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
            if (RequestId > 0 && VendorId > 0)
            {
                bool Result = (new DonorBAL()).AssignVendorBAL(RequestId, VendorId, ref oResponse);
            }
            else
            {
                oResponse.Result = "Failure";
                oResponse.Message = "Oops! There is some problem with the page, Please try to reload the page and try again.";
            }
            return Json(new { oResponse });
        }




    }
}