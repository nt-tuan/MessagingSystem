using CleanArchitecture.Core.Entities.HR;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels.HR
{
    public class DepartmentErrorableModel : DepartmentModel
    {
        public ICollection<MessageModel> messages { get; set; } = new List<MessageModel>();

        public DepartmentErrorableModel()
        {

        }

        public DepartmentErrorableModel(Department entity) : base(entity)
        {

        }

        public async Task UpdateDepartmentFromCell(string header, ICell cell, Func<dynamic, Task<ICollection<Department>>> getDept)
        {
            if (cell == null || cell.CellType == CellType.Blank)
            {
                return;
            }

            if (header == "code")
            {
                var curDept = await getDept(new { Code =  cell.StringCellValue});
                if(curDept != null)
                {
                    messages.Add(MessageModel.CreateWarning("DEPARTMENT_CODE_EXISTED", header));
                }
                code = cell.StringCellValue;
            } else if(header == "name")
            {
                name = cell.StringCellValue;
            } else if(header == "parent")
            {
                var parentValue = cell.StringCellValue;
                if (String.IsNullOrEmpty(parentValue))
                    return;
                var curParent = await getDept(new { Code = parentValue });
                if(curParent.Count > 0)
                {
                    parentId = curParent.First().Id;
                }
                else
                {
                    messages.Add(MessageModel.CreateError("INVALID DEPARMENT", header));
                }
            }
        }
    }
}
