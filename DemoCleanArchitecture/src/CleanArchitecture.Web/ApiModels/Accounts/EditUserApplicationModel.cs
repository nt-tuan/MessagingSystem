using CleanArchitecture.Core.Entities.Accounts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmcSupport.Models.Accounts
{
    public class EditUserApplicationModel : AppUser
    {
        public List<string> Roles { get; set; }
    }
}
