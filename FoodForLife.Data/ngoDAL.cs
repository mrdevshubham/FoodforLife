using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodForLife.Model;
using FoodForLife.Data.Entity;

namespace FoodForLife.Data
{
    public class ngoDAL
    {

        public List<clsNGO> GetNGO(long Id)
        {
            try
            {
                using (var feedforlifeContext = new FeedforlifeEntities())
                {

                    var lstNGO = (from ngo in feedforlifeContext.tblNGOes.Where(ng => ng.IsActive == true)
                                  select new clsNGO
                                  {
                                      NGOId = ngo.Id,
                                      NGOName = ngo.NGOName,
                                      NGOAddress = ngo.NGOAddress,
                                      Phone = ngo.Phone,
                                      Email = ngo.Email,
                                      ContactPerson = ngo.ContactPerson,
                                      CreatedDate = ngo.CreatedDate,
                                      ModifiedDate = ngo.ModifiedDate
                                  }).ToList() ?? new List<clsNGO>();

                    return lstNGO;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
