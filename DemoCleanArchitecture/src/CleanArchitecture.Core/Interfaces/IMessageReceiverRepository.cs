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
        /// <summary>
        /// Get collection of receiver category ["Customer","Employee",...]
        /// </summary>
        /// <returns></returns>
        Task<ICollection<ReceiverCategory>> GetCategories(DateTime? at);
        /// <summary>
        /// Get groups of receivers specified by pageCount: number records per page, page index, search string, group owner
        /// </summary>
        /// <param name="pageCount">Number of record per page. If valud is null, return all records</param>
        /// <param name="page">Page index. If page index is null, return all records</param>
        /// <param name="search">search string</param>
        /// <param name="createby">group owner</param>
        /// <returns></returns>
        Task<ICollection<MessageReceiverGroup>> GetGroups(string search = null, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = (int)BaseEntity.ListOrder.ASC, dynamic filter = null, DateTime? at = null);
        /// <summary>
        /// Get a group specified by its unique id
        /// </summary>
        /// <param name="id">id of group</param>
        /// <returns></returns>
        Task<MessageReceiverGroup> GetGroupById(int id, DateTime? at);
        /// <summary>
        /// Add a group
        /// </summary>
        /// <param name="name"></param>
        /// <param name="receivers"></param>
        /// <param name="createdby"></param>
        /// <returns></returns>
        Task<MessageReceiverGroup> AddGroup(MessageReceiverGroup group, AppUser actor, DateTime? at);
        /// <summary>
        /// Update  a group
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="receivers"></param>
        /// <returns></returns>
        Task<MessageReceiverGroup> UpdateGroup(MessageReceiverGroup group, AppUser actor, DateTime? at);
        /// <summary>
        /// Delete a group
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteGroup(int id, AppUser actor, DateTime? at);
        /// <summary>
        /// Get collection of receivers
        /// </summary>
        /// <param name="pageCount"></param>
        /// <param name="page"></param>
        /// <param name="search"></param>
        /// <param name="groupid"></param>
        /// <param name="cateid"></param>
        /// <returns></returns>
        Task<ICollection<MessageReceiver>> GetReceivers(string search = null, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = (int)BaseEntity.ListOrder.ASC, dynamic filter = null, DateTime? at = null);
        /// <summary>
        /// Get a receiver specified by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MessageReceiver> GetReceiverById(int id, DateTime? at);
        /// <summary>
        /// Add a receiver who is a customer
        /// </summary>
        /// <param name="customerid"></param>
        /// <returns></returns>
        Task<MessageReceiver> AddCustomerReceiver(Customer customer, AppUser actor, DateTime? at);
        /// <summary>
        /// Add a receiver who is an employee
        /// </summary>
        /// <param name="employeeid"></param>
        /// <returns></returns>
        Task<MessageReceiver> AddEmployeeReceiver(Employee employee, AppUser actor, DateTime? at);
        Task<MessageReceiver> AddReceiver(MessageReceiver receiver, AppUser actor, DateTime? at);
        Task<MessageReceiver> UpdateReceiver(MessageReceiver receiver, AppUser actor, DateTime? at);
        Task DeleteReceiver(int id, AppUser user, DateTime? at);

        Task<ReceiverProvider> AddReceiverProvider(ReceiverProvider provider, AppUser actor, DateTime? at);
        Task<MessageServiceProvider> GetProviderById(int id, bool throwException);
    }
}
