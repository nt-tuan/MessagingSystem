﻿using CleanArchitecture.Core.Entities.Core;
using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Sales
{
    public class DistributorDetail : BaseDetailEntity
    {
        public int DistributorId { get; set; }
        public Distributor Distributor { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}