using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodForLife.Data.Entity;
using FoodForLife.Model;

namespace FoodForLife.Data
{
    public class LoginDAL
    {


        public bool Authenticate(string username, string password, ref clsUser oclsuser)
        {
            using (var feedContext = new FeedforlifeEntities())
            {
                var Result = feedContext.tblusers.Where(u =>
                u.Email == username && u.Password == password && u.IsActive == true).FirstOrDefault();

                if (Result != null)
                {
                    clsUser oclsUser = new clsUser();
                    oclsUser.Id = Result.Id;
                    oclsUser.Email = Result.Email;
                    oclsUser.FirstName = Result.Firstname;
                    oclsUser.Phone = Result.Phone;
                    return true;
                }
                else
                    return false;
            }
        }






    }
}
