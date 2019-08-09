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

namespace CleanArchitecture.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRController : ControllerBase
    {
        AppDbContext _context;
        ICoreRepository _coreRep;
        IRepository _repos;
        public HRController(AppDbContext context, ICoreRepository coreRep, IRepository repos)
        {
            _context = context;
            _coreRep = coreRep;
            _repos = repos;
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
            var entity = model.ToEmployee();
            await _coreRep.UpdateEmployee(entity);
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
                await _coreRep.DeleteEmployee(id);
            }
            return Ok(new ResponseModel());
        }

        [HttpPost]
        [Route("emp/add")]
        public async Task<IActionResult> AddEmployee(EmployeeModel model)
        {
            var entity = model.ToEmployee();
            await _coreRep.AddEmployee(entity);
            return Ok(new ResponseModel(new { result = true }));
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
            await _coreRep.UpdateDepartment(entity);
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
                await _coreRep.DeleteDepartment(id);
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
        #endregion

    }
}