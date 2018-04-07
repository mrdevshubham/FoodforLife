using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodForLife.Model
{
    public class HomeModel
    {
        public HomeModel()
        {
            this.lstDonationDetails = new List<clsDonationDetails>();
            this.lstVendors = new List<clsVendor>();
        }

        public List<clsDonationDetails> lstDonationDetails { get; set; }
        public List<clsVendor> lstVendors { get; set; }
    }
}
