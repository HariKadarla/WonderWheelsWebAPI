using System;
using System.Collections.Generic;

#nullable disable

namespace WonderWheelsWebAPI.Model
{
    public partial class AuthorisedCustomerBookingDetail
    {
        public int TicketId { get; set; }
        public int CustomerId { get; set; }
        public int BusId { get; set; }
        public int RouteId { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public DateTime? DepartureDate { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public TimeSpan? ReturnDepartureTime { get; set; }
        public DateTime? ReturnDepartureDate { get; set; }
        public TimeSpan? ReturnArrivalTime { get; set; }
        public DateTime? ReturnArrivalDate { get; set; }
        public string TicketType { get; set; }
        public int? NoOfSeats { get; set; }
        public string SeatIds { get; set; }
        public int TotalPrice { get; set; }
        public int? DriverId { get; set; }
        public string TripStatus { get; set; }

        public virtual BusDetail Bus { get; set; }
        public virtual AuthorisedCustomerDetail Customer { get; set; }
        public virtual DriverDetail Driver { get; set; }
        public virtual Route Route { get; set; }
    }
}
