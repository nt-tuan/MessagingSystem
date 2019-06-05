using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.HR;
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
        Task<ICollection<Employee>> GetEmployees(int perpage = 30, int page = 0, string search = null, string orderby = "code", string orderdir = "asc", IDictionary<string,string> fitler = null);
        Task<Employee> GetEmployee(string code);
        Task<Employee> GetEmployee(int id);
        Task AddEmployee(Employee employee);
        Task EditEmployee(int id, Employee updated);
        Task RemoveEmployee(int id);
        Task AddEmployeeAccount(int id, string username);
        Task RemoveEmployeeAccount(int id);
        Task<ICollection<Department>> GetDepartments(int perpage = 30, int page = 0, string search = null, string orderby = "code", string orderdir = "asc", IDictionary<string, string> fitler = null);
        Task<Department> GetDepartment(int id);
        Task AddDepartment(Department department);
        Task UpdateDepartment(int id, Department department);
        Task DeleteDepartment(int id);
    }
}
