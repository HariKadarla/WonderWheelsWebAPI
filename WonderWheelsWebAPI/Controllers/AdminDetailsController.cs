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
    public class AdminDetailsController : ControllerBase
    {
        private readonly BusReservationContext _context;

        public AdminDetailsController(BusReservationContext context)
        {
            _context = context;
        }

        // GET: api/AdminDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminDetail>>> GetAdminDetails()
        {
            return await _context.AdminDetails.ToListAsync();
        }

        // GET: api/AdminDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminDetail>> GetAdminDetail(int id)
        {
            var adminDetail = await _context.AdminDetails.FindAsync(id);

            if (adminDetail == null)
            {
                return NotFound();
            }

            return adminDetail;
        }

        // PUT: api/AdminDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminDetail(int id, AdminDetail adminDetail)
        {
            if (id != adminDetail.AdminId)
            {
                return BadRequest();
            }

            _context.Entry(adminDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminDetailExists(id))
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

        // POST: api/AdminDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminDetail>> PostAdminDetail(AdminDetail adminDetail)
        {
            _context.AdminDetails.Add(adminDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminDetail", new { id = adminDetail.AdminId }, adminDetail);
        }

        // DELETE: api/AdminDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminDetail(int id)
        {
            var adminDetail = await _context.AdminDetails.FindAsync(id);
            if (adminDetail == null)
            {
                return NotFound();
            }

            _context.AdminDetails.Remove(adminDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminDetailExists(int id)
        {
            return _context.AdminDetails.Any(e => e.AdminId == id);
        }
    }
}
