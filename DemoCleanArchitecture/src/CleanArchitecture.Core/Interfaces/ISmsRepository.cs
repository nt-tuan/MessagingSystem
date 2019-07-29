using CleanArchitecture.Core.Entities.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IMessagingRepository
    {
        Task GetReceiverCategories();
        Task<IEnumerable<MessageReceiver>> GetReceivers();
    }
}
