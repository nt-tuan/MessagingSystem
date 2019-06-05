using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Entities.Accounts;
using CleanArchitecture.Core.Entities.HR;
using CleanArchitecture.Core.Entities.Sales;
using CleanArchitecture.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Data
{
    public class CoreRepository : ICoreRepository
    {
        AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public CoreRepository(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        public async Task<ICollection<Employee>> GetEmployees(int perpage = 30, int page = 0, string search = null, string orderby = "code", string orderdir = "asc", IDictionary<string, string> filter = null)
        {
            var query = _context.Employees.AsQueryable();
            if (!string.IsNullOrEmpty(search))
                query = query.Where(u => u.FullName.Contains(search));
            if (filter != null)
            {
                foreach (var item in filter)
                {
                    var property = typeof(Employee).GetProperty(item.Key);
                    var ptype = property.DeclaringType;
                    if (ptype == typeof(string))
                    {
                        query = query.Where(u => EF.Property<string>(u, item.Key) == item.Value);
                    }
                    else if (ptype == typeof(int))
                    {
                        query = query.Where(u => EF.Property<int>(u, item.Key) == int.Parse(item.Value));
                    }
                    else if (ptype == typeof(double))
                    {
                        query = query.Where(u => EF.Property<double>(u, item.Key) == double.Parse(item.Value));
                    }
                }
            }
            if (orderdir == "asc")
                query = query.OrderBy(u => orderby);
            else
                query = query.OrderByDescending(u => orderby);
            var total = await query.CountAsync();
            var list =
            await query.Skip(perpage * page).Take(perpage).ToListAsync();

            return list;
        }

        public async Task<Employee> GetEmployee(string code)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(u => !u.Removed && u.Code == code);
            return emp;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var emp = await _context.Employees.FirstOrDefaultAsync(u => !u.Removed && u.Id == id);
            return emp;
        }

        public async Task AddEmployee(Employee employee)
        {
            employee.Removed = false;
            employee.FullName = employee.FirstName + employee.LastName;
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
        }

        public async Task EditEmployee(int id, Employee updated)
        {
            var emp = await GetEmployee(id);
            if (emp != null)
            {
                updated.Id = id;
                _context.Entry<Employee>(updated).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return;
            }

            throw new Exception();
        }

        public async Task RemoveEmployee(int id)
        {
            var emp = await GetEmployee(id);
            if (emp != null)
            {
                _context.Entry(emp).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
                return;
            }

            throw new Exception();
        }

        public async Task AddEmployeeAccount(int id, string username)
        {
            var emp = await GetEmployee(id);
            if (emp != null)
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user == null)
                {
                    user = new AppUser
                    {
                        Email = emp.Email,
                        EmployeeId = emp.Id,
                        UserName = username,
                        EmailConfirmed = true
                    };
                    await _userManager.CreateAsync(user);
                    return;
                }
                throw new Exception("USER_EXIST");
            }
            throw new Exception("EMPLOYEE_NOT_FOUND");
        }

        public async Task RemoveEmployeeAccount(int id)
        {
            var user = await _userManager.Users.Include(u => u.Employee).Where(u => u.EmployeeId == id).FirstOrDefaultAsync();
            if (user != null)
            {
                user.EmployeeId = null;
                await _userManager.UpdateAsync(user);
                return;
            }
            throw new Exception("ACCOUNT_NOTFOUND");
        }

        public async Task<ICollection<Department>> GetDepartments(int perpage = 30, int page = 0, string search = null, string orderby = "code", string orderdir = "asc", IDictionary<string, string> filter = null)
        {
            var query = _context.Departments.AsQueryable();
            if (!string.IsNullOrEmpty(search))
                query = query.Where(u => !u.Removed && u.Code.Contains(search) || u.Name.Contains(search));
            if (filter != null)
            {
                foreach (var item in filter)
                {
                    var property = typeof(Department).GetProperty(item.Key);
                    var ptype = property.DeclaringType;
                    if (ptype == typeof(string))
                    {
                        query = query.Where(u => EF.Property<string>(u, item.Key) == item.Value);
                    }
                    else if (ptype == typeof(int))
                    {
                        query = query.Where(u => EF.Property<int>(u, item.Key) == int.Parse(item.Value));
                    }
                    else if (ptype == typeof(double))
                    {
                        query = query.Where(u => EF.Property<double>(u, item.Key) == double.Parse(item.Value));
                    }
                }
            }
            if (orderdir == "asc")
                query = query.OrderBy(u => orderby);
            else
                query = query.OrderByDescending(u => orderby);
            var list =
            await query.Skip(perpage * page).Take(perpage).ToListAsync();

            return list;
        }

        public async Task<Department> GetDepartment(int id)
        {
            var dept = await _context.Departments.FirstOrDefaultAsync(u => u.Id == id);
            return dept;
        }

        public async Task AddDepartment(Department department)
        {
            _context.Add(department);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDepartment(int id, Department updated)
        {
            var dept = GetDepartment(id);
            if (dept != null)
            {
                updated.Id = id;
                _context.Update(updated);
                await _context.SaveChangesAsync();
            }
            throw new Exception("DEPARTMENT_NOTFOUND");
        }

        public Task DeleteDepartment(int id)
        {
            var dept = GetDepartment(id);
            if (dept != null)
            {
                _context.Remove(dept);
            }
            throw new Exception("DEPARTMENT_NOTFOUND");
        }
    }
}
