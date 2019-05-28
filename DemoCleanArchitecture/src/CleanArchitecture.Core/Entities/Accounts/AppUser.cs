using CleanArchitecture.Core.Entities.HR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities.Accounts
{
    public class AppUser : IdentityUser
    {

        public int? EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }


        public string GetFullname()
        {
            return Employee == null ? UserName : Employee.GetFullname();
        }

        public string GetShortName()
        {
            return Employee == null ? UserName : Employee.GetShortName();
        }
    }
}
