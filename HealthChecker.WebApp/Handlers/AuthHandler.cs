using HealthChecker.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace HealthChecker.WebApp.Handlers
{
    public class AuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private UserManager<User> _userManager;

        public AuthHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            UserManager<User> userManager)
            : base(options, logger, encoder, clock)
        {
            _userManager = userManager;
        }
        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization")) { 
                await Context.Response.WriteAsync("Authorization header was not found");
                return AuthenticateResult.Fail("Authorization header was not found");
            }

            try
            {
                var authenticationHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var bytes = Convert.FromBase64String(authenticationHeader.Parameter);
                string[] credentials = Encoding.UTF8.GetString(bytes).Split(":");
                string emailAddress = credentials[0];
                string password = credentials[1];

                User user = _userManager.Users.Where(user => user.Email == emailAddress && user.PasswordHash == password).FirstOrDefault();
                if (user == null) { 
                    await Context.Response.WriteAsync("Invalid username or password");    
                    return AuthenticateResult.Fail("Invalid username or password");
                }
                else
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, user.Email) };
                    var identity = new ClaimsIdentity(claims, Scheme.Name);
                    var principal = new ClaimsPrincipal(identity);
                    var ticket = new AuthenticationTicket(principal, Scheme.Name);

                    await Context.Response.WriteAsync("200 : " + ticket);
                    return AuthenticateResult.Success(ticket);

                }

            }
            catch (Exception e)
            {
                await Context.Response.WriteAsync(e.Message);
                return AuthenticateResult.Fail(e.Message);
            }

        }
    }
}
