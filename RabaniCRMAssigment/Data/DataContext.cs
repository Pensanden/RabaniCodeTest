using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using RabaniCRMAssigment.Models;

namespace RabaniCRMAssigment.Data
{
    public class DataContext : DbContext
    {
        public DataContext (DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<Rewards> Rewards { get; set; }
        public DbSet<Services> Services { get; set; }
        
    }
}
