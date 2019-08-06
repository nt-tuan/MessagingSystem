using CleanArchitecture.Core.Entities.Accounts;
using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Core
{
    public class Person : BaseDetailEntity
    {
        public enum PersonGender {MALE = 0, FEMALE = 1}
        public string IdentityNumber { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DisplayName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? Birthday { get; set; }
        public int Gender { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public AppUser AppUser { get; set; }
    }
}
