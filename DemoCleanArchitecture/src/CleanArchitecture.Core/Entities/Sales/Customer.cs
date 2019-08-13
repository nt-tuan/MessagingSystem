using CleanArchitecture.Core.Entities.Core;
using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Sales
{
    public class Customer : BaseDetailEntity<Customer>
    {
        public Person Person { get; set; }
        public int? PersonId { get; set; }
        public Business Business { get; set; }
        public int? BusinessId { get; set; }
        public string Code { get; set; }

        public int? DistributorId { get; set; }
        public Distributor Distributor { get; set; }

        public float? CoordinateX { get; set; }
        public float? CoordinateY { get; set; }
    }
}
