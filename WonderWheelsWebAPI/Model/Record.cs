using System;
using System.Collections.Generic;

#nullable disable

namespace WonderWheelsWebAPI.Model
{
    public partial class Record
    {
        public int TravelId { get; set; }
        public DateTime TravelDate { get; set; }
        public TimeSpan TravelTime { get; set; }
        public int TotalBookedSeats { get; set; }
        public int RouteId { get; set; }
        public int ProfitPerTrip { get; set; }

        public virtual Route Route { get; set; }
    }
}
