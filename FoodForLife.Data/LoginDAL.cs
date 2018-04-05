using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodForLife.Data.Entity;

namespace FoodForLife.Data
{
    public class LoginDAL
    {


        public bool Authenticate(string username, string password)
        {
            using (var feedContext = new FeedforlifeEntities())
            {

                var Result = feedContext.tblusers.Where(u =>
                u.Email == "admin@feedforlife.com" && u.Password == "admin@123").FirstOrDefault();

                if (Result != null)
                    return true;
                else
                    return false;
            }
        }






    }
}
