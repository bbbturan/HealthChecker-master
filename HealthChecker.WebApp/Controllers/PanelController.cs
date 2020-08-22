using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthChecker.Entities;
using HealthChecker.Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nancy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using HealthChecker.WebApp.Helpers;
using Newtonsoft.Json;
using System.Text;
using System.Runtime.CompilerServices;

namespace HealthChecker.WebApp.Controllers
{
    public class PanelController : Controller
    {
        public User _user = new User();
        private UserManager<User> _userManager;
        private ApiHelper _apiHelper;

        public void FillUser()
        {
            if (Request.Cookies["email"] != null)
            {
                _user =  _userManager.Users.Include(user => user.Apps)
                              .Where(user => user.Email == Request.Cookies["email"].ToString()).FirstOrDefault();
                _user.PasswordHash = null;
            }
        }

        public PanelController(UserManager<User> userManager)
        {
            _userManager = userManager;
            _apiHelper = new ApiHelper();
        }
        
        public  IActionResult Index()
        {
            if(Request.Cookies["email"] != null)
            {
                FillUser();
                return View(_user);
            }
            return RedirectToAction("Login", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> CreateApp(IFormCollection form)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _apiHelper.Initial();

                TargetApp created = new TargetApp() {
                    Name = form["Name"],
                    UrlString = form["UrlString"],
                    Interval = Convert.ToInt32(form["Interval"]),
                    UserId = _user.Id,
                    User = new User(_user.ToString())
                };

                var stringModel = await Task.Run(() => JsonConvert.SerializeObject(created));
                var stringContent = new StringContent(stringModel, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("api/TargetApps", stringContent);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Panel");
                }
                return RedirectToAction("Register", "Home");
            }
            return RedirectToAction("Register", "Home");
        }
    }
}
