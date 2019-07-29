using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.Accounts;
using CleanArchitecture.Core.Entities.Sales;
using CleanArchitecture.Core.Entities.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IMessageReceiverRepository
    {
        /// <summary>
        /// Get collection of receiver category ["Customer","Employee",...]
        /// </summary>
        /// <returns></returns>
        Task<ICollection<ReceiverCategory>> GetCategories();
        /// <summary>
        /// Get groups of receivers specified by pageCount: number records per page, page index, search string, group owner
        /// </summary>
        /// <param name="pageCount">Number of record per page. If valud is null, return all records</param>
        /// <param name="page">Page index. If page index is null, return all records</param>
        /// <param name="search">search string</param>
        /// <param name="createby">group owner</param>
        /// <returns></returns>
        Task<ICollection<MessageReceiverGroup>> GetGroups(int? pageCount = null, int? page = null, string search = null, int? createby = null);
        /// <summary>
        /// Get a group specified by its unique id
        /// </summary>
        /// <param name="id">id of group</param>
        /// <returns></returns>
        Task<MessageReceiverGroup> GetGroupById(int id, bool throwException = false);
        /// <summary>
        /// Add a group
        /// </summary>
        /// <param name="name"></param>
        /// <param name="receivers"></param>
        /// <param name="createdby"></param>
        /// <returns></returns>
        Task<MessageReceiverGroup> AddGroup(string name, ICollection<int> receivers, int createdby);
        /// <summary>
        /// Update  a group
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="receivers"></param>
        /// <returns></returns>
        Task<MessageReceiverGroup> UpdateGroup(int id, string name, ICollection<int> receivers);
        /// <summary>
        /// Delete a group
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteGroup(int id);
        /// <summary>
        /// Get collection of receivers
        /// </summary>
        /// <param name="pageCount"></param>
        /// <param name="page"></param>
        /// <param name="search"></param>
        /// <param name="groupid"></param>
        /// <param name="cateid"></param>
        /// <returns></returns>
        Task<ICollection<MessageReceiver>> GetReceivers(int? pageCount = null, int? page = null, string search = null, int? groupid = null, int? cateid = null);
        /// <summary>
        /// Get a receiver specified by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<MessageReceiver> GetReceiverById(int id, bool throwException);
        /// <summary>
        /// Add a receiver who is a customer
        /// </summary>
        /// <param name="customerid"></param>
        /// <returns></returns>
        Task<MessageReceiver> AddCustomerReceiver(int customerid, int? createdby);
        /// <summary>
        /// Add a receiver who is an employee
        /// </summary>
        /// <param name="employeeid"></param>
        /// <returns></returns>
        Task<MessageReceiver> AddEmployeeReceiver(int employeeid, int? createdby);
        Task<MessageReceiver> AddReceiver(string fullname, string shortname, int category, int? createdby);
        Task<MessageReceiver> UpdateReceiver(int id, MessageReceiver receiver, int? createdby);
        Task DeleteReceiver(int id, int? createdby);

        Task<ReceiverProvider> AddReceiverProvider(int receiverid, int providerid, string address, int? createdby);
        Task<MessageServiceProvider> GetProviderById(int id, bool throwException);
    }
}
