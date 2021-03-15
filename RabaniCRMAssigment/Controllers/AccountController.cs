using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabaniCRMAssigment.Data;
using RabaniCRMAssigment.Models;
using Microsoft.EntityFrameworkCore;


namespace RabaniCRMAssigment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Account
        [HttpGet]
        public async Task<List<Accounts>> Get()
        {
           return await _context.Accounts.ToListAsync();
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public async Task<Accounts> Get(int id)
        {
            return await _context.Accounts.FindAsync(id);
        }

        // POST: api/Account
        [HttpPost]
        public async Task<List<Accounts>> Post([FromBody] Accounts value)
        {   
            await _context.Accounts.AddAsync(value);
            await _context.SaveChangesAsync();
            return await _context.Accounts.ToListAsync();
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            _context.Accounts.Remove(_context.Accounts.FindAsync(id).Result);
            await _context.SaveChangesAsync();
        }

        // POST : api/Account/Points
        [HttpPost("Points")]
        public async Task<string> Post([FromBody] ServiceUser value)
        {
             _context.Accounts.FindAsync(value.accountID).Result.Balance += _context.Services
                .Where(x => x.ServiceName == value.serviceName).FirstAsync().Result.PointsEarned;

            await _context.SaveChangesAsync();
            return "success";
        }

        // POST : api/Account/Redeem
        [HttpPost("Redeem")]
        public async Task<string> Post([FromBody] UserReward value)
        {
            if ( _context.Accounts.FindAsync(value.accountID).Result.Status == "INACTIVE")
                return "Account is inactive";


            if ((_context.Accounts.FindAsync(value.accountID).Result.Balance -= _context.Rewards
                .Where(x => x.RewardName == value.RewardName).FirstAsync().Result.RewardPoint) >= 0)
            {
                await _context.SaveChangesAsync();
                return "success";
            }
            else
                return "Balance is too low";
           
            
        }
    }
}
