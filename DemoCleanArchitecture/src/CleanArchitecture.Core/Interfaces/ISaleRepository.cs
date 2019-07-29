using CleanArchitecture.Core.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    interface ISaleRepository
    {
        Task<Customer> GetCustomer(int id, bool throwException = false);
        Task<ICollection<Customer>> GetCustomers(string search, int? page = 1, int? pageRows = 30, string orderby = null, int? orderdir = null, Dictionary<string,string> filter = null);
        Task<ICollection<Distributor>> GetDistributors();
    }
}
