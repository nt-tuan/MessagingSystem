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

        public async Task UpdateEmployeeFromCell(string header, ICell cell, Func<dynamic,Task<Employee>> getEmp, Func<dynamic, Task<Department>> getDept)
        {
            if(cell == null && cell.CellType == CellType.Blank)
            {
                return;
            }

            if (header == "code")
            {
                var code = cell.StringCellValue;
                var emp = await getEmp(new { Code = code });
                if (emp != null)
                {
                    messages.Add(MessageModel.CreateWarning("EMPLOYEE_CODE_EXISTED", header));
                }
                this.code = code;
            }
            else if (header == "firstname")
            {
                firstname = cell.StringCellValue;
            }
            else if (header == "lastname")
            {
                lastname = cell.StringCellValue;
            }
            else if (header == "email")
            {
                email = cell.StringCellValue;
            }
            else if (header == "birthday")
            {
                birthday = cell.DateCellValue;
            }else if(header == "department")
            {
                var dept = await getDept(new { Code = cell.StringCellValue });
                if (dept != null)
                {
                    deptid = dept.Id;
                }
                else
                    messages.Add(MessageModel.CreateError("INVALID DEPARMENT", header));
            }
        }
    }
}
