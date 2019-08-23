using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.Sales;
using CleanArchitecture.Core.Entities.Messaging;
using CleanArchitecture.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Web.ApiModels;
using CleanArchitecture.Web.ApiModels.Messaging;
using Microsoft.AspNetCore.Identity;
using CleanArchitecture.Core.Entities.Accounts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.Web.Api
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        readonly IMessageReceiverRepository _imessage;
        readonly ICoreRepository _icore;
        readonly IRepository _res;
        readonly UserManager<AppUser> _userManager;
        public MessageController(IMessageReceiverRepository imessage, ICoreRepository icore, IRepository res, UserManager<AppUser> userManager)
        {
            _imessage = imessage;
            _icore = icore;
            _res = res;
            _userManager = userManager;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("ReceiverCategories")]
        public async Task<ICollection<ReceiverCategory>> Get()
        {
            return await _imessage.GetCategories(DateTime.Now);
            //return await _imessage.GetCategories();
        }

        [HttpPost]
        [Route("receivers")]
        public async Task<IActionResult> GetReceivers(TableParameter param)
        {
            var model = (await _imessage.GetReceivers(param.search, param.page, param.pageSize, param.orderBy, param.orderDirection, param.filter, DateTime.Now)).Select(u => new MessageReceiverModel(u));
            return Ok(new ResponseModel(model));
        }

        [HttpPost]
        [Route("AddCustomerReceiver/{id}")]
        public async Task<IActionResult> AddCustomerReceiver(int id)
        {
            var customer = await _res.GetById<Customer>(id, DateTime.Now);
            if (customer == null)
                return NotFound();

            var receiver = await _imessage.AddCustomerReceiver(customer, await _userManager.GetUserAsync(User), DateTime.Now);
            var model = new MessageReceiverModel(receiver);
            return Ok(new ResponseModel(model));
        }

        [HttpPost]
        [Route("AddEmployeeReceiver/{id}")]
        public async Task<IActionResult> AddEmployeeReceiver(int id)
        {
            var employee = await _icore.GetEmployeeById(id);
            if (employee == null)
                return NotFound();
            var receiver = await _imessage.AddEmployeeReceiver(employee, await _userManager.GetUserAsync(User), DateTime.Now);
            var model = new MessageReceiverModel(receiver);
            return Ok(new ResponseModel(model));
        }

        [HttpPost]
        [Route("AddReceiverProvider/{id}")]
        public async Task<IActionResult> AddReceiverProvider(int id, ReceiverProviderModel model)
        {
            var receiver = await _imessage.GetReceiverById(id, DateTime.Now);
            if (receiver == null)
                return NotFound();
            var entity = new ReceiverProvider
            {
                MessageReceiverId = receiver.OriginId ?? receiver.Id,
                ReceiverAddress = model.receiverAddress,
                MessageServiceProviderId = model.provider.id
            };
            var result = await _imessage.AddReceiverProvider(entity, await _userManager.GetUserAsync(User), DateTime.Now);
            var resultModel = new ReceiverProviderModel(result);
            return Ok(new ResponseModel(resultModel));
        }

        [HttpPost]
        [Route("DeleteReceiverProvider/{id}")]
        public async Task<IActionResult> DeleteReceiverProvider(int id)
        {
            await _imessage.DeleteReceiverProvider(id, await _userManager.GetUserAsync(User), DateTime.Now);
            return Ok();
        }

        [HttpPost]
        [Route("DeleteReceiver/{id}")]
        public async Task<IActionResult>DeleteReceiver(int id)
        {
            await _imessage.DeleteReceiver(id, await _userManager.GetUserAsync(User), DateTime.Now);
            return Ok();
        }

        [HttpGet]
        [Route("customers")]
        public async Task<ICollection<Customer>> Customers()
        {
            return null;
            //return await _icore.GetCustomers(null, "");
        }
    }
}
