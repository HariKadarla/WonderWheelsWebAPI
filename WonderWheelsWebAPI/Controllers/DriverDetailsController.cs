using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WonderWheelsWebAPI.Model;

namespace WonderWheelsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverDetailsController : ControllerBase
    {
        private readonly BusReservationContext _context;

        public DriverDetailsController(BusReservationContext context)
        {
            _context = context;
        }

        // GET: api/DriverDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DriverDetail>>> GetDriverDetails()
        {
            return await _context.DriverDetails.ToListAsync();
        }

        // GET: api/DriverDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DriverDetail>> GetDriverDetail(int id)
        {
            var driverDetail = await _context.DriverDetails.FindAsync(id);

            if (driverDetail == null)
            {
                return NotFound();
            }

            return driverDetail;
        }

        // PUT: api/DriverDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDriverDetail(int id, DriverDetail driverDetail)
        {
            if (id != driverDetail.DriverId)
            {
                return BadRequest();
            }

            _context.Entry(driverDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/DriverDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DriverDetail>> PostDriverDetail(DriverDetail driverDetail)
        {
            _context.DriverDetails.Add(driverDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDriverDetail", new { id = driverDetail.DriverId }, driverDetail);
        }

        // DELETE: api/DriverDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriverDetail(int id)
        {
            var driverDetail = await _context.DriverDetails.FindAsync(id);
            if (driverDetail == null)
            {
                return NotFound();
            }

            _context.DriverDetails.Remove(driverDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DriverDetailExists(int id)
        {
            return _context.DriverDetails.Any(e => e.DriverId == id);
        }
    }
}
