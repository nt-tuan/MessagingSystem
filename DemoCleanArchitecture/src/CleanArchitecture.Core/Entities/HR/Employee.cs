using CleanArchitecture.Core.Entities.Core;
using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.HR
{
    public class Employee : BaseDetailEntity
    {
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public string Code { get; set; }
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
        public int EmployeeTitleId { get; set; }
        public EmployeeTitle EmployeeTitle { get; set; }
        public Employee Origin { get; set; }
    }
}
