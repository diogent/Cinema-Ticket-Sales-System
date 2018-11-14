using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;


[assembly: OwinStartup(typeof(AspNetIdentityApp.Startup))]

namespace AspNetIdentityApp
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //// Set up context and manager
            //// Registering ApplicationContext in OWIN 
            //app.CreatePerOwinContext<ApplicationContext>(ApplicationContext.Create);
            //// Registering ApplicationUserManager in OWIN
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                // Using Cookie 
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Index"),
            });
        }
    }
}