using CleanArchitecture.Core.Entities.Messaging;
using CleanArchitecture.Web.ApiModels.Core;
using CleanArchitecture.Web.ApiModels.HR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels.Messaging
{
    public class MessageReceiverModel
    {
        public string name { get; set; }
        public string shortname { get; set; }
        public CustomerModel customer { get; set; }
        public EmployeeModel employee { get; set; }
        public ICollection<ReceiverProviderModel> providers { get; set; }
        public MessageReceiverModel()
        {

        }

        public MessageReceiverModel(MessageReceiver entity)
        {
            name = entity.FullName;
            shortname = entity.ShortName;
            if (entity.Customer != null)
                customer = new CustomerModel(entity.Customer);
            if (entity.Employee != null)
                employee = new EmployeeModel(entity.Employee);
        }
    }
}
