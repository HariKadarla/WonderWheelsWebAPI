using System;
using System.Collections.Generic;

#nullable disable

namespace WonderWheelsWebAPI.Model
{
    public partial class CoachResevationBusDetail
    {
        public CoachResevationBusDetail()
        {
            CoachReservationDetails = new HashSet<CoachReservationDetail>();
        }

        public int CoachBusId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public int TotalSeats { get; set; }
        public string Status { get; set; }
        public int? DriverId { get; set; }

        public virtual DriverDetail Driver { get; set; }
        public virtual ICollection<CoachReservationDetail> CoachReservationDetails { get; set; }
    }
}
