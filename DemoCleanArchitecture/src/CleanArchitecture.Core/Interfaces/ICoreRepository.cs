using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.Accounts;
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
        #region Employee
        Task<ICollection<Employee>> ListEmployees(string search, int? page, int? pageRows, string orderby, int? orderdir, dynamic filter);
        Task<Employee> GetEmployeeByCode(string code);
        Task<Employee> GetEmployeeById(int id);
        Task<int> GetEmployeeCount(dynamic filter = null);
        Task<Employee> AddEmployee(Employee employee);
        Task UpdateEmployee(Employee updated, AppUser appUser);
        Task DeleteEmployee(int id, AppUser appUser);
        Task AddEmployeeAccount(int id, string username, AppUser appUser);
        Task RevokeEmployeeAccount(int id, AppUser appUser);
        //End employee interface
        #endregion 
        #region Department
        Task<ICollection<Department>> GetDepartments(string search, int? page, int? pageRows, string orderby, int? orderdir, dynamic filter);
        Task<IDictionary<int,Department>> GetDepartmentsTree();
        Task<Department> GetDepartmentById(int id);
        Task<Department> GetDepartmentTreeById(int id);
        Task<int> GetDepartmentCount(dynamic filter);
        Task AddDepartment(Department department, AppUser appUser);
        Task UpdateDepartment(Department department, AppUser appUser);
        Task DeleteDepartment(int id, AppUser appUser);
        #endregion
    }
}
