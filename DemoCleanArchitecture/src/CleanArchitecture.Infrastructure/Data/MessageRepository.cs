using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.Accounts;
using CleanArchitecture.Core.Entities.Sales;
using CleanArchitecture.Core.Entities.Messaging;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Data.Exceptions;
using CleanArchitecture.Infrastructure.Data.Exceptions.Messages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities.HR;

namespace CleanArchitecture.Infrastructure.Data
{
    public class MessageReceiverRepository : IMessageReceiverRepository
    {
        const string CUSTOMER_CATEGORY = "KH";
        const string EMPLOYEE_CATEGORY = "NV";
        readonly AppDbContext _context;
        readonly ICoreRepository _core;
        readonly IRepository _res;
        public MessageReceiverRepository(AppDbContext context, ICoreRepository icore, IRepository res)
        {
            _context = context;
            _core = icore;
            _res = res;
        }

        public async Task<ReceiverCategory> AddCategory(ReceiverCategory cate, AppUser appUser)
        {
            var entity = await _res.AddDetail(cate, DateTime.Now, appUser);
            return entity;
        }

        public async Task<MessageReceiver> AddCustomerReceiver(Customer customer, AppUser actor, DateTime? at)
        {
            //Get customer
            Customer qcus = null;
            if (customer == null)
            {
                throw new EntityNotFound(typeof(Customer), customer.Id);
            }

            var receiver = new MessageReceiver();
            receiver.FullName = qcus.Person.FullName;
            receiver.ShortName = qcus.Person.DisplayName;
            receiver.CustomerId = qcus.Id;
            var entity = await _res.AddDetail(receiver, DateTime.Now, actor);
            return entity;
        }

        public async Task<MessageReceiver> AddEmployeeReceiver(Employee employee, AppUser actor, DateTime? at)
        {
            var emp = await _core.GetEmployeeById(employee.Id);
            if (emp == null)
            {
                throw new EntityNotFound(typeof(Employee), employee.Id);
            }
            var receiver = new MessageReceiver();
            receiver.FullName = emp.Person.FullName;
            receiver.ShortName = emp.Person.DisplayName;
            receiver.EmployeeId = emp.Id;
            var entity = await _res.AddDetail(receiver, DateTime.Now, actor);
            return entity;
        }

        public async Task<MessageReceiverGroup> AddGroup(MessageReceiverGroup group, AppUser actor, DateTime? at)
        {
            var entity = await _res.AddDetail(group, DateTime.Now, actor);
            return entity;
        }

        public async Task<MessageReceiver> AddReceiver(MessageReceiver receiver, AppUser actor, DateTime? at)
        {
            var entity = await _res.AddDetail(receiver, at, actor);
            return entity;
        }

        public async Task<ReceiverProvider> AddReceiverProvider(ReceiverProvider provider, AppUser actor, DateTime? at)
        {
            return await _res.AddDetail(provider, at, actor);
        }

        public async Task DeleteCategory(ReceiverCategory cate, AppUser appUser)
        {
            //throw new NotImplementedException();
            await _res.DeleteDetail(cate, DateTime.Now, appUser);
        }

        public async Task DeleteGroup(int id, AppUser actor, DateTime? at)
        {
            var group = await _res.GetById<MessageReceiverGroup>(id, DateTime.Now);
            await _res.DeleteDetail(group, at, actor);
        }

        public async Task DeleteReceiver(int id, AppUser user, DateTime? at)
        {
            var receiver = await _res.GetById<MessageReceiver>(id, at);
            await _res.DeleteDetail(receiver);
        }

        public async Task<ICollection<ReceiverCategory>> GetCategories(DateTime? at)
        {
            var list = await _res.List<ReceiverCategory>(at: at);
            return list;
        }

        public async Task<MessageReceiverGroup> GetGroupById(int id, DateTime? at)
        {
            var group = await _res.GetById<MessageReceiverGroup>(id, at);
            return group;
        }

        public async Task<ICollection<MessageReceiverGroup>> GetGroups(string search = null, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = 1, dynamic filter = null, DateTime? at = null)
        {
            var groups = await _res.List<MessageReceiverGroup>(search, page, pageRows, orderby, orderdir, filter, at);
            return groups;
        }

        public async Task<MessageServiceProvider> GetProviderById(int id, bool throwException)
        {
            return await _res.GetById<MessageServiceProvider>(id, DateTime.Now);
        }

        public async Task<List<MessageServiceProvider>> GetProviders(DateTime? at)
        {
            return await _res.List<MessageServiceProvider>(at: at);
        }

        public async Task<MessageReceiver> GetReceiverById(int id, DateTime? at)
        {
            return await _res.GetById<MessageReceiver>(id, at);
        }

        public async Task<ICollection<MessageReceiver>> GetReceivers(string search = null, int? page = null, int? pageRows = null, string orderby = "Id", int? orderdir = 1, dynamic filter = null, DateTime? at = null)
        {
            return await _res.List<MessageReceiver>(search, page, pageRows, orderby, orderdir, filter, at);
        }

        public async Task UpdateCategory(ReceiverCategory cate, AppUser appUser)
        {
            await _res.UpdateDetail<ReceiverCategory>(cate, DateTime.Now, appUser);
        }

        public async Task UpdateGroup(MessageReceiverGroup group, AppUser actor, DateTime? at)
        {
            await _res.UpdateDetail(group, at, actor);
        }

        public async Task UpdateReceiver(MessageReceiver receiver, AppUser actor, DateTime? at)
        {
            await _res.UpdateDetail(receiver, at, actor);
        }
        /*
//helps
public async Task<ReceiverCategory> GetCategory(string code, bool throwException = false)
{
var entity = await _context.ReceiverCategories.FirstOrDefaultAsync(u => u.Code == code);
if (entity == null && throwException)
throw new EntityNotFound(typeof(ReceiverCategory), code);
return entity;
}

//Add a message receiver who is a customer. If that customer has a phone number, add receiver Messaging provider infomation.
public async Task<MessageReceiver> AddCustomerReceiver(int customerid, int? user)
{
var e = await _icore.GetCustomer(customerid, true);
var cate = await GetCategory(CUSTOMER_CATEGORY, true);

var receiver = new MessageReceiver
{
FullName = e.Fullname,
ShortName = e.Shortname,
ReceiverCategoryId = cate.Id,
CustomerId = customerid,
CreatedTime = DateTime.Now,
CreatedBy = user
};
await _context.AddAsync(receiver);

if (!String.IsNullOrEmpty(e.Phone))
await AddReceiverProvider(receiver.Id, 1, e.Phone, null);
return receiver;
}

public async Task<MessageReceiver> AddEmployeeReceiver(int employeeid, int? user)
{
var emp = await _icore.GetEmployee(employeeid, true);
var category = await GetCategory(EMPLOYEE_CATEGORY, true);

var receiver = new MessageReceiver
{
FullName = emp.FullName,
ShortName = emp.GetShortName(),
ReceiverCategoryId = category.Id,
EmployeeId = employeeid,
CreatedTime = DateTime.Now,
CreatedBy = user
};
await _context.AddAsync(receiver);

if (!String.IsNullOrEmpty(emp.Phone))
await AddReceiverProvider(receiver.Id, 1, emp.Phone, null);
return receiver;
}

public async Task<MessageReceiverGroup> AddGroup(string name, ICollection<int> receivers, int createdby)
{
var group = new MessageReceiverGroup
{
Name = name,
CreatedTime = DateTime.Now,
CreatedBy = createdby
};
await _context.AddAsync(group);
await UpdateReceiversInGroup(group, receivers);
return group;
}

public async Task<MessageReceiver> AddReceiver(string fullname, string shortname, int category, int? createdby)
{
var receiver = new MessageReceiver
{
FullName = fullname,
ShortName = shortname,
CreatedTime = DateTime.Now,
CreatedBy = createdby,
ReceiverCategoryId = category
};
await _context.AddAsync(receiver);

return receiver;
}

public async Task DeleteGroup(int id)
{
var group = await GetGroupById(id, throwException:true);
group.Removed = true;
var processedgroup = await _context.AutoMessageConfigDetailsMessageReceiverGroups.CountAsync(u => u.MessageReceiverGroupId == id);
if(processedgroup == 0)
{
_context.Remove(group);
await _context.SaveChangesAsync();
return;
}
_context.MessageReceiverGroups.Update(group);
await _context.SaveChangesAsync();
}

public async Task DeleteReceiver(int id, int? createdby)
{
var receiver = await GetReceiverById(id, throwException: true);
receiver.Removed = true;
receiver.RemovedBy = createdby;
var sentmessagesCount = await _context.SentMessages.CountAsync(u => u.ReceiverProvider.MessageReceiverId == id);
var automessageCount = await _context.AutoMesasgeConfigDetailsMessageReceivers.CountAsync(u => u.MessageReceiverId == id);
var automessageGroupCount = await _context.AutoMessageConfigDetailsMessageReceiverGroups.CountAsync(u => u.MessageReceiveGroup.MessageReceiverGroupMessageReceivers.Any(v => v.MessageReceiverId == id));
if(sentmessagesCount == 0 && automessageCount == 0 && automessageGroupCount == 0)
{
//delete receiver provider first
var provider = await _context.ReceiverProviders.Where(u => u.MessageReceiverId == id).ToListAsync();
_context.RemoveRange(provider);
await _context.SaveChangesAsync();
//delte receiver in groups
var groups = await _context.MessageReceiverGroupMessageReceivers.Where(u => u.MessageReceiverId == id).ToListAsync();
_context.RemoveRange(groups);
await _context.SaveChangesAsync();
//then delete receiver
_context.Remove(receiver);
await _context.SaveChangesAsync();
return;
}
_context.Update(receiver);
await _context.SaveChangesAsync();
}

public async Task<ICollection<ReceiverCategory>> GetCategories()
{
return await _context.ReceiverCategories.ToListAsync();
}


public async Task<MessageReceiverGroup> GetGroupById(int id, bool throwException = false)
{
var group = await _context.MessageReceiverGroups.FirstOrDefaultAsync(u => u.Id == id && !u.Removed);
if (group == null && throwException)
throw new EntityNotFound(typeof(MessageReceiverGroup), id);
return group;
}

public async Task<ICollection<MessageReceiverGroup>> GetGroups(int? pageCount = null, int? page = null, string search = null, int? createby = null)
{
var query = _context.MessageReceiverGroups.Where(u => !u.Removed);
if (createby != null)
query = query.Where(u => u.CreatedBy == createby);
if (!string.IsNullOrEmpty(search))
{
query = query.Where(u => u.Name.Contains(search));
}
if(pageCount != null && page != null)
{
query = query.OrderBy(u => u.Name).Take(pageCount.Value).Skip(page.Value * pageCount.Value);
}
var collection = await query.ToListAsync();
return collection;
}

public async Task<MessageReceiver> GetReceiverById(int id, bool throwException = false)
{
var receiver = await _context.MessageReceivers.FirstOrDefaultAsync(u => u.Id == id && !u.Removed);
if (receiver == null && throwException)
throw new EntityNotFound(typeof(MessageReceiver), id);
return receiver;
}

public async Task<ICollection<MessageReceiver>> GetReceivers(int? pageCount = null, int? page = null, string search = null, int? groupid = null, int? cateid = null)
{
var query = _context.MessageReceivers.Where(u => !u.Removed);
if (!string.IsNullOrEmpty(search))
query = query.Where(u => u.FullName.Contains(search));
if (groupid != null)
query = query.Where(u => u.MessageReceiverGroupMessageReceivers.Any(v => v.MessageReceiverGroupId == groupid.Value));
if (cateid != null)
query = query.Where(u => u.ReceiverCategoryId == cateid);
return await query.ToListAsync();
}

public async Task<MessageReceiverGroup> UpdateGroup(int id, string name, ICollection<int> receivers)
{
var group = await GetGroupById(id, throwException: true);
group.Name = name;
_context.Update(group);
await _context.SaveChangesAsync();
await UpdateReceiversInGroup(group, receivers);
return group;
}

public async Task UpdateReceiversInGroup(MessageReceiverGroup group, ICollection<int> receivers)
{
var mr = new List<MessageReceiverGroupMessageReceiver>();
foreach (var item in receivers)
{
var receiver = new MessageReceiverGroupMessageReceiver
{
  MessageReceiverId = item,
  MessageReceiverGroupId = group.Id
};
mr.Add(receiver);
}
await _context.AddRangeAsync(mr);
}

public async Task<MessageReceiver> UpdateReceiver(int id, MessageReceiver receiver, int? modifiedby)
{
var current = await GetReceiverById(id, throwException: true);
current.FullName = receiver.FullName;
current.ShortName = receiver.ShortName;
current.LastModifiedBy = modifiedby;
_context.Update(current);
await _context.SaveChangesAsync();
return current;
}

public async Task<ReceiverProvider> AddReceiverProvider(int receiverid, int providerid, string address, int? createdby)
{
var receiver = await GetReceiverById(receiverid, throwException:true);
var provider = await GetProviderById(providerid, throwException: true);

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

public async Task<MessageServiceProvider> GetProviderById(int id, bool throwException = false)
{
var pr = await _context.MessageServiceProviders.FirstOrDefaultAsync(u => u.Id == id && !u.Removed);
if(pr == null && throwException)
{
throw new EntityNotFound(typeof(MessageServiceProvider), id);
}
return pr;
}
*/
    }
}
