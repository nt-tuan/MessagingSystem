using CleanArchitecture.Core.Entities.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.ApiModels.Messaging
{
    public class ReceiverProviderModel : BaseModel<ReceiverProvider>
    {
        public ProviderModel provider { get; set; }
        public string receiverAddress { get; set; }
        public ReceiverProviderModel()
        {

        }

        public ReceiverProviderModel(ReceiverProvider entity) : base(entity) {
            if(entity.MessageServiceProvider != null)
            {
                provider = new ProviderModel(entity.MessageServiceProvider);
            }
            receiverAddress = entity.ReceiverAddress;
        }
    }
}
