using CleanArchitecture.Core.Entities.Accounts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DmcSupport.Models.Accounts
{
    public class UserRolesModel
    {
        public AppUser User { get; set; }
        public List<bool> RolesAssigned { get; set; }
        public List<string> RolesNewAssigned { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}