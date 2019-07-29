using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.SharedKernel
{
    public class BaseDetailEntity : BaseEntity
    {
        public DateTime Effective { get; set; }
        public string CreateNote { get; set; }
    }
}
