using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("employees")]
        public async Task<IActionResult> GetEmployees([FromQuery] int perpage = 30, [FromQuery]int page = 0, string search = null, string orderBy = "code", string direction = "asc")
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
            {
                data = list,
                total = total,
                page = page
            });
        }
    }
}