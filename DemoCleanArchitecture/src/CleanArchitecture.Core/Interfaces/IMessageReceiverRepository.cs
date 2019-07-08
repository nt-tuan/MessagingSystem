using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.Sales;
using CleanArchitecture.Core.Entities.SMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IMessageReceiverRepository
    {
        //SMS
        Task<ICollection<ReceiverCategory>> GetCategories();
        Task<ICollection<MessageReceiverGroup>> GetGroups(int? pageCount = null, int? page = null, string search = null, int? createby = null);
        Task<MessageReceiverGroup> GetGroupById(int id);
        Task<MessageReceiverGroup> AddGroup(string name, ICollection<int> receivers, int createdby);
        Task<MessageReceiverGroup> UpdateGroup(int id, string name, ICollection<int> receivers);
        Task DeleteGroup(int id);
        Task<ICollection<MessageReceiver>> GetReceivers(int? pageCount = null, int? page = null, string search = null, int? groupid = null);
        Task<ICollection<MessageReceiver>> GetCustomerReceivers(int? pageCount = null, int? page = null, string search = null, int? groupid = null);
        Task<ICollection<MessageReceiver>> GetEmployeeReceivers(int? pageCount = null, int? page = null, string search = null, int? groupid = null);
        Task<MessageReceiver> GetReceiverById(int id);
        Task<MessageReceiver> AddCustomerReceiver(int customerid);
        Task<MessageReceiver> AddEmployeeReceiver(int employeeid);
        Task<MessageReceiver> AddReceiver(string fullname, string shortname, int category, int createdby);
        Task<MessageReceiver> UpdateReceiver(int id, MessageReceiver receiver);
        Task<MessageReceiver> DeleteReceiver(int id);

        Task<ReceiverProvider> AddReceiverProvider(int receiverid, int providerid, string address, int? createdby);
        Task<MessageServiceProvider> GetProviderById(int id);
    }
}
