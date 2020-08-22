using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthChecker.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nancy;

namespace HealthChecker.WebApp.Controllers
{
    public class PanelController : Controller
    {
        private User _user;
        
        public IActionResult Index()
        {
            _user = new User()
            {
                Id = Request.Cookies["id"].ToString(),
                UserName = Request.Cookies["username"].ToString(),
                Email = Request.Cookies["username"].ToString(),
                PasswordHash = Request.Cookies["password"].ToString(),
                Apps = new List<TargetApp>(){}
            };  

            ///TO DO
            /// - get all apps from api by userid
            /// - make sure to complete method that return apps by id


            return View(_user);
        }
    }
}
