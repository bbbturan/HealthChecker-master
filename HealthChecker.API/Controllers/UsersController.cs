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
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserManager<User> _userManager;

        public UsersController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("Users/Get")]
        public List<User> Get()
        {
            return _userManager.Users.ToList();
        }

        [HttpGet("GetLoginUser")]
        [Route("Users/GetLoginUser")]
        public async Task<ActionResult<User>> GetLoginUser()
        {
            string emailAddress = HttpContext.User.Identity.Name;

            var user = await _userManager.Users.Include(user=> user.Apps)
                            .Where(user => user.Email == emailAddress).FirstOrDefaultAsync();
            user.PasswordHash = null;
            return user;
        }

        [HttpGet("{id}")]
        [Route("Users/Get")]
        public User Get(string id)
        {
            return _userManager.Users.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        [Route("Users/Post")]
        public async Task Post([FromHeader]string user)
        {
            //Use if get JsonResult parameter
            //string strResult = user.ToString();
            User usr = new User(user);
            var result = await _userManager.CreateAsync(usr,usr.PasswordHash);
        }

    }
}
