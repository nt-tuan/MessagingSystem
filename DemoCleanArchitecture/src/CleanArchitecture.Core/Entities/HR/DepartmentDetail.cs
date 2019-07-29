using CleanArchitecture.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Core.Entities.HR
{
    public class DepartmentDetail : BaseDetailEntity
    {
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }

        public string Location { get; set; }
        public string Location2 { get; set; }
        public string Location3 { get; set; }

        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Phone3 { get; set; }
        public int? ParentId { get; set; }
        public virtual Department Parent { get; set; }
        public int? ManagerId { get; set; }
        public Employee Manager { get; set; }
    }
}
