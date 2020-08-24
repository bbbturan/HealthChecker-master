using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HealthCheckCoreAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHealthChecks();
            services.AddHealthChecksUI();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            var options = new HealthCheckOptions();
            options.ResponseWriter = async (c, r) =>
            {
                c.Response.ContentType = "application/json";
                var result = JsonConvert.SerializeObject(new
                {
                    status = r.Status.ToString(),
                    errors = r.Entries.Select(e => new
                    {
                        key = e.Key,
                        value = e.Value.Status.ToString()
                    }),
                    durations = r.TotalDuration.TotalMilliseconds.ToString()
                });
                await c.Response.WriteAsync(result);
            };


            app.UseHealthChecks(
                path: "/HealthChecks", 
                options: new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                }
                
                );

            app.UseHealthChecksUI(options =>
            {
                options.UIPath = "/HealthChecks-ui";
            });
        }
    }
}
