using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.Core;
using CleanArchitecture.Core.Entities.HR;
using CleanArchitecture.Core.Entities.Sales;
using CleanArchitecture.Core.SharedKernel;
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
        Task<Employee> AddEmployee(Employee employee);
        Task UpdateEmployee(int id, Employee updated);
        Task RemoveEmployee(int id);
        Task AddEmployeeAccount(int id, string username);
        Task RemoveEmployeeAccount(int id);

        
        
        Task<ICollection<Department>> GetDepartments(string search, int? page, int? pageRows, string orderby, int? orderdir, IDictionary<string, string> filter);
        Task<Department> GetDepartment(int id);
        Task<int> GetDepartmentCount(IDictionary<string, string> filter);
        Task AddDepartment(Department department);
        Task UpdateDepartment(int id, Department department);
        Task DeleteDepartment(int id);
    }
}
