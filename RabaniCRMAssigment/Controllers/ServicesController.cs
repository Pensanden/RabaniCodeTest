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
    public class ServicesController : ControllerBase
    {
        private readonly DataContext _context;

        public ServicesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Services
        [HttpGet]
        public List<Services> Get()
        {
            return _context.Services.ToList();
        }

        // GET: api/Services/5
        [HttpGet("{id}")]
        public Services Get(int id)
        {
            return _context.Services.Find(id);
        }

        // POST: api/Services
        [HttpPost]
        public string Post([FromBody] Services value)
        {
            if (_context.Services.Find(value.ServicesId) == null)
            {
                _context.Services.Add(value);
                _context.SaveChanges();
                return "Success";
            }
            return "err : Duplicate";
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Services.Remove(_context.Services.Find(id));
            _context.SaveChanges();
        }
    }
}
