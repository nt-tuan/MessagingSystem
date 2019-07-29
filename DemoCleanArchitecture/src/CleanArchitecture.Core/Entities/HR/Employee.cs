using CleanArchitecture.Core.Entities.Core;
using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.HR
{
    public class Employee : BaseEntity
    {
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public string Code { get; set; }
        public ICollection<EmployeeJob> EmployeeJobs { get; set; }
    }
}
