using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HealthChecker.WebApp.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Authorization;
using HealthChecker.WebApp.Helpers;
using HealthChecker.Entities;
using Newtonsoft.Json;
using Nancy.Json;
using System.Net.Http.Headers;
using System.Text;

namespace HealthChecker.WebApp.Controllers
{
    public class HomeController : Controller
    {

        ApiHelper _apiHelper;
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _apiHelper = new ApiHelper();
        }

        public async Task<IActionResult> GetUsers()
        {

            List<User> user = new List<User>();
            HttpClient client = _apiHelper.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Users");

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<List<User>>(result);
            }

            return View(user);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new UserSignUpViewModel());
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View(new UserSignInViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserSignInViewModel user)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _apiHelper.Initial();

                var stringModel = await Task.Run(() => JsonConvert.SerializeObject(user));
                var stringContent = new StringContent(stringModel, Encoding.UTF8);
                HttpResponseMessage res = await client.PostAsync("api/Users", stringContent);

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    var sur = JsonConvert.DeserializeObject<List<User>>(result);
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Register");
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserSignUpViewModel model)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = _apiHelper.Initial();

                var stringModel = await Task.Run(() => JsonConvert.SerializeObject(model));
                var stringContent = new StringContent(stringModel, Encoding.UTF8, "application/json");
                HttpResponseMessage res = await client.PostAsync("api/Users", stringContent );

                if (res.IsSuccessStatusCode)
                {
                    var result = res.Content.ReadAsStringAsync().Result;
                    var sur = JsonConvert.DeserializeObject<List<User>>(result);
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Register");
                //var content = new JavaScriptSerializer().Serialize(model);


            //    var contentHttp = new FormUrlEncodedContent(new[]
            //{
            //    new KeyValuePair<string, string>("UserName", model.UserName),
            //    new KeyValuePair<string, string>("Name", model.Name),
            //    new KeyValuePair<string, string>("Surname", model.SurName),
            //    new KeyValuePair<string, string>("Email", model.Email),
            //    new KeyValuePair<string, string>("PasswordHash", model.PasswordHash)

            //});
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
