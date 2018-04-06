using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodForLife.Data;
using FoodForLife.Model;


namespace FoodForLife.Business
{
    public class LoginBAL
    {


        public bool Authenticate(string Email, string Password, ref clsUser oclsuser)
        {
            return (new LoginDAL()).Authenticate(Email, Password, ref oclsuser);
        }



    }
}
