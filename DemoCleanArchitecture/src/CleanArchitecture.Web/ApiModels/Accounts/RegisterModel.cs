using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmcSupport.Models.Accounts
{
    public class RegisterModel
    {
        public string EmployeeCode { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Email { get; set; }
    }
}
