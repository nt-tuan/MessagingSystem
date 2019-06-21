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
        public int? deptid { get; set; }
        public string deptname { get; set; }
        public DateTime birthday { get; set; }
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
            firstname = entity.FirstName;
            lastname = entity.LastName;
            deptid = entity.DepartmentId.Value;
            deptname = entity.Department.Name;
            birthday = entity.Birthday;
            email = entity.Email;
        }
    }
}
