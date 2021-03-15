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
    public class RewardsController : ControllerBase
    {
       
            private readonly DataContext _context;

            public RewardsController(DataContext context)
            {
                _context = context;
            }

        // GET: api/Rewards
        [HttpGet]
        public async Task<List<Rewards>> Get()
        {
            return await _context.Rewards.ToListAsync(); 
        }

        // GET: api/Rewards/5
        [HttpGet("{id}")]
        public async Task<Rewards> Get(int id)
        {
            return await _context.Rewards.FindAsync(id);
        }

        // POST: api/Rewards
        [HttpPost]
        public async Task<string> Post([FromBody] Rewards value)
        {
            if (_context.Rewards.FindAsync(value.RewardsId) == null)
            {
                await _context.Rewards.AddAsync(value);
                await _context.SaveChangesAsync();
                return "Success";
            }
            return "err : Duplicate";

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Rewards.Remove(_context.Rewards.FindAsync(id).Result);
        }
    }
}
