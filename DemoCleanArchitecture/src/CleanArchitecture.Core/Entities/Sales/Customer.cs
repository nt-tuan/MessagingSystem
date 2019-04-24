using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string Code { get; set; }
        public string Fullname { get; set; }
        public string Shortname { get; set; }
        public string Phone { get; set; }
        public string DistributorCode { get; set; }
        public string Owner { get; set; }
        public string Receiver { get; set; }

        public DateTime CreateTime { get; set; }
        public DateTime ModifiedTime { get; set; }
    }
}
