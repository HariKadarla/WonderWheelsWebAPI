using System;
using System.Collections.Generic;

#nullable disable

namespace WonderWheelsWebAPI.Model
{
    public partial class Route
    {
        public Route()
        {
            AuthorisedCustomerBookingDetails = new HashSet<AuthorisedCustomerBookingDetail>();
            BusDetails = new HashSet<BusDetail>();
            Records = new HashSet<Record>();
            UnauthorisedCustomerBookingDetails = new HashSet<UnauthorisedCustomerBookingDetail>();
        }

        public int RouteId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int JourneyTime { get; set; }
        public int TicketPrice { get; set; }
        public int InvestmentPerTrip { get; set; }
        public int SeatFullProfit { get; set; }

        public virtual ICollection<AuthorisedCustomerBookingDetail> AuthorisedCustomerBookingDetails { get; set; }
        public virtual ICollection<BusDetail> BusDetails { get; set; }
        public virtual ICollection<Record> Records { get; set; }
        public virtual ICollection<UnauthorisedCustomerBookingDetail> UnauthorisedCustomerBookingDetails { get; set; }
    }
}
