using FoodForLife.Data;
using FoodForLife.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodForLife.Business
{
    public class ngoBAL
    {

        public List<clsNGO> GetNGOBAL(long Id)
        {
            return (new ngoDAL()).GetNGO(Id);
        }



    }
}
