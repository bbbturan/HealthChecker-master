using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthChecker.API.Models;
using HealthChecker.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthChecker.Controllers
{
    [Route("api/[controller]")]
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
        [Route("register")]
        public async Task<IActionResult> SignUpPost([FromBody]UserSignUpViewModel model)
        {
            User user;
            try
            {
                user = new User
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PasswordHash = model.PasswordHash,
                    Name = model.Name,
                    Surname = model.SurName
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
        [Route("login")]
        public async Task<IActionResult> SignInPost([FromBody]UserSignInViewModel model)
        {
            var rslt =  _userManager.Users.Where(u => u.Email == model.UserName && u.PasswordHash == model.Password).FirstOrDefault();
           // var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, true);
            if (rslt != null )
            {
                return StatusCode(201);

            }
            return BadRequest();
        }

    }
}