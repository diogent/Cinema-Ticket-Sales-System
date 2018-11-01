using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration;
using CinemaTicketSalesSystem.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Autofac.Integration.Mvc;

namespace CinemaTicketSalesSystem.Services
{
    public class AutofacConfig
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ApplicationContext>().AsSelf().InstancePerRequest();
            builder.Register<UserStore<ApplicationUser>>(c => new UserStore<ApplicationUser>(c.Resolve<ApplicationContext>())).AsImplementedInterfaces();
            //builder.RegisterGeneric(typeof(UserStore<>)).As(typeof(IUserStore<>)).InstancePerRequest();
            builder.Register<IdentityFactoryOptions<ApplicationContext>>(c => new IdentityFactoryOptions<ApplicationContext>()
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("CinemaTicketSalesSystem")
            }).InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();            
            var container = builder.Build();
            return container;   
        }   
    }
}