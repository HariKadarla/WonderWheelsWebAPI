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
    public class RouteFetchController : ControllerBase
    {
        public IConfiguration _configuration;

        private readonly BusReservationContext _context;

        public RouteFetchController(BusReservationContext context)
        {
            _context = context;
        }
        [HttpPost]

        public async Task<ActionResult<Route>> Post(Route _route)
        {
            if (_route != null && _route.Source != null && _route.Destination != null)
            {
                Route routeDetails = await GetRoute(_route.Source, _route.Destination);

                if (routeDetails != null)
                {
                    return routeDetails;
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
        private async Task<Route> GetRoute(string source, string destination)
        {
            return await _context.Routes.FirstOrDefaultAsync(u => u.Source == source && u.Destination == destination);
        }
    }
}
