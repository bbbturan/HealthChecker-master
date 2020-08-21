using System;
using System.Threading;
using System.Threading.Tasks;
using HealthChecker.Services;

namespace HealthChecker.Services
{
    public class RequestCollectorService : HostedService
    {
        protected override async Task ExecuteAsync(CancellationToken cToken)
        {
            while (!cToken.IsCancellationRequested)
            {
                Console.WriteLine($"{DateTime.Now.ToString()} Çalışma zamanı taleplerini topluyorum.");
                await Task.Delay(TimeSpan.FromSeconds(30), cToken);
            }
        }
    }
}
