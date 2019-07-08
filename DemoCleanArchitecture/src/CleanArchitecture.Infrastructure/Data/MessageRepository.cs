using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.Sales;
using CleanArchitecture.Core.Entities.SMS;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Data.Exceptions;
using CleanArchitecture.Infrastructure.Data.Exceptions.Messages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Data
{
    public class MessageReceiverRepository : IMessageReceiverRepository
    {
        const string CUSTOMER_CATEGORY = "KH";
        const string EMPLOYEE_CATEGORY = "NV";
        readonly AppDbContext _context;
        readonly ICoreRepository _icore;
        public MessageReceiverRepository(AppDbContext context, ICoreRepository icore)
        {
            _context = context;
            _icore = icore;
        }

        //helps
        public async Task<ReceiverCategory> GetCategory(string code)
        {
            return await _context.ReceiverCategories.FirstOrDefaultAsync(u => u.Code == code);
        }
           
        //Add a message receiver who is a customer. If that customer has a phone number, add receiver sms provider infomation.
        public async Task<MessageReceiver> AddCustomerReceiver(int customerid)
        {
            var e = await _icore.GetEmployee(customerid);
            var cate = await GetCategory(CUSTOMER_CATEGORY);
            if (e != null && cate != null)
            {
                var receiver = new MessageReceiver
                {
                    FullName = e.FullName,
                    ShortName = e.GetShortName(),
                    ReceiverCategoryId = cate.Id,
                    CreatedBy = null
                };
                _context.Update(receiver);
                await _context.SaveChangesAsync();

                if (!String.IsNullOrEmpty(e.Phone))
                    await AddReceiverProvider(receiver.Id, 1, e.Phone, null);
            }
            throw new Exception();
        }

        public Task<MessageReceiver> AddEmployeeReceiver(int employeeid)
        {
            throw new NotImplementedException();
        }

        public Task<MessageReceiverGroup> AddGroup(string name, ICollection<int> receivers, int createdby)
        {
            throw new NotImplementedException();
        }

        public Task<MessageReceiver> AddReceiver(string fullname, string shortname, int category, int createdby)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGroup(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageReceiver> DeleteReceiver(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<ReceiverCategory>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<MessageReceiver>> GetCustomerReceivers(int? pageCount = null, int? page = null, string search = null, int? groupid = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<MessageReceiver>> GetEmployeeReceivers(int? pageCount = null, int? page = null, string search = null, int? groupid = null)
        {
            throw new NotImplementedException();
        }

        public Task<MessageReceiverGroup> GetGroupById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<MessageReceiverGroup>> GetGroups(int? pageCount = null, int? page = null, string search = null, int? createby = null)
        {
            throw new NotImplementedException();
        }

        public Task<MessageReceiver> GetReceiverById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<MessageReceiver>> GetReceivers(int? pageCount = null, int? page = null, string search = null, int? groupid = null)
        {
            throw new NotImplementedException();
        }

        public Task<MessageReceiverGroup> UpdateGroup(int id, string name, ICollection<int> receivers)
        {
            throw new NotImplementedException();
        }

        public Task<MessageReceiver> UpdateReceiver(int id, MessageReceiver receiver)
        {
            throw new NotImplementedException();
        }

        public async Task<ReceiverProvider> AddReceiverProvider(int receiverid, int providerid, string address, int? createdby)
        {
            var receiver = await GetReceiverById(receiverid);
            var provider = await GetProviderById(providerid);
            if (provider == null)
                throw new ProviderNotFoundException();

            if (receiver == null)
                throw new ReceiverNotFoundException();

            if (!provider.IsValidAddress(address))
                throw new InvalidReceiverAddressException(address, provider);

            var rp = new ReceiverProvider 
            {
                MessageReceiverId = receiverid,
                MessageServiceProviderId = providerid,
                ReceiverAddress = address
            };

            _context.Update(rp);
            await _context.SaveChangesAsync();

            return rp;
        }

        public async Task<MessageServiceProvider> GetProviderById(int id)
        {
            return await _context.MessageServiceProviders.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
