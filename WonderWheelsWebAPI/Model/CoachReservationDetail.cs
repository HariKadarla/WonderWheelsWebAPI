using System;
using System.Collections.Generic;

#nullable disable

namespace WonderWheelsWebAPI.Model
{
    public partial class CoachReservationDetail
    {
        public int ReservationId { get; set; }
        public int CustomerId { get; set; }
        public string WithDriver { get; set; }
        public int? CoachBusId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public TimeSpan? DepartureTime { get; set; }
        public DateTime? DepartureDate { get; set; }
        public TimeSpan? ArrivalTime { get; set; }
        public DateTime? ArrivalDate { get; set; }
        public TimeSpan? ReturnDepartureTime { get; set; }
        public DateTime? ReturnDepartureDate { get; set; }
        public TimeSpan? ReturnArrivalTime { get; set; }
        public DateTime? ReturnArrivalDate { get; set; }
        public DateTime? OutDate { get; set; }
        public DateTime? InDate { get; set; }
        public int? Price { get; set; }
        public string SecurityDeposit { get; set; }
        public int? DepositAmount { get; set; }

        public virtual CoachResevationBusDetail CoachBus { get; set; }
        public virtual AuthorisedCustomerDetail Customer { get; set; }
    }
}
