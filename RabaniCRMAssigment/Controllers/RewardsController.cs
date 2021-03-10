using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabaniCRMAssigment.Data;
using RabaniCRMAssigment.Models;

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
        public List<Rewards> Get()
        {
            return _context.Rewards.ToList(); 
        }

        // GET: api/Rewards/5
        [HttpGet("{id}")]
        public Rewards Get(int id)
        {
            return _context.Rewards.Find(id);
        }

        // POST: api/Rewards
        [HttpPost]
        public string Post([FromBody] Rewards value)
        {
            if (_context.Rewards.Find(value.RewardsId) == null)
            {
                _context.Rewards.Add(value);
                _context.SaveChanges();
                return "Success";
            }
            return "err : Duplicate";

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Rewards.Remove(_context.Rewards.Find(id));
        }
    }
}
