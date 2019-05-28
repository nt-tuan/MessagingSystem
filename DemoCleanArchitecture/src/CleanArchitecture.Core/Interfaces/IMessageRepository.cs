using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.SMS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface IMessageRepository
    {
        //Customer interfaces
        Task<List<Customer>> GetCustomers(int? distributor = null, string name = null);
        Customer UpdateCustomer(Customer customer);
        Customer AddCustomer(Customer customer);

        //SMS
        Task<List<ReceiverCategory>> GetCategories();        
    }
}
