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
        public string shortname { get; set; }
        public string alias { get; set; }
        public int? parentId { get; set; }
        public string parentName { get; set; }
        public string parentCode { get; set; }
        public int? managerId { get; set; }
        public string managerName { get; set; }

        public DepartmentModel()
        {

        }

        public DepartmentModel(Department entity)
        {
            if (entity.OriginId == null)
                id = entity.Id;
            else
                id = entity.Id;
            code = entity.Code;
            name = entity.FullName;
            //alias = entity.Name;
            parentId = entity.ParentId;
            managerId = entity.ManagerId;
            managerName = entity.Manager!=null? entity.Manager.Person.FullName : null;
            if (entity.Parent != null)
            {
                SetParent(entity.Parent);
            }
        }

        public void SetParent(Department curParent)
        {
            parentId = curParent.Id;
            parentCode = curParent.Code;
            parentName = curParent.FullName;
        }

        public Department ToEntity()
        {
            var entity = new Department
            {
                Code = code,
                FullName = name,
                ShortName = shortname,
                ParentId = parentId
            };
            return entity;
        }
    }
}
