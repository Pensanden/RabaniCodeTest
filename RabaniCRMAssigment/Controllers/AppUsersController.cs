using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabaniCRMAssigment.Data;
using RabaniCRMAssigment.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNet.OData;

namespace RabaniCRMAssigment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUsersController : ControllerBase
    {
        private readonly DataContext _context;

        public AppUsersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [EnableQuery()]
        [HttpGet()]
        public async Task<List<AppUser>> Get()
        {
            return await _context.AppUsers.Include("Accounts").ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> Get(int id)
        {
            return await _context.AppUsers.Include(a => a.Accounts)
                .Where(i => i.AppUserId == id).SingleOrDefaultAsync();
        }

        // POST: api/Users
        [HttpPost]
        public async Task<List<AppUser>> Post([FromBody] List<AppUser> value)
        {
            foreach (var item in value)
            {
              await  _context.AppUsers.AddAsync(item);
              await  _context.SaveChangesAsync();
            }
            return await _context.AppUsers.ToListAsync();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            _context.AppUsers.Remove(_context.AppUsers.FindAsync(id).Result);
            await _context.SaveChangesAsync();
        }
    }
}
