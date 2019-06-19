using CleanArchitecture.Core.Entities.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels.HR
{
    public class DepartmentModel
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string alias { get; set; }
        public int? parentId { get; set; }
        public string parentName { get; set; }
        public DepartmentModel()
        {

        }

        public DepartmentModel(Department entity)
        {
            id = entity.Id;
            code = entity.Code;
            name = entity.Name;
            //alias = entity.Name;
            parentId = entity.ParentId;
            if (entity.Parent != null)
                parentName = entity.Parent.Name;
        }
    }
}
