using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Web.ApiModels;
using CleanArchitecture.Web.ApiModels.HR;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Core.Entities.HR;
using Microsoft.AspNetCore.Identity;
using CleanArchitecture.Core.Entities.Accounts;
using DmcSupport.DI;
using NPOI.SS.UserModel;

namespace CleanArchitecture.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRController : ControllerBase
    {
        AppDbContext _context;
        ICoreRepository _coreRep;
        IRepository _repos;
        SignInManager<AppUser> _signInManager;
        UserManager<AppUser> _userManager;
        public HRController(AppDbContext context, ICoreRepository coreRep, IRepository repos, SignInManager<AppUser> signinManager, UserManager<AppUser> userManager)
        {
            _context = context;
            _coreRep = coreRep;
            _repos = repos;
            _signInManager = signinManager;
            _userManager = userManager;  
        }

        async Task<AppUser> getCurrentUser()
        {
            return await _userManager.GetUserAsync(User);
        }

        #region EMPLOYEE
        [HttpPost]
        [Route("emp")]
        public async Task<IActionResult> Employees(TableParameter param)
        {

            var list = await _coreRep.ListEmployees(param.search, param.pageSize, param.page, param.orderBy, param.orderDirection, param.filter);
            var count = await _coreRep.GetEmployeeCount(param.filter);
            return Ok(new
            ResponseModel(new
            {
                emps = list.Select(u => new EmployeeModel(u)),
                total = count
            }));
        }

        [HttpPost]
        [Route("emp/{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var emp = await _coreRep.GetEmployeeById(id);
            if (emp != null)
            {
                return Ok(new ResponseModel(new
                EmployeeModel(emp)));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("emp/update/{id}")]
        public async Task<IActionResult> UpdateEmployee(EmployeeModel model)
        {
            var appUser = await getCurrentUser();
            var entity = model.ToEmployee();
            await _coreRep.UpdateEmployee(entity, appUser);
            return Ok(new ResponseModel(new
            {
                result = true
            }));
        }

        [HttpPost]
        [Route("emp/delete")]
        public async Task<IActionResult> DeleteEmployees(IntCollectionModel model)
        {
            foreach (var id in model.collection)
            {
                await _coreRep.DeleteEmployee(id, await getCurrentUser());
            }
            return Ok(new ResponseModel());
        }

        [HttpPost]
        [Route("emp/add")]
        public async Task<IActionResult> AddEmployee(EmployeeModel model)
        {
            var entity = model.ToEmployee();
            await _coreRep.AddEmployee(entity, await getCurrentUser());
            return Ok(new ResponseModel(new { result = true }));
        }

        [Route("ReviewEmployeesExcel")]
        public async Task<IActionResult> ReadEmployeeExcel()
        {
            var file = Request.Form.Files[0];
            var rs = new List<EmployeeErrorableModel>();
            await FileHelper.scanExcel(file, 6, async (header, row) =>
            {
                var employee = new EmployeeErrorableModel();
                try { 
                    for(var i=0; i < header.Cells.Count; i++)
                    {
                        await employee.UpdateEmployeeFromCell(header.Cells[i].StringCellValue, row.Cells[i], 
                            async (p) =>
                            {
                                return await _coreRep.ListEmployees(filter: p);
                            }, async (p) => {
                                return await _coreRep.GetDepartments(filter: p);
                            });
                    }
                }
                catch (Exception e)
                {
                    employee.messages.Add(MessageModel.CreateError(e.Message));
                }
                rs.Add(employee);
            });
            return Ok(new ResponseModel(rs));
        }        

        [Route("UpdateEmployeesExcel")]
        public async Task<IActionResult> UploadEmployeeExcel(ICollection<EmployeeModel> employees)
        {
            var entities = employees.Select(u => u.ToEmployee());
            var rs = new List<EmployeeErrorableModel>();
            foreach (var item in entities)
            {
                try
                {
                    await _coreRep.UpdateOrAddEmployeeByCode(item, await getCurrentUser());
                }
                catch (Exception e)
                {
                    var irs = new EmployeeErrorableModel(item);
                    irs.messages.Add(MessageModel.CreateError(e.Message));
                }
            }
            return Ok(new ResponseModel(rs));
        }
        #endregion

        #region DEPARTMENT
        [HttpPost]
        [Route("dept/{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var dept = await _coreRep.GetDepartmentById(id);
            return Ok(new ResponseModel(new DepartmentModel(dept)));
        }

        [HttpPost]
        [Route("depts")]
        public async Task<IActionResult> GetDepartments(TableParameter param)
        {
            var depts = await _coreRep.GetDepartments(param.search, param.pageSize, param.page, param.orderBy, param.orderDirection, param.filter);

            var count = await _coreRep.GetDepartmentCount(param.filter);
            return Ok(new ResponseModel(new
            {
                depts = depts.Select(u => new DepartmentModel(u)),
                total = count
            }));
        }

        [HttpPost]
        [Route("dept/update/{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, DepartmentModel model)
        {
            var entity = new Department
            {
                Id = id,
                Code = model.code,
                FullName = model.name,
                ShortName = model.shortname,
                ParentId = model.parentId,
                ManagerId = model.managerId
            };
            await _coreRep.UpdateDepartment(entity, await getCurrentUser());
            return Ok(new ResponseModel(new
            {
                result = true
            }));
        }

        [HttpPost]
        [Route("dept/delete")]
        public async Task<IActionResult> DeleteDepartments(IntCollectionModel model)
        {
            foreach (var id in model.collection)
            {
                await _coreRep.DeleteDepartment(id, await getCurrentUser());
            }
            return Ok(new ResponseModel());
        }

        [HttpPost]
        [Route("deptsselection")]
        public async Task<IActionResult> GetDepartmentsSelection(string queryString)
        {
            var dept = await _coreRep.GetDepartments(queryString, 1000, 0, "code", 0, new
            {
                Code = queryString,
                FullName = queryString,
                ShortName = queryString
            });
            return Ok(new ResponseModel(dept.Select(u => new
            {
                text = u.FullName,
                value = u.Id
            })));
        }

        [HttpPost]
        [Route("ReviewDepartmentExcel")]
        public async Task<IActionResult> ReviewDepartmentExcel()
        {
            var file = Request.Form.Files[0];
            var rs = new List<DepartmentErrorableModel>();
            await FileHelper.scanExcel(file, 6, async (header, row) =>
            {
                var dept = new DepartmentErrorableModel();
                try
                {
                    for (var i = 0; i < header.Cells.Count; i++)
                    {
                        if (row.Cells.Count > i)
                        {
                            await dept.UpdateDepartmentFromCell(header.Cells[i].StringCellValue, row.Cells[i],
                                 async (p) =>
                                 {
                                     return await _coreRep.GetDepartments(filter: p);
                                 });
                        }
                    }
                }
                catch (Exception e)
                {
                    dept.messages.Add(MessageModel.CreateError(e.Message, e.Source));
                }
                rs.Add(dept);
            });
            return Ok(new ResponseModel(rs));
        }

        [HttpPost]
        [Route("ImportDepartments")]
        public async Task<IActionResult> UploadDepartmentExcel(ICollection<DepartmentModel> depts)
        {
            var entities = depts.Select(u => u.ToEntity());
            var rs = new List<DepartmentErrorableModel>();
            foreach (var item in entities)
            {
                try
                {
                    await _coreRep.UpdateOrAddDepartmentByCode(item, await getCurrentUser());
                    var irs = new DepartmentErrorableModel(item);
                    rs.Add(irs);
                }
                catch (Exception e)
                {
                    var irs = new DepartmentErrorableModel(item);
                    irs.messages.Add(MessageModel.CreateError(e.Message));
                    rs.Add(irs);
                }
            }
            return Ok(new ResponseModel(rs));
        }
        #endregion
    }
}