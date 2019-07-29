using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Core
{
    public class BusinessDetail : BaseDetailEntity
    {
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TaxNumber { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
