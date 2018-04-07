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

        public bool SaveDonorDetails(clsDonationDetails oclsDonationDetails, ref ResponseMessage oResponse)
        {
            try
            {
                using (var feedforlifeContext = new FeedforlifeEntities())
                {
                    var oPinCode = feedforlifeContext.tblAdminTerritories.Where(Ter => Ter.AssignedPinCodes.Contains(oclsDonationDetails.PinCode)).FirstOrDefault();
                    if (oPinCode != null)
                    {

                        TimeSpan resultadoRetrasoIngresoAM = new TimeSpan(oclsDonationDetails.CollectionTime.Days, oclsDonationDetails.CollectionTime.Minutes, oclsDonationDetails.CollectionTime.Milliseconds);

                        feedforlifeContext.USP_SaveDonationDetails(oclsDonationDetails.Name, oclsDonationDetails.ContactNumber, oclsDonationDetails.EmailId, oclsDonationDetails.DateOfBirth, oclsDonationDetails.AnniveraryDate
                            , oclsDonationDetails.EventName, oclsDonationDetails.EventDate, oclsDonationDetails.EventAddress, oclsDonationDetails.City, oclsDonationDetails.State
                            , oclsDonationDetails.PinCode, oclsDonationDetails.PartyTypeId, oclsDonationDetails.FoodType, oclsDonationDetails.TotalServingInvited, resultadoRetrasoIngresoAM, oclsDonationDetails.TotalServingLeft, RequestStatus.NEW, oPinCode.AdminId);
                    }
                    else
                    {
                        oResponse.ResponseCode = 0;
                        oResponse.Result = "Failure";
                        oResponse.Message = "Oops! Currently we do not serve at these pin codes.";
                        return false;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                oResponse.ResponseCode = 0;
                oResponse.Result = "Failure";
                oResponse.Message = "There was some exception, while contacting Database. Please try again.";
                return false;
            }
        }

        public List<clsDonationDetails> GetDonor(string RequestStatus)
        {
            try
            {
                using (var feedforlifeContext = new FeedforlifeEntities())
                {

                    var lstDonor = (from donor in feedforlifeContext.tblDonorRequests.Where(D => D.RequestStatus == RequestStatus)
                                    join DType in feedforlifeContext.mtblPartyTypes on donor.PartyType equals DType.Id
                                    select new clsDonationDetails
                                  {
                                      DonorId = donor.Id,
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
                                      CollectionTime = donor.CollectionTime,
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


        /*This method will get all the Donation Request, Based on 
         * Id it will decide whether to get details or list*/
        public clsDonationDetails GetDonorDetails(long Id)
        {
            try
            {
                using (var feedforlifeContext = new FeedforlifeEntities())
                {

                    var oDonor = (from donor in feedforlifeContext.tblDonorRequests.Where(D => D.Id == Id && D.IsActive == true)
                                  join DType in feedforlifeContext.mtblPartyTypes on donor.PartyType equals DType.Id
                                    select new clsDonationDetails
                                    {
                                        DonorId = donor.Id,
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
                                         PartyType = DType.TypeName,
                                         FoodType = donor.FoodType,
                                         TotalServingInvited = donor.TotalServingsInvited ?? 0,
                                         CollectionTime = donor.CollectionTime,
                                         TotalServingLeft = donor.TotalServingsLeft ?? 0,
                                         Isactive = donor.IsActive,
                                         CreatedDate = donor.Createddate,
                                         ModifiedDate = donor.ModifiedDate,

                                         RequestStatus = donor.RequestStatus

                }).FirstOrDefault() ?? (new clsDonationDetails());

                    return oDonor;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public bool AssignVendorDAL(long RequestId, long VendorId, ref ResponseMessage oResponse)
        {
            try
            {
                using (var feedforlifeContext = new FeedforlifeEntities())
                {
                    tblDonorRequestVendor OtblDonorRequestVendor = new tblDonorRequestVendor();
                    OtblDonorRequestVendor.RequestId = RequestId;
                    OtblDonorRequestVendor.VendorId = VendorId;
                    feedforlifeContext.tblDonorRequestVendors.Add(OtblDonorRequestVendor);
                    feedforlifeContext.SaveChanges();

                    oResponse.ResponseCode = 1;
                    oResponse.Result = "Success";
                    oResponse.Message = "Successfully Assigned vendor to the Donor Request.";

                    return true;
                }
            }
            catch (Exception ex)
            {
                oResponse.ResponseCode = 0;
                oResponse.Result = "Failure";
                oResponse.Message = "Failed to connect to Database, Please try again.";
                return false;
            }
            
        }


    }
}
