using System;
using System.Collections.Generic;

#nullable disable

namespace WonderWheelsWebAPI.Model
{
    public partial class BusDetail
    {
        public BusDetail()
        {
            AuthorisedCustomerBookingDetails = new HashSet<AuthorisedCustomerBookingDetail>();
        }

        public int BusId { get; set; }
        public int RouteId { get; set; }
        public int? TotalSeats { get; set; }
        public int? FilledSeats { get; set; }
        public string Status { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public DateTime? DepartureDate { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public int? DriverId { get; set; }
        public string Seat1 { get; set; }
        public string Seat2 { get; set; }
        public string Seat3 { get; set; }
        public string Seat4 { get; set; }
        public string Seat5 { get; set; }
        public string Seat6 { get; set; }
        public string Seat7 { get; set; }
        public string Seat8 { get; set; }
        public string Seat9 { get; set; }
        public string Seat10 { get; set; }
        public string Seat11 { get; set; }
        public string Seat12 { get; set; }
        public string Seat13 { get; set; }
        public string Seat14 { get; set; }
        public string Seat15 { get; set; }
        public string Seat16 { get; set; }
        public string Seat17 { get; set; }
        public string Seat18 { get; set; }
        public string Seat19 { get; set; }
        public string Seat20 { get; set; }
        public string Seat21 { get; set; }
        public string Seat22 { get; set; }
        public string Seat23 { get; set; }
        public string Seat24 { get; set; }
        public string Seat25 { get; set; }
        public string Seat26 { get; set; }
        public string Seat27 { get; set; }
        public string Seat28 { get; set; }
        public string Seat29 { get; set; }
        public string Seat30 { get; set; }
        public string Seat31 { get; set; }
        public string Seat32 { get; set; }
        public string Seat33 { get; set; }
        public string Seat34 { get; set; }
        public string Seat35 { get; set; }
        public string Seat36 { get; set; }
        public string Seat37 { get; set; }
        public string Seat38 { get; set; }
        public string Seat39 { get; set; }
        public string Seat40 { get; set; }

        public virtual DriverDetail Driver { get; set; }
        public virtual Route Route { get; set; }
        public virtual ICollection<AuthorisedCustomerBookingDetail> AuthorisedCustomerBookingDetails { get; set; }
    }
}
