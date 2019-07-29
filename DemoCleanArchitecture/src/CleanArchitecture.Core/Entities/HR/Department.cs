using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities.HR
{
    public class Department : BaseEntity
    {
        public string Code { get; set; }

        public ICollection<DepartmentDetail> Children { get; set; }

        public ICollection<EmployeeDetail> Employees { get; set; }
    }
}
