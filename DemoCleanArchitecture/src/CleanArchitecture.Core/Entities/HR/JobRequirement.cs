using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities.HR
{
    public class JobRequirement : BaseEntity
    {
        public string Name { get; set; }

        public ICollection<EmployeeJobRequirement> EmployeeJobRequirements { get; set; }
    }
}
