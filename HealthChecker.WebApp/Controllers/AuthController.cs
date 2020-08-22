using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthChecker.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
    }
}
