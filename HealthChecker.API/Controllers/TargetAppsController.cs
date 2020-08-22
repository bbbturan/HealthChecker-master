using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthChecker.Business.Abstract;
using HealthChecker.Business.Concrete;
using HealthChecker.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthChecker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TargetAppsController : ControllerBase
    {
        private ITargetAppService _appService;

        public TargetAppsController()
        {
            _appService = new TargetAppManager();
        }

        [HttpGet]
        public List<TargetApp> Get()
        {
            return _appService.GetAllApps();
        }

        [HttpGet("{id}")]
        public TargetApp Get(int id)
        {
            return _appService.GetAppById(id);
        }

        [HttpPost]
        public TargetApp Post([FromBody]TargetApp targetApp) {
            return _appService.CreateApp(targetApp);
        }

        [HttpPut]
        public TargetApp Put([FromBody]TargetApp targetApp)
        {
            return _appService.UpdateApp(targetApp);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _appService.DeleteApp(id);
        }
    }
}
