using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthChecker.Business.Abstract;
using HealthChecker.Business.Concrete;
using HealthChecker.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace HealthChecker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public List<User> Get()
        {
            return _userManager.Users.ToList();
        }

        [HttpGet("GetLoginUser")]
        public async Task<ActionResult<User>> GetLoginUser()
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var user = await _userManager.Users.Include(user=> user.Apps)
                            .Where(user => user.Email == emailAddress).FirstOrDefaultAsync();
            user.PasswordHash = null;
            return user;
        }

        [HttpGet("{id}")]
        public User Get(string id)
        {
            return _userManager.Users.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public async Task Post([FromHeader]string user)
        {
            //Use if get JsonResult parameter
            //string strResult = user.ToString();
            User usr = new User(user);
            var result = await _userManager.CreateAsync(usr,usr.PasswordHash);
        }

    }
}
