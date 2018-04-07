﻿using System;
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
                        otblDonorRequest.PartyType = oclsDonationDetails.PartyTypeId;
                        otblDonorRequest.FoodType = "";
                        otblDonorRequest.TotalServingsInvited = oclsDonationDetails.TotalServingInvited;
                        otblDonorRequest.CollectionTime = oclsDonationDetails.CollectionTime;
                        otblDonorRequest.TotalServingsLeft = oclsDonationDetails.TotalServingLeft;
                        otblDonorRequest.IsActive = oclsDonationDetails.Isactive;
                        otblDonorRequest.Createddate = oclsDonationDetails.CreatedDate;
                        otblDonorRequest.ModifiedDate = oclsDonationDetails.ModifiedDate;

                        otblDonorRequest.PrimaryAdminId = oPinCode.AdminId;

                        feedforlifeContext.tblDonorRequests.Add(otblDonorRequest);
                        feedforlifeContext.SaveChanges();
                    }
                    else
                    {
                        oResponse.ResponseCode = 0;
                        oResponse.Result = "Failure";
                        oResponse.Message = "Oops! Currently we do not server at these pin codes.";
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




    }
}
