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
        //Usecase 1.1
        Task<ICollection<ReceiverCategory>> GetCategories(DateTime? at);
        //Usecase 1.2
        Task<ReceiverCategory> AddCategory(ReceiverCategory cate, AppUser appUser);
        //Usecase 1.3
        Task UpdateCategory(ReceiverCategory cate, AppUser appUser);
        //Usecase 1.4
        Task DeleteCategory(ReceiverCategory cate, AppUser appUser);

        //Usecase 2.1
        Task<ICollection<MessageReceiverGroup>> GetGroups(string search = null, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = (int)BaseEntity.ListOrder.ASC, dynamic filter = null, DateTime? at = null);
        //Usecase 2.2
        Task<MessageReceiverGroup> GetGroupById(int id, DateTime? at);
        //Usecase 2.3
        Task<MessageReceiverGroup> AddGroup(MessageReceiverGroup group, AppUser actor, DateTime? at);        
        //Usecase 2.4
        Task UpdateGroup(MessageReceiverGroup group, AppUser actor, DateTime? at);
        //Usecase 2.5
        Task DeleteGroup(int id, AppUser actor, DateTime? at);

        //Usecase  3.1
        Task<ICollection<MessageReceiver>> GetReceivers(string search = null, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = (int)BaseEntity.ListOrder.ASC, dynamic filter = null, DateTime? at = null);
        //Usecase 3.2
        Task<MessageReceiver> GetReceiverById(int id, DateTime? at);
        //Usecase 3.3.1
        Task<MessageReceiver> AddCustomerReceiver(Customer customer, AppUser actor, DateTime? at);
        //Usecase 3.3.2
        Task<MessageReceiver> AddEmployeeReceiver(Employee employee, AppUser actor, DateTime? at);
        //Usecase 3.3.3
        Task<MessageReceiver> AddReceiver(MessageReceiver receiver, AppUser actor, DateTime? at);
        //Usecase 3.4
        Task UpdateReceiver(MessageReceiver receiver, AppUser actor, DateTime? at);
        //Usecase 3.5
        Task DeleteReceiver(int id, AppUser actor, DateTime? at);
        //Usecase 3.4.1
        Task<ReceiverProvider> AddReceiverProvider(ReceiverProvider provider, AppUser actor, DateTime? at);
        Task DeleteReceiverProvider(int id, AppUser actor, DateTime? at);
        //Usecase 3.6
        Task<List<MessageServiceProvider>> GetProviders(DateTime? at);
        //Usecase 3.7
        Task<MessageServiceProvider> GetProviderById(int id, bool throwException);
    }
}
