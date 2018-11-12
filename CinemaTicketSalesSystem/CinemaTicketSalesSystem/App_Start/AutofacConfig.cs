using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Autofac.Integration.Mvc;
using ApplicationDbMovies.Contexts;
using ApplicationDbMovies.Models;
using CinemaTicketSalesBusinessLogic.Models;

namespace CinemaTicketSalesSystem.Services
{
    public class AutofacConfig
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.Register<UserStore<ApplicationUser>>(c => new UserStore<ApplicationUser>(c.Resolve<ApplicationDbContext>())).AsImplementedInterfaces();
            //builder.RegisterGeneric(typeof(UserStore<>)).As(typeof(IUserStore<>)).InstancePerRequest();
            builder.Register<IdentityFactoryOptions<ApplicationDbContext>>(c => new IdentityFactoryOptions<ApplicationDbContext>()
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("CinemaTicketSalesSystem")
            }).InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            var container = builder.Build();
            return container;   
        }   
    }
}