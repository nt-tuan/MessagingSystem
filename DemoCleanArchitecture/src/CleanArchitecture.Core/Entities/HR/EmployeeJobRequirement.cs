using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities.HR
{
    public class EmployeeJobRequirement
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int JobRequirementId { get; set; }
        public JobRequirement JobRequirement { get; set; }
    }
}
