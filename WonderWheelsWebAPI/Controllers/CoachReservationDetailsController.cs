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
    public class CoachReservationDetailsController : ControllerBase
    {
        private readonly BusReservationContext _context;

        public CoachReservationDetailsController(BusReservationContext context)
        {
            _context = context;
        }

        // GET: api/CoachReservationDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CoachReservationDetail>>> GetCoachReservationDetails()
        {
            return await _context.CoachReservationDetails.ToListAsync();
        }

        // GET: api/CoachReservationDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CoachReservationDetail>> GetCoachReservationDetail(int id)
        {
            var coachReservationDetail = await _context.CoachReservationDetails.FindAsync(id);

            if (coachReservationDetail == null)
            {
                return NotFound();
            }

            return coachReservationDetail;
        }

        // PUT: api/CoachReservationDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoachReservationDetail(int id, CoachReservationDetail coachReservationDetail)
        {
            if (id != coachReservationDetail.ReservationId)
            {
                return BadRequest();
            }

            _context.Entry(coachReservationDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoachReservationDetailExists(id))
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

        // POST: api/CoachReservationDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CoachReservationDetail>> PostCoachReservationDetail(CoachReservationDetail coachReservationDetail)
        {
            _context.CoachReservationDetails.Add(coachReservationDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCoachReservationDetail", new { id = coachReservationDetail.ReservationId }, coachReservationDetail);
        }

        // DELETE: api/CoachReservationDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCoachReservationDetail(int id)
        {
            var coachReservationDetail = await _context.CoachReservationDetails.FindAsync(id);
            if (coachReservationDetail == null)
            {
                return NotFound();
            }

            _context.CoachReservationDetails.Remove(coachReservationDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CoachReservationDetailExists(int id)
        {
            return _context.CoachReservationDetails.Any(e => e.ReservationId == id);
        }
    }
}
