using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels.HR
{
    public class DepartmentCollectionModel
    {
        public ICollection<DepartmentModel> depts { get; set; } = new List<DepartmentModel>();
    }
}
