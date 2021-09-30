using System;
using System.Collections.Generic;

#nullable disable

namespace WonderWheelsWebAPI.Model
{
    public partial class UnauthorisedCustomerDetail
    {
        public UnauthorisedCustomerDetail()
        {
            UnauthorisedCustomerBookingDetails = new HashSet<UnauthorisedCustomerBookingDetail>();
        }

        public string Email { get; set; }
        public int ContactNo { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UnauthorisedCustomerBookingDetail> UnauthorisedCustomerBookingDetails { get; set; }
    }
}
