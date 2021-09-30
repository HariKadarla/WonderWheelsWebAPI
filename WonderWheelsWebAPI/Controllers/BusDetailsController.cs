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
    public class BusDetailsController : ControllerBase
    {
        private readonly BusReservationContext _context;

        public BusDetailsController(BusReservationContext context)
        {
            _context = context;
        }

        // GET: api/BusDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusDetail>>> GetBusDetails()
        {
            return await _context.BusDetails.ToListAsync();
        }

        // GET: api/BusDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusDetail>> GetBusDetail(int id)
        {
            var busDetail = await _context.BusDetails.FindAsync(id);

            if (busDetail == null)
            {
                return NotFound();
            }

            return busDetail;
        }

        // PUT: api/BusDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusDetail(int id, BusDetail busDetail)
        {
            if (id != busDetail.BusId)
            {
                return BadRequest();
            }

            _context.Entry(busDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusDetailExists(id))
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

        // POST: api/BusDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BusDetail>> PostBusDetail(BusDetail busDetail)
        {
            _context.BusDetails.Add(busDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusDetail", new { id = busDetail.BusId }, busDetail);
        }

        // DELETE: api/BusDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusDetail(int id)
        {
            var busDetail = await _context.BusDetails.FindAsync(id);
            if (busDetail == null)
            {
                return NotFound();
            }

            _context.BusDetails.Remove(busDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusDetailExists(int id)
        {
            return _context.BusDetails.Any(e => e.BusId == id);
        }
    }
}
