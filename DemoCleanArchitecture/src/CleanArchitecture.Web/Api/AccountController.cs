using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Core.Entities.Accounts;
using CleanArchitecture.Core.Interfaces;
using CleanArchitecture.Web.ApiModels;
using CleanArchitecture.Web.ApiModels.Accounts;
using DmcSupport.Models.Accounts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Web.Api
{
    [Route("api/[controller]")]
    [Produces("json/application")]
    public class AccountController : Controller
    {
        //private readonly ApplicationDbContext _context;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ICoreRepository _icore;

        public AccountController(SignInManager<AppUser> signinManager, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, ICoreRepository icore)
        {
            _signinManager = signinManager;
            _userManager = userManager;
            _roleManager = roleManager;
            _icore = icore;

            //_logger = logger;
        }

        [HttpPost]
        [Route("signin")]
        [AllowAnonymous]
        public async Task<IActionResult> Signin(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var appuser = await _userManager.FindByEmailAsync(user.Username);
                    if (appuser == null)
                    {
                        appuser = await _userManager.FindByNameAsync(user.Username);
                    }

                    //If wrong user
                    if (appuser == null)
                    {
                        return BadRequest();
                    }
                    var s = await _signinManager.PasswordSignInAsync(appuser, user.Password, user.Remember, lockoutOnFailure: false);
                    string message = String.Empty;
                    if (s.IsNotAllowed)
                    {
                        return BadRequest(new
                        {
                            message = "Tài khoản của bạn không được phép đăng nhập"
                        });
                    }
                    if (s.IsLockedOut)
                    {
                        return BadRequest(new
                        {
                            message = "Tài khoản của bạn đã bị khóa"
                        });
                    }
                    if (!s.Succeeded)
                    {
                        return BadRequest(new
                        {
                            message = "Tên tài khoản hoặc mật khẩu không đúng"
                        });
                    }
                    else
                    {
                        return Ok(new
                        {
                            data = new
                            {
                                username = appuser.UserName,
                                fullname = appuser.GetFullname(),
                                shortname = appuser.GetShortName()
                            }
                        });
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(new
                    {
                        message = e.Message
                    });
                }
            }
            return BadRequest(new
            {
                message = ModelState.Select(u => $"{u.Key}: {u.Value}")
            });
        }

        [AllowAnonymous]
        [Route("signout")]
        [HttpPost]
        public async Task<IActionResult> SignOut()
        {
            //var user = await _userManager.FindByNameAsync(User.Identity.Name);
            await _signinManager.SignOutAsync();
            return Ok();
        }

        [HttpPost]
        [Route("register")]
        [Authorize]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var appuser = new AppUser();
                if (String.IsNullOrEmpty(model.EmployeeCode))
                {
                    var emp = await _icore.GetEmployee(model.EmployeeCode);
                    if (emp != null)
                    {
                        return BadRequest(new
                        {
                            message = ""
                        });

                    }
                }
                appuser.UserName = model.Username;
                appuser.Email = model.Email;

                var r = await _userManager.CreateAsync(appuser, model.Password);
                var mlist = new List<string>();

                if (!r.Succeeded)
                {
                    return BadRequest(new
                    {
                        messages = r.Errors.Select(u => new
                        {
                            key = u.Code,
                            value = u.Description
                        })
                    });
                }
                else
                {
                    return Ok();
                }
            }
            return BadRequest(new
            {
                result = false,
                messages = ModelState.Select(u => new
                {
                    key = u.Key,
                    value = u.Value
                })
            });
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult> list()
        {
            var accounts = await _userManager.Users.Include(u => u.Employee).ToListAsync();
            var data = new
            {
                data = accounts.Select(async u => new
                {
                    username = u.UserName,
                    employeeId = u.EmployeeId,
                    employeeCode = u.Employee == null ? null : u.Employee.Code,
                    email = u.Email,
                    id = u.Id,
                    roles = (await _userManager.GetRolesAsync(u))
                })
            };
            return Ok(new ResponseModel(data));
        }

        [HttpGet]
        [Route("details/{id}")]
        public async Task<IActionResult> Detail(string id)
        {
            var user = await _userManager.Users.Include(u => u.Employee).FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return NotFound();
            var userroles = await _userManager.GetRolesAsync(user);
            var data = new DetailsModel(user);
            data.SetRoles(userroles);
            return Ok(new ResponseModel(new
            {
                data = data
            }));
        }

        [HttpPost]
        [Route("update/{id}")]
        public async Task<IActionResult> Edit(string id, EditUserApplicationModel model)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return NotFound();
                }
                user.UserName = model.UserName;
                user.Email = model.Email;
                user.PhoneNumber = model.PhoneNumber;
                user.EmployeeId = model.EmployeeId;
                await _userManager.UpdateAsync(user);

                var aroles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, aroles);
                if (model.Roles != null)
                    await _userManager.AddToRolesAsync(user, model.Roles);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }

        }

        [HttpPost]
        [Route("changepassword")]
        public async Task<IActionResult> ChangePassword(RegisterModel model)
        {
            var user = await _userManager.FindByNameAsync(_signinManager.Context.User.Identity.Name);
            if (user == null)
                return NotFound();
            var rs = await _userManager.ChangePasswordAsync(user, model.Password, model.ConfirmPassword);
            if (rs.Succeeded)
                return Ok();
            else
                return BadRequest(rs.Errors.Select(u => $"{u.Code}: {u.Description}"));
        }

        [HttpPost]
        [Route("resetpassword/{id}")]
        public async Task<IActionResult> ResetPassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return NotFound();
            }
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var password = GenerateRandomPassword(_userManager.Options.Password);
            var result = await _userManager.ResetPasswordAsync(user, token, password);

            if (result.Succeeded)
                return Ok();
            else
                return BadRequest(result.Errors.Select(u => $"{u.Code}: {u.Description}"));
        }

        [HttpPost]
        public async Task<ActionResult> AssignUserRole(string id, UserRolesModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);
                var roles = await _userManager.GetRolesAsync(user);
                await _userManager.RemoveFromRolesAsync(user, roles.ToArray());
                for (var i = 0; i < model.RolesNewAssigned.Count; i++)
                {
                    await _userManager.AddToRoleAsync(user, model.RolesNewAssigned[i]);
                }
                return Ok();
            }
            // ViewBag["SuccessMessage"] = "Đã thêm quyền thành công";
            return BadRequest(ModelState);
        }

        private class SelectionItem
        {
            public bool _checked { get; set; }
            public string value { get; set; }
        }

        private class RoleSelectionItem
        {
            public string description { get; set; }
        }


        private async Task<IEnumerable<SelectionItem>> GetRoleSelection(ICollection<string> userroles)
        {
            var roles = (await _roleManager.Roles.ToListAsync()).Select(u => new SelectionItem
            {
                value = u.Name,
                _checked = userroles.Contains(u.Name)
            });
            return roles;
        }

        public static string GenerateRandomPassword(PasswordOptions opts = null)
        {
            if (opts == null) opts = new PasswordOptions()
            {
                RequiredLength = 8,
                RequiredUniqueChars = 4,
                RequireDigit = true,
                RequireLowercase = true,
                RequireNonAlphanumeric = true,
                RequireUppercase = true
            };

            string[] randomChars = new[] {
        "ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
        "abcdefghijkmnopqrstuvwxyz",    // lowercase
        "0123456789",                   // digits
        "!@$?_-"                        // non-alphanumeric
    };
            Random rand = new Random(Environment.TickCount);
            List<char> chars = new List<char>();

            if (opts.RequireUppercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[0][rand.Next(0, randomChars[0].Length)]);

            if (opts.RequireLowercase)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[1][rand.Next(0, randomChars[1].Length)]);

            if (opts.RequireDigit)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[2][rand.Next(0, randomChars[2].Length)]);

            if (opts.RequireNonAlphanumeric)
                chars.Insert(rand.Next(0, chars.Count),
                    randomChars[3][rand.Next(0, randomChars[3].Length)]);

            for (int i = chars.Count; i < opts.RequiredLength
                || chars.Distinct().Count() < opts.RequiredUniqueChars; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(rand.Next(0, chars.Count),
                    rcs[rand.Next(0, rcs.Length)]);
            }

            return new string(chars.ToArray());
        }


    }
}