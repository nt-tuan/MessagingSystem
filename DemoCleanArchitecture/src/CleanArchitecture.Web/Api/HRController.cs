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
        public HRController(AppDbContext context, ICoreRepository coreRep)
        {
            _context = context;
            _coreRep = coreRep;
        }

        #region EMPLOYEE
        [HttpPost]
        [Route("emp")]
        public async Task<IActionResult> GetEmployees(TableParameter param)
        {
            /*
            var list = await _coreRep.GetEmployees(param.pageSize, param.page, param.search, param.orderBy, param.orderDirection, param.filter);
            var count = await _coreRep.GetEmployeeCount(param.filter);
            return Ok(new
            ResponseModel(new
            {
                emps = list.Select(u => new EmployeeModel(u)),
                total = count
            }));
            */
            return null;
        }

        [HttpPost]
        [Route("emp/{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var emp = await _coreRep.GetEmployee(id);
            if (emp != null)
            {
                return Ok(new ResponseModel(new
                EmployeeModel(emp)));
            }
            return NotFound();
        }

        [HttpPost]
        [Route("emp/update/{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeModel model)
        {
            /*
            var entity = new Employee
            {
                Id = id,
                FirstName = model.firstname,
                LastName = model.lastname,
                DepartmentId = model.deptid,
                Code = model.code
            };
            await _coreRep.UpdateEmployee(id, entity);
            return Ok(new ResponseModel(new
            {
                result = true
            }));
            */
            return null;
        }

        [HttpPost]
        [Route("emp/delete")]
        public async Task<IActionResult> DeleteEmployees(IntCollectionModel model)
        {
            foreach (var id in model.collection)
            {
                await _coreRep.RemoveEmployee(id);
            }
            return Ok(new ResponseModel());
        }

        [HttpPost]
        [Route("emp/add")]
        public async Task<IActionResult> AddEmployee(EmployeeModel model)
        {
            /*
            var employee = new Employee
            {
                Code = model.code,
                FirstName = model.firstname,
                LastName = model.lastname,
                DepartmentId = model.deptid,
                Address = model.address,
                Phone = model.phone,
                Birthday = model.birthday,
                Email = model.email
            };
            await _coreRep.AddEmployee(employee);
            return Ok(new ResponseModel(new { result = true }));
            */
            return null;
        }

        #endregion

        #region DEPARTMENT
        [HttpPost]
        [Route("dept/{id}")]
        public async Task<IActionResult> GetDepartment(int id)
        {
            var dept = await _coreRep.GetDepartment(id);
            return Ok(new ResponseModel(new DepartmentModel(dept)));
        }

        [HttpPost]
        [Route("depts")]
        public async Task<IActionResult> GetDepartments(TableParameter param)
        {
            var depts = await _coreRep.GetDepartments(param.pageSize, param.page, param.search, param.orderBy, param.orderDirection, param.filter);

            var count = await _coreRep.GetDepartmentCount();
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
            /*
            try
            {
                var entity = new Department
                {
                    Code = model.code,
                    Name = model.name,
                    ParentId = model.parentId,
                    ManagerId = model.managerId
                };
                await _coreRep.UpdateDepartment(id, entity);
                return Ok(new ResponseModel(new
                {
                    result = true
                }));
            }
            catch (Exception e)
            {
                return BadRequest(new ResponseModel(e.Message));
            }
            */
            return null;
        }

        [HttpPost]
        [Route("dept/delete")]
        public async Task<IActionResult> DeleteDepartment(IntCollectionModel model)
        {
            try
            {
                foreach (var id in model.collection)
                {
                    await _coreRep.DeleteDepartment(id);
                }
                return Ok(new ResponseModel());
            }
            catch (Exception e)
            {
                return Ok(new ResponseModel(e.Message, new
                {
                    result = false
                }));
            }
        }

        [HttpPost]
        [Route("deptsselection")]
        public async Task<IActionResult> GetDepartmentsSelection(string queryString)
        {
            var dept = await _coreRep.GetDepartments(1000, 0, queryString, "code", 0, null);
            return Ok(new ResponseModel(dept.Select(u => new
            {
                text = u.FullName,
                value = u.Id
            })));
        }
        #endregion

    }
}