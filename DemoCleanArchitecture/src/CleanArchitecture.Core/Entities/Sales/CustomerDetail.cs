using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Sales
{
    public class CustomerDetail : BaseDetailEntity
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? DistributorId { get; set; }
        public Distributor Distributor { get; set; }

        public float? CoordinateX { get; set; }
        public float? CoordinateY { get; set; }
    }
}
