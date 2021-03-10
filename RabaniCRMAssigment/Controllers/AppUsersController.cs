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
        public List<AppUser> Get()
        {
            return _context.AppUsers.Include("Accounts").ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<AppUser> Get(int id)
        {
            return _context.AppUsers.Include(a => a.Accounts).Where(i => i.AppUserId == id).SingleOrDefault();
        }

        // POST: api/Users
        [HttpPost]
        public List<AppUser> Post([FromBody] List<AppUser> value)
        {
            foreach (var item in value)
            {
                _context.AppUsers.Add(item);
                _context.SaveChanges();
            }
            return _context.AppUsers.ToList();

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.AppUsers.Remove(_context.AppUsers.Find(id));
            _context.SaveChanges();
        }
    }
}
