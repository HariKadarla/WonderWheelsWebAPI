using System;
using System.Collections.Generic;

#nullable disable

namespace WonderWheelsWebAPI.Model
{
    public partial class AuthorisedCustomerDetail
    {
        public AuthorisedCustomerDetail()
        {
            AuthorisedCustomerBookingDetails = new HashSet<AuthorisedCustomerBookingDetail>();
            CoachReservationDetails = new HashSet<CoachReservationDetail>();
        }

        public int CustomerId { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? ContactNo { get; set; }
        public string Gender { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int? Age { get; set; }
        public int? Wallet { get; set; }

        public virtual ICollection<AuthorisedCustomerBookingDetail> AuthorisedCustomerBookingDetails { get; set; }
        public virtual ICollection<CoachReservationDetail> CoachReservationDetails { get; set; }
    }
}
