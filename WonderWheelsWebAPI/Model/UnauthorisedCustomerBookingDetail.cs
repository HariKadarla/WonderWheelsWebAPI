using System;
using System.Collections.Generic;

#nullable disable

namespace WonderWheelsWebAPI.Model
{
    public partial class UnauthorisedCustomerBookingDetail
    {
        public int BookingId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public int RouteId { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public DateTime? DepartureDate { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public string TicketType { get; set; }
        public int NoOfSeats { get; set; }
        public int SeatIds { get; set; }
        public int TotalPrice { get; set; }
        public int? DriverId { get; set; }
        public string TripStatus { get; set; }

        public virtual DriverDetail Driver { get; set; }
        public virtual UnauthorisedCustomerDetail EmailNavigation { get; set; }
        public virtual Route Route { get; set; }
    }
}
