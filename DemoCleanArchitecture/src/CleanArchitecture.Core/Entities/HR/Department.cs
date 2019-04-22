using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Entities.HR
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }

        public string Code { get; set; }
        public int? ParentId { get; set; }

        public virtual Department Parent { get; set; }

        public ICollection<Department> Children { get; set; }

        public string Location { get; set; }
        public string Location2 { get; set; }
        public string Location3 { get; set; }

        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public bool Removed { get; set; } = false;

        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }

        public ICollection<Employee> Employees { get; set; }
    }
}
