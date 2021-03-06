//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodForLife.Data.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblDonorRequest
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblDonorRequest()
        {
            this.tblDonorRequestVendors = new HashSet<tblDonorRequestVendor>();
            this.tblDonorRequestVendors1 = new HashSet<tblDonorRequestVendor>();
        }
    
        public long Id { get; set; }
        public string DonorName { get; set; }
        public string ContactNumber { get; set; }
        public string EmailId { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<System.DateTime> WeddingAnniversary { get; set; }
        public string EventName { get; set; }
        public System.DateTime EventDate { get; set; }
        public string EventAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PinCode { get; set; }
        public Nullable<long> PartyType { get; set; }
        public string FoodType { get; set; }
        public Nullable<int> TotalServingsInvited { get; set; }
        public System.TimeSpan CollectionTime { get; set; }
        public Nullable<int> TotalServingsLeft { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime Createddate { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string RequestStatus { get; set; }
        public long PrimaryAdminId { get; set; }
        public Nullable<long> SecondaryAdminId { get; set; }
    
        public virtual mtblPartyType mtblPartyType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDonorRequestVendor> tblDonorRequestVendors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblDonorRequestVendor> tblDonorRequestVendors1 { get; set; }
        public virtual tbluser tbluser { get; set; }
        public virtual tbluser tbluser1 { get; set; }
    }
}
