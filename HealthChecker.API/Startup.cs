using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthChecker.DataAccess;
using HealthChecker.Entities;
using HealthChecker.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HealthChecker.API
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            ///Check this lineee
            //services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/LogIn");
          
            //services.AddAuthentication("Auth")
            //.AddScheme<AuthenticationSchemeOptions, AuthHandler>("Auth", null);
            services.AddDbContext<ApplicationContext>();
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationContext>()
                .AddDefaultTokenProviders();
            services.AddControllers();
            services.AddSingleton<IHostedService, HealthCheckService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
