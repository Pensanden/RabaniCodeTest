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
    public class AccountController : ControllerBase
    {
        
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Account
        [HttpGet]
        public  List<Accounts> Get()
        {
           return _context.Accounts.ToList();
        }

        // GET: api/Account/5
        [HttpGet("{id}")]
        public Accounts Get(int id)
        {
            return _context.Accounts.Find(id);
        }

        // POST: api/Account
        [HttpPost]
        public List<Accounts> Post([FromBody] Accounts value)
        {   
            _context.Accounts.Add(value);
            _context.SaveChanges();
            return _context.Accounts.ToList();
        }

        // DELETE: api/Account/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _context.Accounts.Remove(_context.Accounts.Find(id));
            _context.SaveChanges();
        }

        // POST : api/Account/Points
        [HttpPost("Points")]
        public string Post([FromBody] ServiceUser value)
        {
            _context.Accounts.Find(value.accountID).Balance += _context.Services.Where(x => x.ServiceName == value.serviceName).First().PointsEarned;
            _context.SaveChanges();
            return "success";
        }

        // POST : api/Account/Redeem
        [HttpPost("Redeem")]
        public string Post([FromBody] UserReward value)
        {
            if (_context.Accounts.Find(value.accountID).Status == "INACTIVE")
                return "Account is inactive";


            if ((_context.Accounts.Find(value.accountID).Balance -= _context.Rewards.Where(x => x.RewardName == value.RewardName).First().RewardPoint) >= 0)
            {
                _context.SaveChanges();
                return "success";
            }
            else
                return "Balance is too low";
           
            
        }
    }
}
