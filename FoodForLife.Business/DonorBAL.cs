﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodForLife.Data;
using FoodForLife.Model;

namespace FoodForLife.Business
{
    public class DonorBAL
    {


        public bool SaveDonorDetailsBAL(clsDonationDetails oclsDonationDetails)
        {
            return (new DonorDAL()).SaveDonorDetails(oclsDonationDetails);
        }

        public List<clsDonationDetails> GetDonorBAL(string RequestStatus)
        {
            return (new DonorDAL()).GetDonor(RequestStatus);
        }

        public clsDonationDetails GetDonorDetailsBAL(long Id)
        {
            return (new DonorDAL()).GetDonorDetails(Id);
        }


    }
}
