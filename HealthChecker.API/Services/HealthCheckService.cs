using HealthChecker.API.Services;
using HealthChecker.Business.Abstract;
using HealthChecker.Business.Concrete;
using HealthChecker.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace HealthChecker.Services
{
    public class HealthCheckService : HostedService
    {
        HttpClient restClient;
        List<TargetApp> appList = new List<TargetApp>();

        private ITargetAppService _appService;
        private ILogService _logService;

        public HealthCheckService()
        {
            restClient = new HttpClient();
            _appService = new TargetAppManager();
            _logService = new LogManager();
        }
        protected override async Task ExecuteAsync(CancellationToken cToken)
        {

            appList = _appService.GetAllApps();

            foreach (var item in appList)
            {
                while (!cToken.IsCancellationRequested)
                {
                    var response = await restClient.GetAsync(item.UrlString, cToken);
                    if (response.IsSuccessStatusCode)
                    {
                        continue;
                    }
                    else
                    {
                        try
                        {
                            Log logResponse = new Log() {
                                Date = DateTime.Now,
                                ErrorMessage = response.Content.ToString()
                            };
                        
                            _logService.CreateLog(logResponse);
                            MailService.SendMail(item.User.Email, "Url Fail", response.StatusCode.ToString());
                        }
                        catch (Exception e)
                        {
                            var err = e.Message;
                            throw;
                        }
                    }

                }
                await Task.Delay(TimeSpan.FromSeconds(item.Interval), cToken);
            }


        }
    }
}
