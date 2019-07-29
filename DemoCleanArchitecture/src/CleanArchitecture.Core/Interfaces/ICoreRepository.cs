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
        Task<ICollection<Employee>> GetEmployees(string search, int? page, int? pageRows, string orderby, int? orderdir, IDictionary<string,string> filter);
        Task<Employee> GetEmployee(string code);
        Task<Employee> GetEmployee(int id, bool throwException = false);
        Task<int> GetEmployeeCount(IDictionary<string, string> filter = null);
        Task AddEmployee(Employee employee);
        Task UpdateEmployee(int id, Employee updated);
        Task RemoveEmployee(int id);
        Task AddEmployeeAccount(int id, string username);
        Task RemoveEmployeeAccount(int id);
        Task<ICollection<Department>> GetDepartments(int? perpage = 30, int? page = 0, string search = null, string orderby = "code", int? orderdir = 0, IDictionary<string, string> fitler = null);
        Task<Department> GetDepartment(int id);
        Task<int> GetDepartmentCount();
        Task AddDepartment(Department department);
        Task UpdateDepartment(int id, Department department);
        Task DeleteDepartment(int id);
    }
}
