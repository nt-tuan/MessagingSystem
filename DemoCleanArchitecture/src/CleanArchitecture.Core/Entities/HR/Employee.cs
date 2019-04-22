using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.HR
{
    public class Employee : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public int? DepartmentId { get; set; }

        public bool Removed { get; set; } = false;

        public virtual Department Department { get; set; }

        public ICollection<EmployeeJob> EmployeeJobs { get; set; }

        public string GetShortName()
        {
            return "";
        }

        public string GetFullname()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }
    }
}
