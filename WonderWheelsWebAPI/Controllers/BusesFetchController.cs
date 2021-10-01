using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Added...

using WonderWheelsWebAPI.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace WonderWheelsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusesFetchController : ControllerBase
    {
        public IConfiguration _configuration;

        private readonly BusReservationContext _context;

        public BusesFetchController(BusReservationContext context)
        {
            _context = context;
        }
        [HttpPost]

        public async Task<ActionResult<IEnumerable<BusDetail>>> Post(BusDetail _bus)
        {
            if (_bus != null && _bus.RouteId != 0 && _bus.DepartureDate != null)
            {
                List<BusDetail> buses = await _context.BusDetails.Where(b => b.RouteId == _bus.RouteId && b.DepartureDate == _bus.DepartureDate).ToListAsync();


                if (buses != null)
                {
                    return buses;
                }
                else
                {
                    return BadRequest("No Route Found");
                }
            }
            else
            {
                return BadRequest("Input Source and Destination");
            }
        }
        /*
        private async Task<List<BusDetail>> GetBuses(int routeid, DateTime? departuredate)
        {
             return  (List<BusDetail>) _context.BusDetails.ToList().Where(u => u.RouteId == routeid && u.DepartureDate == departuredate);
        } */
    }
}
