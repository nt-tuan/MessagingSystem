using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.Accounts;
using CleanArchitecture.Core.Entities.Core;
using CleanArchitecture.Core.Entities.HR;
using CleanArchitecture.Core.Entities.Sales;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Infrastructure.Data.Exceptions;
using CleanArchitecture.Infrastructure.Data.Exceptions.Messages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Data
{
    public class CoreRepository : ICoreRepository
    {
        const int ORDER_ASC = 0;
        const int ORDER_DESC = 1;

        readonly IRepository _repos;
        readonly UserManager<AppUser> _userManager;
        readonly AppDbContext _db;
        public CoreRepository(IRepository repos, UserManager<AppUser> userManager, AppDbContext db)
        {
            _repos = repos;
            _userManager = userManager;
            _db = db;
        }

        public async Task AddDepartment(Department department, AppUser appUser)
        {
            await _repos.AddDetail(department, DateTime.Now, appUser);
        }

        public async Task<Employee> AddEmployee(Employee employee, AppUser appUser)
        {
            var time = DateTime.Now;
            var person = await _repos.GetById<Person>(employee.PersonId, time);
            if(person == null)
            {
                person = await _repos.AddDetail(employee.Person, time);
            }
            employee.PersonId = person.Id;
            employee.CreatedById = appUser.Id;
            await _repos.AddDetail(employee);
            return employee;
        }

        public async Task AddEmployeeAccount(int id, string username, AppUser appUser)
        {
            //var emp = await GetEmployee(id);
        }

        public async Task DeleteDepartment(int id, AppUser appUser)
        {
            var department = await GetDepartment(id);
            if(department != null)
            {
                await _repos.DeleteDetail<Department>(department, DateTime.Now, appUser);
            }
        }

        public async Task<Department> GetDepartment(int id)
        {
            var dept = await _repos.GetById<Department>(id, DateTime.Now);
            return dept;
        }

        public async Task<int> GetDepartmentCount(dynamic filter)
        {
            var count = await _repos.Count<Department>(filter:filter, time:DateTime.Now);
            return count;
        }

        public async Task<ICollection<Department>> GetDepartments(string search = null, int? page = 0, int? pageRows = 30, string orderby = "ASC", int? orderdir = 0, dynamic filter = null)
        {
            var list = await _repos.List<Department>(_db.Departments.Include(u => u.Parent),search, page, pageRows, orderby, orderdir, filter, DateTime.Now);
            return list;
        }

        public async Task<ICollection<Department>> GetDepartments(IQueryable<Department> query, string search = null, int? page = 0, int? pageRows = 30, string orderby = "ASC", int? orderdir = 0, dynamic filter = null)
        {
            var list = await _repos.List<Department>(query, search, page, pageRows, orderby, orderdir, filter, DateTime.Now);
            return list;
        }

            public async Task<Employee> GetEmployeeByCode(string code)
        {
            var employee = await _repos.List<Employee>(filter : new {Code = code }, at: DateTime.Now);
            return employee.Count > 0 ? employee[0] : null;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var query = _db.Employees.Include(u => u.Person);
            return await _repos.GetById<Employee>(query, id);
        }

        public async Task<int> GetEmployeeCount(dynamic filter)
        {
            return await _repos.Count<Employee>(filter);
        }

        public async Task<ICollection<Employee>> ListEmployees(string search, int? page, int? pageRows, string orderby, int? orderdir, dynamic filter)
        {
            //throw new NotImplementedException();
            var query = _db.Employees.Include(u => u.Person);
            var list = await _repos.List<Employee>(query, search, page, pageRows, orderby, orderdir, filter);
            return list;
        }

        public async Task DeleteEmployee(int id, AppUser appUser)
        {
            var emp = await _repos.GetById<Employee>(id, DateTime.Now);
            if (emp != null)
                await _repos.DeleteDetail(emp, DateTime.Now, appUser);
            else
                throw new EntityNotFound(typeof(Employee), emp);
        }

        public Task RevokeEmployeeAccount(int id, AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateDepartment(Department department, AppUser appUser)
        {
            await _repos.UpdateDetail(department, DateTime.Now, appUser);
        }

        public async Task UpdateEmployee(Employee updated, AppUser appUser)
        {
            await _repos.UpdateDetail(updated, DateTime.Now, appUser);
        }

        public async Task<IDictionary<int,Department>> GetDepartmentsTree()
        {
            var dict = new Dictionary<int, Department>();
            var list = await _repos.List<Department>(at: DateTime.Now);
            foreach (var item in list)
            {
                dict.Add(item.Id, item);
            }

            foreach(var item in dict)
            {
                if (item.Value.ParentId != null && dict.ContainsKey(item.Value.ParentId.Value))
                    item.Value.Parent = dict[item.Value.ParentId.Value];
            }
            return dict;
        }

        public async Task<Department> GetDepartmentById(int id)
        {
            return await _repos.GetById<Department>(id);
        }

        public async Task<Department> GetDepartmentTreeById(int id)
        {
            var set = new HashSet<int>();
            var dept = await _repos.GetById<Department>(id);
            var temp = dept;
            while (!set.Contains(temp.Id))
            {
                set.Add(temp.Id);
                if(temp.ParentId != null)
                {
                    var parent = await _repos.GetById<Department>(temp.ParentId.Value);
                    temp.Parent = parent;
                    temp = parent;
                }
            }
            return dept;
        }

        public async Task UpdateOrAddEmployeeByCode(Employee employee, AppUser appUser)
        {
            var empCount = await GetEmployeeByCode(employee.Code);
            if (empCount == null)
            {
                await AddEmployee(employee, appUser);
            }
            else
            {
                employee.OriginId = empCount.OriginId;
                employee.Id = empCount.Id;
                await UpdateEmployee(employee, appUser);
            }
        }

        public async Task UpdateOrAddDepartmentByCode(Department department, AppUser appUser)
        {
            var query = _db.Departments.AsNoTracking().Where(u => u.Code == department.Code);
            var deptCount = await GetDepartments(query: query);
            if(deptCount.Count > 0)
            {
                department.Id = deptCount.First().Id;
                department.OriginId = deptCount.First().OriginId;
                await UpdateDepartment(department, appUser);
            }
            else
            {
                await AddDepartment(department, appUser);
            }
        }
    }
}
