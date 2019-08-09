using CleanArchitecture.Core.Entities.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels.HR
{
    public class EmployeeModel
    {
        public int id { get; set; }
        public string code { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string displayname { get; set; }
        public int? deptid { get; set; }
        public string deptname { get; set; }
        public DateTime? birthday { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public EmployeeModel()
        {

        }

        public EmployeeModel(Employee entity)
        {
            id = entity.Id;
            code = entity.Code;
            firstname = entity.Person.FirstName;
            lastname = entity.Person.LastName;
            deptid = entity.DepartmentId.Value;
            deptname = entity.Department.FullName;
            birthday = entity.Person.Birthday;
            email = entity.Person.Email;
        }

        public Employee ToEmployee()
        {
            var entity = new Employee
            {
                Id = id,
                DepartmentId = deptid,
            };
            entity.Person = new Core.Entities.Core.Person
            {
                FirstName = firstname,
                LastName = lastname,
                DisplayName = displayname,
                Email = email,
                Phone = phone,
                Birthday = birthday,
                Address = address
            };
            return entity;
        }
    }
}
