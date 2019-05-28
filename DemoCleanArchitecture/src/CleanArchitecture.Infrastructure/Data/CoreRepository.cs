using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.HR;
using CleanArchitecture.Core.Entities.Sales;
using CleanArchitecture.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        async Task<Department> loadChildren(Department entity)
        {
            var q = new Queue<Department>();
            var flags = new HashSet<int>();
            q.Enqueue(entity);
            flags.Add(entity.Id);
            while (q.Count > 0)
            {
                var first = q.Dequeue();
                await _context.Entry(first).Collection(u => u.Children).LoadAsync();
                foreach (var item in first.Children)
                {
                    if (!flags.Contains(item.Id))
                    {
                        q.Enqueue(item);
                        flags.Add(item.Id);
                    }
                }
            }
            return entity;
        }

        

        //end support functions
        public async Task<Employee> GetEmployeeDetails(int id)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.Id == id && !m.Removed);
            return employee;
        }

        public async Task<Employee> GetEmployeeDetails(string code)
        {
            var employee = await _context.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(m => m.Code == code && !m.Removed);
            return employee;
        }
    }
}
