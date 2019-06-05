﻿using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.Sales
{
    public class Distributor : BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}