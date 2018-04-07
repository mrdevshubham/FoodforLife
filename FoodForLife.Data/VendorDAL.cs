using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodForLife.Model;
using FoodForLife.Data.Entity;

namespace FoodForLife.Data
{
    public class VendorDAL
    {

        public bool SaveVendorDetails(clsVendor oclsVendor)
        {
            using (var FeedForLifeContext = new FeedforlifeEntities())
            {

                tblVendor otblVendor = new tblVendor();
                otblVendor.VendorName = oclsVendor.VendorName;
                otblVendor.Phone = oclsVendor.VendorName;

                otblVendor.Email = oclsVendor.Email;
                otblVendor.Address_Primary = oclsVendor.Address_Primary;
                otblVendor.Address_Secondary = oclsVendor.Address_Secondary;
                otblVendor.IsActive = true;
                otblVendor.Createddate = DateTime.Now;
                otblVendor.ModifiedDate = DateTime.Now;
            }
            return true;
        }


        public List<clsVendor> GetVendor(long Id)
        {

            using (var FeedForLifeContext = new FeedforlifeEntities())
            {
                var lstVendor = (from vendor in FeedForLifeContext.tblVendors.Where(V => V.Id == (Id > 0 ? Id : V.Id))
                                 select new clsVendor
                                 {
                                     Id = vendor.Id,
                                     VendorName = vendor.VendorName,
                                     Phone = vendor.Phone,
                                     Email = vendor.Email,
                                     Address_Primary = vendor.Address_Primary,
                                     Address_Secondary = vendor.Address_Secondary,
                                     Isactive = vendor.IsActive,
                                     CreatedDate = vendor.Createddate,
                                     ModifiedDate = vendor.ModifiedDate
                                 }).ToList() ?? (new List<clsVendor>());

                return lstVendor;

            }


            








        }



    }
}
