using CleanArchitecture.Core.Entities.Accounts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels.Accounts
{
    public class DetailsModel
    {
        public string username { get; set; }
        public string email { get; set; }
        public string fullname { get; set; }
        public string shortname { get; set; }
        public string lastActiveTime { get; set; }
        public string employeeCode { get; set; }
        public int? employeeId { get; set; }
        public ICollection<string> roles { get; set; }
        public DetailsModel()
        {

        }

        public DetailsModel(AppUser user)
        {
            username = user.UserName;
            email = user.Email;

        }

        public void SetRoles(ICollection<string> roles)
        {
            this.roles = roles;
        }
    }
}
