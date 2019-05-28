using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.SMS;
using CleanArchitecture.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Data
{
    public class MessageRepository : IMessageRepository
    {
        AppDbContext _context;
        public MessageRepository(AppDbContext context)
        {
            _context = context;
        }

        public Customer AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ReceiverCategory>> GetCategories()
        {
            return await _context.ReceiverCategory.ToListAsync();
        }

        public async Task<List<Customer>> GetCustomers(int? distributor = null, string name = null)
        {
            var lst = new List<Customer>();
            lst.Add(new Customer
            {
                Code = "ASBDA",
                Fullname = "Nhà thuốc 123",
                Shortname = "Nt123"
            });
            return lst;
        }

        public Customer UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
