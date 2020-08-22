using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthChecker.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthChecker.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("administrator/register")]
        public async Task<IActionResult> SignUpPost([FromHeader]User model)
        {
            User user;
            try
            {
                user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

            }
            catch (Exception)
            {
                ///TO DO
                ///-Add log record
                return BadRequest();
            }

            var result = await _userManager.CreateAsync(user, model.PasswordHash);
            if (!result.Succeeded)
            {
                ///TO DO
                ///-Add log record
                return BadRequest();
            }

            return StatusCode(201);
        }


        [HttpPost]
        [Route("administrator/login")]
        public async Task<IActionResult> SignInPost([FromHeader]User model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.PasswordHash, false, true);
            if (result.Succeeded)
            {
                return StatusCode(201);

            }
            return BadRequest();
        }

    }
}