using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.Sales;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Core.Interfaces
{
    public interface ICoreRepository
    {
        Task<ICollection<Customer>> GetCustomers(int? distributorId, string search, int? page = 1, int? take = 30);
        Task<ICollection<Distributor>> GetDistributors();
    }
}
