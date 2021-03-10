using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RabaniCRMAssigment.Models
{
    public  class Accounts
    {
        public int AccountsId { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public string Status { get; set; }
        [ForeignKey("AppUserID")]
        public int AppUserID { get; set; }
        [IgnoreDataMember]
        public AppUser appUser { get; set; }
    }
}
