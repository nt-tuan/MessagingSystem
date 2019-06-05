using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Web.ApiModels;

namespace CleanArchitecture.Web.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class HRController : ControllerBase
    {
        AppDbContext _context;
        public HRController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("emps")]
        public async Task<IActionResult> GetEmployees([FromQuery] int perpage = 30, int page = 0, string search = null, string orderBy = "code", string direction = "asc")
        {

            var query = _context.Employees.AsQueryable();
            if (!string.IsNullOrEmpty(search))
                query = query.Where(u => u.FullName.Contains(search));
            if (direction == "asc")
                query = query.OrderBy(u => orderBy);
            else
                query = query.OrderByDescending(u => orderBy);
            var total = await query.CountAsync();
            var list =
            await query.Skip(perpage * page).Take(perpage).ToListAsync();

            return Ok(new
            ResponseModel(new
            {
                emps = list,
                total = total
            }));
        }

        [HttpPost]
        [Route("emps/{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var emp = await _context.Employees.Where(u => !u.Removed && u.Id == id).FirstOrDefaultAsync();
            if (emp != null)
            {
                return Ok(new ResponseModel(new
                {
                    code = emp.Code,
                    firstname = emp.FirstName,
                    lastname = emp.LastName,
                    deptid = emp.DepartmentId,
                    birthday = emp.Birthday,
                    email = emp.Email
                }));
            }
            return NotFound();
        }

        

    }
}