using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace RabaniCRMAssigment.Models
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Accounts> Accounts { get; set; }
    }
}




