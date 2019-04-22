using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities
{
    public class Customer : BaseEntity
    {
        public string Fullname { get; set; }
    }
}
