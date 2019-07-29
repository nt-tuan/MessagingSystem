using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.HR
{
    public class EmployeeDetail : BaseDetailEntity
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int EmployeeTitleId { get; set; }
        public EmployeeTitle EmployeeTitle { get; set; }
    }
}
