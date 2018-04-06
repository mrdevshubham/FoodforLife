using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodForLife.Model
{
    public class clsDonationDetails
    {

        public int DonorId { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string EmailId { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? AnniveraryDate { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public string EventAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public string PartyType { get; set; }
        public string FoodType { get; set; }
        public int TotalServingInvited { get; set; }
        public TimeSpan CollectionTime { get; set; }
        public int TotalServingLeft { get; set; }

        public string PrimaryAssignee { get; set; }
        public string SecondaryAssignee { get; set; }


        public bool Isactive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

    }
}
