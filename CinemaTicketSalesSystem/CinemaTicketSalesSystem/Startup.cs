using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CinemaTicketSalesSystem.Startup))]
namespace CinemaTicketSalesSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
