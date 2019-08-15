using CleanArchitecture.Core.Entities.HR;
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
    }
}
