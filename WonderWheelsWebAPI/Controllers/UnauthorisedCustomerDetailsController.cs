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
    public class UnauthorisedCustomerDetailsController : ControllerBase
    {
        private readonly BusReservationContext _context;

        public UnauthorisedCustomerDetailsController(BusReservationContext context)
        {
            _context = context;
        }

        // GET: api/UnauthorisedCustomerDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnauthorisedCustomerDetail>>> GetUnauthorisedCustomerDetails()
        {
            return await _context.UnauthorisedCustomerDetails.ToListAsync();
        }

        // GET: api/UnauthorisedCustomerDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnauthorisedCustomerDetail>> GetUnauthorisedCustomerDetail(string id)
        {
            var unauthorisedCustomerDetail = await _context.UnauthorisedCustomerDetails.FindAsync(id);

            if (unauthorisedCustomerDetail == null)
            {
                return NotFound();
            }

            return unauthorisedCustomerDetail;
        }

        // PUT: api/UnauthorisedCustomerDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnauthorisedCustomerDetail(string id, UnauthorisedCustomerDetail unauthorisedCustomerDetail)
        {
            if (id != unauthorisedCustomerDetail.Email)
            {
                return BadRequest();
            }

            _context.Entry(unauthorisedCustomerDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnauthorisedCustomerDetailExists(id))
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

        // POST: api/UnauthorisedCustomerDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnauthorisedCustomerDetail>> PostUnauthorisedCustomerDetail(UnauthorisedCustomerDetail unauthorisedCustomerDetail)
        {
            _context.UnauthorisedCustomerDetails.Add(unauthorisedCustomerDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UnauthorisedCustomerDetailExists(unauthorisedCustomerDetail.Email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUnauthorisedCustomerDetail", new { id = unauthorisedCustomerDetail.Email }, unauthorisedCustomerDetail);
        }

        // DELETE: api/UnauthorisedCustomerDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnauthorisedCustomerDetail(string id)
        {
            var unauthorisedCustomerDetail = await _context.UnauthorisedCustomerDetails.FindAsync(id);
            if (unauthorisedCustomerDetail == null)
            {
                return NotFound();
            }

            _context.UnauthorisedCustomerDetails.Remove(unauthorisedCustomerDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnauthorisedCustomerDetailExists(string id)
        {
            return _context.UnauthorisedCustomerDetails.Any(e => e.Email == id);
        }
    }
}
