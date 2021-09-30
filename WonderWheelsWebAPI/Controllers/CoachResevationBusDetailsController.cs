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
    public class CoachResevationBusDetailsController : ControllerBase
    {
        private readonly BusReservationContext _context;

        public CoachResevationBusDetailsController(BusReservationContext context)
        {
            _context = context;
        }

        // GET: api/CoachResevationBusDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachResevationBusDetail>>> GetCoachResevationBusDetails()
        {
            return await _context.CoachResevationBusDetails.ToListAsync();
        }

        // GET: api/CoachResevationBusDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoachResevationBusDetail>> GetCoachResevationBusDetail(int id)
        {
            var coachResevationBusDetail = await _context.CoachResevationBusDetails.FindAsync(id);

            if (coachResevationBusDetail == null)
            {
                return NotFound();
            }

            return coachResevationBusDetail;
        }

        // PUT: api/CoachResevationBusDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoachResevationBusDetail(int id, CoachResevationBusDetail coachResevationBusDetail)
        {
            if (id != coachResevationBusDetail.CoachBusId)
            {
                return BadRequest();
            }

            _context.Entry(coachResevationBusDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachResevationBusDetailExists(id))
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

        // POST: api/CoachResevationBusDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoachResevationBusDetail>> PostCoachResevationBusDetail(CoachResevationBusDetail coachResevationBusDetail)
        {
            _context.CoachResevationBusDetails.Add(coachResevationBusDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoachResevationBusDetail", new { id = coachResevationBusDetail.CoachBusId }, coachResevationBusDetail);
        }

        // DELETE: api/CoachResevationBusDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoachResevationBusDetail(int id)
        {
            var coachResevationBusDetail = await _context.CoachResevationBusDetails.FindAsync(id);
            if (coachResevationBusDetail == null)
            {
                return NotFound();
            }

            _context.CoachResevationBusDetails.Remove(coachResevationBusDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoachResevationBusDetailExists(int id)
        {
            return _context.CoachResevationBusDetails.Any(e => e.CoachBusId == id);
        }
    }
}
