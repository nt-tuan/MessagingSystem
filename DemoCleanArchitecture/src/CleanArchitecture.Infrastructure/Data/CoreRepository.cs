using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.Sales;
using CleanArchitecture.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Data
{
    public class CoreRepository : ICoreRepository
    {
        AppDbContext _context;
        public CoreRepository(AppDbContext context)
        {
            _context = context;
        }

        public Task<ICollection<Customer>> GetCustomers(int? distributorId, string search, int? page = 1, int? take = 30)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Distributor>> GetDistributors()
        {
            throw new NotImplementedException();
        }
    }
}
