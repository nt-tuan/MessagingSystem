using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels.HR
{
    public class EmployeeCollectionModel
    {
        public ICollection<EmployeeModel> employees { get; set; } = new List<EmployeeModel>();
    }
}
