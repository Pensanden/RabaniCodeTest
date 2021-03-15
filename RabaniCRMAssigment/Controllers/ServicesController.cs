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
    public class ServicesController : ControllerBase
    {
        private readonly DataContext _context;

        public ServicesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public async Task<List<Services>> Get()
        {
            return await _context.Services.ToListAsync();
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public async Task<Services> Get(int id)
        {
            return await _context.Services.FindAsync(id);
        }

        // POST: api/Services
        [HttpPost]
        public async Task<string> Post([FromBody] Services value)
        {
            if (_context.Services.FindAsync(value.ServicesId) == null)
            {
               await _context.Services.AddAsync(value);
               await _context.SaveChangesAsync();
               return "Success";
            }
               return "err : Duplicate";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            _context.Services.Remove(_context.Services.FindAsync(id).Result);
            await _context.SaveChangesAsync();
        }
    }
}
