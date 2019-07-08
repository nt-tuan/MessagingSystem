using CleanArchitecture.Core.Entities.SMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface ISmsRepository
    {
        Task GetReceiverCategories();
        Task<IEnumerable<MessageReceiver>> GetReceivers();
    }
}
