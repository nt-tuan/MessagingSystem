using CleanArchitecture.Core.Entities.HR;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels.HR
{
    public class EmployeeErrorableModel : EmployeeModel
    {
        public EmployeeErrorableModel()
        {

        }
        public EmployeeErrorableModel(Employee entity) : base(entity)
        {

        }
        public ICollection<MessageModel> messages { get; set; } = new List<MessageModel>();

        public async Task UpdateEmployeeFromCell(string header, ICell cell, Func<dynamic,Task<List<Employee>>> getEmp, Func<dynamic, Task<List<Department>>> getDept)
        {
            if(cell == null && cell.CellType == CellType.Blank)
            {
                return;
            }

            header = header.ToLower();
            if (header == "code")
            {
                var code = cell.StringCellValue;
                var emp = await getEmp(new { Code = code });
                if (emp.Count > 0)
                {
                    messages.Add(MessageModel.CreateWarning("EMPLOYEE_CODE_EXISTED", header));
                }
                this.code = code;
            }
            else if (header == "firstname")
            {
                person.firstname = cell.StringCellValue;
            }
            else if (header == "lastname")
            {
                person.lastname = cell.StringCellValue;
            }
            else if (header == "email")
            {
                person.email = cell.StringCellValue;
            }
            else if (header == "birthday")
            {
                person.birthday = cell.DateCellValue;
            }
            else if (header == "id-number"){
                person.identityNumber = cell.StringCellValue;
            }
            else if(header == "department")
            {
                var dept = await getDept(new { Code = cell.StringCellValue });
                if (dept.Count > 0)
                {
                    var curDept = dept.First();
                    this.dept = new DepartmentModel(curDept);
                }
                else
                    messages.Add(MessageModel.CreateError("INVALID DEPARMENT", header));
            }
        }
    }
}
