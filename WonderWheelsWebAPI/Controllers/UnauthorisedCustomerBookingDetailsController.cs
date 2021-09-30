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
    public class UnauthorisedCustomerBookingDetailsController : ControllerBase
    {
        private readonly BusReservationContext _context;

        public UnauthorisedCustomerBookingDetailsController(BusReservationContext context)
        {
            _context = context;
        }

        // GET: api/UnauthorisedCustomerBookingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnauthorisedCustomerBookingDetail>>> GetUnauthorisedCustomerBookingDetails()
        {
            return await _context.UnauthorisedCustomerBookingDetails.ToListAsync();
        }

        // GET: api/UnauthorisedCustomerBookingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnauthorisedCustomerBookingDetail>> GetUnauthorisedCustomerBookingDetail(int id)
        {
            var unauthorisedCustomerBookingDetail = await _context.UnauthorisedCustomerBookingDetails.FindAsync(id);

            if (unauthorisedCustomerBookingDetail == null)
            {
                return NotFound();
            }

            return unauthorisedCustomerBookingDetail;
        }

        // PUT: api/UnauthorisedCustomerBookingDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnauthorisedCustomerBookingDetail(int id, UnauthorisedCustomerBookingDetail unauthorisedCustomerBookingDetail)
        {
            if (id != unauthorisedCustomerBookingDetail.BookingId)
            {
                return BadRequest();
            }

            _context.Entry(unauthorisedCustomerBookingDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnauthorisedCustomerBookingDetailExists(id))
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

        // POST: api/UnauthorisedCustomerBookingDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnauthorisedCustomerBookingDetail>> PostUnauthorisedCustomerBookingDetail(UnauthorisedCustomerBookingDetail unauthorisedCustomerBookingDetail)
        {
            _context.UnauthorisedCustomerBookingDetails.Add(unauthorisedCustomerBookingDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnauthorisedCustomerBookingDetail", new { id = unauthorisedCustomerBookingDetail.BookingId }, unauthorisedCustomerBookingDetail);
        }

        // DELETE: api/UnauthorisedCustomerBookingDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnauthorisedCustomerBookingDetail(int id)
        {
            var unauthorisedCustomerBookingDetail = await _context.UnauthorisedCustomerBookingDetails.FindAsync(id);
            if (unauthorisedCustomerBookingDetail == null)
            {
                return NotFound();
            }

            _context.UnauthorisedCustomerBookingDetails.Remove(unauthorisedCustomerBookingDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnauthorisedCustomerBookingDetailExists(int id)
        {
            return _context.UnauthorisedCustomerBookingDetails.Any(e => e.BookingId == id);
        }
    }
}
