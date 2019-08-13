using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.Accounts;
using CleanArchitecture.Core.Entities.Sales;
using CleanArchitecture.Core.Entities.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Core.SharedKernel;
using CleanArchitecture.Core.Entities.HR;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IMessageReceiverRepository
    {
        Task<ICollection<ReceiverCategory>> GetCategories(DateTime? at);
        Task<ICollection<MessageReceiverGroup>> GetGroups(string search = null, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = (int)BaseEntity.ListOrder.ASC, dynamic filter = null, DateTime? at = null);
        Task<MessageReceiverGroup> GetGroupById(int id, DateTime? at);
        Task<MessageReceiverGroup> AddGroup(MessageReceiverGroup group, AppUser actor, DateTime? at);        
        Task<MessageReceiverGroup> UpdateGroup(MessageReceiverGroup group, AppUser actor, DateTime? at);
        Task DeleteGroup(int id, AppUser actor, DateTime? at);
        Task<ICollection<MessageReceiver>> GetReceivers(string search = null, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = (int)BaseEntity.ListOrder.ASC, dynamic filter = null, DateTime? at = null);
        Task<MessageReceiver> GetReceiverById(int id, DateTime? at);
        Task<MessageReceiver> AddCustomerReceiver(Customer customer, AppUser actor, DateTime? at);
        Task<MessageReceiver> AddEmployeeReceiver(Employee employee, AppUser actor, DateTime? at);
        Task<MessageReceiver> AddReceiver(MessageReceiver receiver, AppUser actor, DateTime? at);
        Task<MessageReceiver> UpdateReceiver(MessageReceiver receiver, AppUser actor, DateTime? at);
        Task DeleteReceiver(int id, AppUser user, DateTime? at);

        Task<ReceiverProvider> AddReceiverProvider(ReceiverProvider provider, AppUser actor, DateTime? at);
        Task<MessageServiceProvider> GetProviderById(int id, bool throwException);
    }
}
