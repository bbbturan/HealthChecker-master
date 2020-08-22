using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HealthChecker.Entities;
using HealthChecker.WebApp.Helpers;
using HealthChecker.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HealthChecker.WebApp.Controllers
{
    public class AuthController : Controller
    {
        ApiHelper _apiHelper;
        private readonly ILogger<AuthController> _logger;


        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
            _apiHelper = new ApiHelper();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserSignInViewModel user)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _apiHelper.Initial();

                var stringModel = await Task.Run(() => JsonConvert.SerializeObject(user));
                var stringContent = new StringContent(stringModel, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("api/Account/login", stringContent);

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    var sur = JsonConvert.DeserializeObject<List<User>>(result);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            return RedirectToAction("Register","Home");
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _apiHelper.Initial();

                var stringModel = await Task.Run(() => JsonConvert.SerializeObject(model));
                var stringContent = new StringContent(stringModel, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("api/Users", stringContent);

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    var sur = JsonConvert.DeserializeObject<List<User>>(result);
                    return RedirectToAction("Index", "Home");
                }
                return RedirectToAction("Register", "Home");
            }
            return RedirectToAction("Register", "Home");
        }
    }
}
