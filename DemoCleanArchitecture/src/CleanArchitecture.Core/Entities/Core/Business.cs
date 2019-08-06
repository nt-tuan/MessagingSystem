using CleanArchitecture.Core.Entities.Accounts;
using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Core
{
    public class Business : BaseDetailEntity
    {
        public string BusinessIdentityNumber { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TaxNumber { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public AppUser AppUser { get; set; }
    }
}
