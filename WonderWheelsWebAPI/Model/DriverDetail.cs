using System;
using System.Collections.Generic;

#nullable disable

namespace WonderWheelsWebAPI.Model
{
    public partial class DriverDetail
    {
        public DriverDetail()
        {
            AuthorisedCustomerBookingDetails = new HashSet<AuthorisedCustomerBookingDetail>();
            BusDetails = new HashSet<BusDetail>();
            CoachResevationBusDetails = new HashSet<CoachResevationBusDetail>();
            UnauthorisedCustomerBookingDetails = new HashSet<UnauthorisedCustomerBookingDetail>();
        }

        public int DriverId { get; set; }
        public string Name { get; set; }
        public int? ContactNo { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }

        public virtual ICollection<AuthorisedCustomerBookingDetail> AuthorisedCustomerBookingDetails { get; set; }
        public virtual ICollection<BusDetail> BusDetails { get; set; }
        public virtual ICollection<CoachResevationBusDetail> CoachResevationBusDetails { get; set; }
        public virtual ICollection<UnauthorisedCustomerBookingDetail> UnauthorisedCustomerBookingDetails { get; set; }
    }
}
