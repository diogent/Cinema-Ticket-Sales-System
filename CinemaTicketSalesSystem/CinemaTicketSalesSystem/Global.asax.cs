using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac.Integration.Mvc;
using CinemaTicketSalesSystem.App_Start;
using CinemaTicketSalesSystem.Services;

namespace CinemaTicketSalesSystem
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            var container = AutofacConfig.ConfigureContainer();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
