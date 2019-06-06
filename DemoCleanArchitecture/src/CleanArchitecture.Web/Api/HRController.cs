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
        [Route("emps")]
        public async Task<IActionResult> GetEmployees(TableParameter param)
        {
            var list = await _coreRep.GetEmployees(param.pageSize, param.page, param.search, param.orderBy, param.orderDirection, param.filters);
            var count = await _coreRep.GetEmployeeCount();
            return Ok(new
            ResponseModel(new
            {
                emps = list.Select(u => new EmployeeModel(u)),
                total = count
            }));
        }

        [HttpPost]
        [Route("emps/{id}")]
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
            var depts = await _coreRep.GetDepartments(param.pageSize, param.page, param.search, param.orderBy, param.orderDirection, param.filters);

            var count = await _coreRep.GetDepartmentCount();
            return Ok(new ResponseModel(new {
                depts = depts,
                total = count
            }));

        }
        #endregion

    }
}