using CleanArchitecture.Core.Entities.Core;
using CleanArchitecture.Core.Entities.HR;
using CleanArchitecture.Web.ApiModels.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels.HR
{
    public class EmployeeModel : BaseModel<Employee>
    {
        public string code { get; set; }     
        public DepartmentModel dept { get; set; }

        public PersonModel person { get; set; }
        public EmployeeModel()
        {

        }

        public EmployeeModel(Employee entity) : base(entity)
        {
            code = entity.Code;
            if (entity.Person != null)
            {
                person = new PersonModel(entity.Person);
            }
            if (entity.Department != null)
                dept = new DepartmentModel(entity.Department);
        }

        

        public Employee ToEmployee()
        {
            var entity = new Employee
            {
                Id = id,
                Code = code
            };

            if(dept != null)
            {
                entity.DepartmentId = dept.id;
            }

            if(person != null)
            {
                entity.Person = person.ToEntity();
                entity.PersonId = person.id;
            }
            
            return entity;
        }
    }
}
