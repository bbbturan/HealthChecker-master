using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthChecker.Business.Abstract;
using HealthChecker.Business.Concrete;
using HealthChecker.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthChecker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private ILogService _logService;

        public LogsController()
        {
            _logService = new LogManager(); 
        }

        [HttpGet]
        public List<Log> Get()
        {
            return _logService.GetAllLogs();
        }

        [HttpPost]
        public Log Post([FromBody]Log log)
        {
            return _logService.CreateLog(log);
        }



        ///To Do
        ///-Develop get method by date
        ///-Use this method for log management

        ///[HttpGet("{id}")]
        ///public Log Get(int id)
        ///{
        ///    return _logService.GetLogById(id);
        ///}
    }
}
