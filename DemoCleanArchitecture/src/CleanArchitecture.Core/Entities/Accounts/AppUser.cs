using CleanArchitecture.Core.Entities.Core;
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

        public int? PersonId { get; set; }
        public int? BusinessId { get; set; }

        public virtual Person Person { get; set; }
        
        public virtual Business Business { get; set; }

        public string GetFullname()
        {
            return Person == null ? UserName : Person.FullName;
        }

        public string GetShortName()
        {
            return Person == null ? UserName : Person.FullName;
        }
    }
}
