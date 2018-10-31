using Microsoft.Owin;
using Owin;
using CinemaTicketSalesSystem.Models;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;

[assembly: OwinStartup(typeof(AspNetIdentityApp.Startup))]

namespace AspNetIdentityApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Set up context and manager
            app.CreatePerOwinContext<ApplicationContext>(ApplicationContext.Create);              // Registering ApplicationContext in OWIN 
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);      // Registering ApplicationUserManager in OWIN
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,                // Using Cookie 
                LoginPath = new PathString("/Account/Login"),
            });
        }
    }
}