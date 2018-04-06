using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodForLife.Model;
using FoodForLife.Data.Entity;

namespace FoodForLife.Data
{
    public class DonorDAL
    {

        public bool SaveDonorDetails(clsDonationDetails oclsDonationDetails)
        {
            try
            {
                using (var feedforlifeContext = new FeedforlifeEntities())
                {
                    tblDonorRequest otblDonorRequest = new tblDonorRequest();
                    otblDonorRequest.DonorName = oclsDonationDetails.Name;
                    otblDonorRequest.ContactNumber = oclsDonationDetails.ContactNumber;
                    otblDonorRequest.EmailId = oclsDonationDetails.EmailId;
                    otblDonorRequest.DOB = oclsDonationDetails.DateOfBirth;
                    otblDonorRequest.WeddingAnniversary = oclsDonationDetails.AnniveraryDate;
                    otblDonorRequest.EventName = oclsDonationDetails.EventName;
                    otblDonorRequest.EventDate = oclsDonationDetails.EventDate;
                    otblDonorRequest.EventAddress = oclsDonationDetails.EventAddress;
                    otblDonorRequest.City = oclsDonationDetails.City;
                    otblDonorRequest.State = oclsDonationDetails.State;
                    otblDonorRequest.PinCode = oclsDonationDetails.PinCode;
                    otblDonorRequest.PartyType = 101;
                    otblDonorRequest.FoodType = "";
                    otblDonorRequest.TotalServingsInvited = oclsDonationDetails.TotalServingInvited;
                    otblDonorRequest.CollectioTime = oclsDonationDetails.CollectionTime;
                    otblDonorRequest.TotalServingsLeft = oclsDonationDetails.TotalServingLeft;
                    otblDonorRequest.IsActive = oclsDonationDetails.Isactive;
                    otblDonorRequest.Createddate = oclsDonationDetails.CreatedDate;
                    otblDonorRequest.ModifiedDate = oclsDonationDetails.ModifiedDate;

                    feedforlifeContext.tblDonorRequests.Add(otblDonorRequest);
                    feedforlifeContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /*This method will get all the Donation Request, Based on 
         * Id it will decide whether to get details or list*/
        public List<clsDonationDetails> GetDonor(long Id)
        {
            try
            {
                using (var feedforlifeContext = new FeedforlifeEntities())
                {

                    var lstDonor = (from donor in feedforlifeContext.tblDonorRequests.Where(D => D.Id == (Id > 0 ? Id : D.Id))
                                    select new clsDonationDetails
                                    {

                                         Name = donor.DonorName,
                                         ContactNumber = donor.ContactNumber,
                                         EmailId = donor.EmailId,
                                         DateOfBirth = donor.DOB,
                                         AnniveraryDate = donor.WeddingAnniversary,
                                         EventName = donor.EventName,
                                         EventDate = donor.EventDate,
                                         EventAddress = donor.EventAddress,
                                         City = donor.City,
                                         State = donor.State,
                                         PinCode = donor.PinCode,
                                         PartyType = "",
                                         FoodType = "",
                                         TotalServingInvited = donor.TotalServingsInvited ?? 0,
                                         CollectionTime = donor.CollectioTime,
                                         TotalServingLeft = donor.TotalServingsLeft ?? 0,
                                         Isactive = donor.IsActive,
                                         CreatedDate = donor.Createddate,
                                         ModifiedDate = donor.ModifiedDate

                }).ToList() ?? (new List<clsDonationDetails>());

                    return lstDonor;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }




    }
}
