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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.Web.Api
{
    [Route("api/[controller]")]
    public class MessageController : Controller
    {
        readonly IMessageReceiverRepository _imessage;
        readonly ICoreRepository _icore;
        readonly IRepository _res;
        public MessageController(IMessageReceiverRepository imessage, ICoreRepository icore, IRepository res)
        {
            _imessage = imessage;
            _icore = icore;
            _res = res;
        }

        // GET: api/<controller>
        [HttpGet]
        [Route("ReceiverCategories")]
        public async Task<ICollection<ReceiverCategory>> Get()
        {
            return await _imessage.GetCategories(DateTime.Now);
            //return await _imessage.GetCategories();
        }

        [HttpGet]
        [Route("receivers")]
        public async Task<IActionResult> GetReceivers(TableParameter param)
        {
            return Ok(await _imessage.GetReceivers(param.search, param.page, param.pageSize, param.orderBy, param.orderDirection, param.filter, DateTime.Now));
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
