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
    public class ChuckFactService : HostedService
    {
        HttpClient restClient;
        List<TargetApp> appList = new List<TargetApp>();
        string icndbUrl = "http://api.icndb.com/jokes/random";

        private ITargetAppService _appService;

        public ChuckFactService()
        {
            restClient = new HttpClient();
            _appService = new TargetAppManager();
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
                        var fact = await response.Content.ReadAsStringAsync();
                        Console.WriteLine($"{DateTime.Now.ToString()}\n{fact}");
                    }

                }
                ///TO DO
                /// catch exception and add log 
                await Task.Delay(TimeSpan.FromSeconds(item.Interval), cToken);
            }


        }
    }
}
