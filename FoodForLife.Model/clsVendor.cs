using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodForLife.Model
{
    public class clsVendor
    {
        public long Id { get; set; }
        public string VendorName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address_Primary { get; set; }
        public string Address_Secondary { get; set; }
        public bool Isactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
