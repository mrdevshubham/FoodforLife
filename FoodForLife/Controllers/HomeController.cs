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
        ResponseMessage oResponse = new ResponseMessage();

        public ActionResult Index()
        {
            //clsDonationDetails oclsDonationDetails = new clsDonationDetails();
            //oclsDonationDetails.Name = "Priya";
            //oclsDonationDetails.ContactNumber = "8985874784";
            //oclsDonationDetails.EmailId = "priya@sunlife.com";

            //oclsDonationDetails.DateOfBirth = DateTime.Now;
            //oclsDonationDetails.AnniveraryDate = DateTime.Now;
            //oclsDonationDetails.EventDate = DateTime.Now;

            //oclsDonationDetails.EventName = "Marriage";
            //oclsDonationDetails.EventAddress = "Address";
            //oclsDonationDetails.City = "BSW";
            //oclsDonationDetails.State = "UP";
            //oclsDonationDetails.PinCode = "243601";
            //oclsDonationDetails.PartyTypeId = 101;
            //oclsDonationDetails.FoodType = "VEG";
            //oclsDonationDetails.TotalServingInvited = 52;
            ////otblDonorRequest.CollectionTime = resultadoRetrasoIngresoAM;
            //oclsDonationDetails.TotalServingLeft = 5;


            //var isSuccess = (new DonorBAL()).SaveDonorDetailsBAL(oclsDonationDetails, ref oResponse);


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
                Session["user"] = oclsUser;
                if (IsValidUser)
                    return Json(new { Result = "Success" });
                else
                    return Json(new { Result = "Failure", Message = "The Email/Password combination is not correct." });
            }
        }

        public ActionResult Donor()
        {
            return View();
        }

        /*Section to save Donation Details*/
        [HttpPost]
        public ActionResult SaveDonation(clsDonationDetails oclsDonationDetails)
        {
            //oclsDonationDetails.EventName = "BirthDay";
            //oclsDonationDetails.State = "Haryana";

            var isSuccess = (new DonorBAL()).SaveDonorDetailsBAL(oclsDonationDetails, ref oResponse);
            if (isSuccess)
            {
                oResponse.Result = "Success";
                oResponse.Message = "Thank you for your contribution.";
                return Json(new { oResponse });
            }
            else
                return Json(new {oResponse});
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