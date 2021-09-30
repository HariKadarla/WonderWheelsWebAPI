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
    public class AuthorisedCustomerBookingDetailsController : ControllerBase
    {
        private readonly BusReservationContext _context;

        public AuthorisedCustomerBookingDetailsController(BusReservationContext context)
        {
            _context = context;
        }

        // GET: api/AuthorisedCustomerBookingDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorisedCustomerBookingDetail>>> GetAuthorisedCustomerBookingDetails()
        {
            return await _context.AuthorisedCustomerBookingDetails.ToListAsync();
        }

        // GET: api/AuthorisedCustomerBookingDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorisedCustomerBookingDetail>> GetAuthorisedCustomerBookingDetail(int id)
        {
            var authorisedCustomerBookingDetail = await _context.AuthorisedCustomerBookingDetails.FindAsync(id);

            if (authorisedCustomerBookingDetail == null)
            {
                return NotFound();
            }

            return authorisedCustomerBookingDetail;
        }

        // PUT: api/AuthorisedCustomerBookingDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthorisedCustomerBookingDetail(int id, AuthorisedCustomerBookingDetail authorisedCustomerBookingDetail)
        {
            if (id != authorisedCustomerBookingDetail.TicketId)
            {
                return BadRequest();
            }

            _context.Entry(authorisedCustomerBookingDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorisedCustomerBookingDetailExists(id))
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

        // POST: api/AuthorisedCustomerBookingDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuthorisedCustomerBookingDetail>> PostAuthorisedCustomerBookingDetail(AuthorisedCustomerBookingDetail authorisedCustomerBookingDetail)
        {
            _context.AuthorisedCustomerBookingDetails.Add(authorisedCustomerBookingDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthorisedCustomerBookingDetail", new { id = authorisedCustomerBookingDetail.TicketId }, authorisedCustomerBookingDetail);
        }

        // DELETE: api/AuthorisedCustomerBookingDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorisedCustomerBookingDetail(int id)
        {
            var authorisedCustomerBookingDetail = await _context.AuthorisedCustomerBookingDetails.FindAsync(id);
            if (authorisedCustomerBookingDetail == null)
            {
                return NotFound();
            }

            _context.AuthorisedCustomerBookingDetails.Remove(authorisedCustomerBookingDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorisedCustomerBookingDetailExists(int id)
        {
            return _context.AuthorisedCustomerBookingDetails.Any(e => e.TicketId == id);
        }
    }
}
