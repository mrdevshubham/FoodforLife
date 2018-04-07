using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodForLife.Data;
using FoodForLife.Model;

namespace FoodForLife.Business
{
    public class VendorBAL
    {

        public bool SaveVendorDetailsBAL(clsVendor oclsVendor)
        {
            return (new VendorDAL()).SaveVendorDetails(oclsVendor);
        }

        public List<clsVendor> GetVendorBAL(long Id)
        {
            return (new VendorDAL()).GetVendor(Id);
        }


    }
}
