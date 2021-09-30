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
    public class AuthorisedCustomerDetailsController : ControllerBase
    {
        private readonly BusReservationContext _context;

        public AuthorisedCustomerDetailsController(BusReservationContext context)
        {
            _context = context;
        }

        // GET: api/AuthorisedCustomerDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorisedCustomerDetail>>> GetAuthorisedCustomerDetails()
        {
            return await _context.AuthorisedCustomerDetails.ToListAsync();
        }

        // GET: api/AuthorisedCustomerDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorisedCustomerDetail>> GetAuthorisedCustomerDetail(int id)
        {
            var authorisedCustomerDetail = await _context.AuthorisedCustomerDetails.FindAsync(id);

            if (authorisedCustomerDetail == null)
            {
                return NotFound();
            }

            return authorisedCustomerDetail;
        }

        // PUT: api/AuthorisedCustomerDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthorisedCustomerDetail(int id, AuthorisedCustomerDetail authorisedCustomerDetail)
        {
            if (id != authorisedCustomerDetail.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(authorisedCustomerDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorisedCustomerDetailExists(id))
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

        // POST: api/AuthorisedCustomerDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AuthorisedCustomerDetail>> PostAuthorisedCustomerDetail(AuthorisedCustomerDetail authorisedCustomerDetail)
        {
            _context.AuthorisedCustomerDetails.Add(authorisedCustomerDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAuthorisedCustomerDetail", new { id = authorisedCustomerDetail.CustomerId }, authorisedCustomerDetail);
        }

        // DELETE: api/AuthorisedCustomerDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorisedCustomerDetail(int id)
        {
            var authorisedCustomerDetail = await _context.AuthorisedCustomerDetails.FindAsync(id);
            if (authorisedCustomerDetail == null)
            {
                return NotFound();
            }

            _context.AuthorisedCustomerDetails.Remove(authorisedCustomerDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AuthorisedCustomerDetailExists(int id)
        {
            return _context.AuthorisedCustomerDetails.Any(e => e.CustomerId == id);
        }
    }
}
