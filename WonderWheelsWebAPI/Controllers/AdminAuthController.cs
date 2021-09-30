using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WonderWheelsWebAPI.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;


namespace WonderWheelsWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminAuthController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly BusReservationContext _context;

        public AdminAuthController(BusReservationContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult<AdminDetail>> Post(AdminDetail _account)
        {
            if (_account != null && _account.Email != null && _account.Password != null)
            {
                AdminDetail adminaccount = await GetAccount(_account.Email, _account.Password);

                if (adminaccount != null)
                {
                    return adminaccount;
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest("Provide Login Credentials");
            }
        }
        private async Task<AdminDetail> GetAccount(string email, string password)
        {
            return await _context.AdminDetails.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }

    }
}
