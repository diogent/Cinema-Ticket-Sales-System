using Autofac;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Autofac.Integration.Mvc;
using ApplicationDbMovies.Contexts;
using ApplicationDbMovies.Models;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesBusinessLogic.Queries;
using AutoMapper;
using CinemaTicketSalesBusinessLogic.Mappings;

namespace CinemaTicketSalesSystem.Services
{
    public class AutofacConfig
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();
            builder.Register<RoleStore<ApplicationRole>>(c => new RoleStore<ApplicationRole>(c.Resolve<ApplicationDbContext>()))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.Register<UserStore<ApplicationUser>>(c => new UserStore<ApplicationUser>(c.Resolve<ApplicationDbContext>()))
                .AsImplementedInterfaces().InstancePerRequest();
            builder.Register<IdentityFactoryOptions<ApplicationUserManager>>(c => new IdentityFactoryOptions<ApplicationUserManager>()
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("CinemaTicketSalesSystem")
            }).InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(ApplicationUserManager).Assembly)
                .Where(t => t.Name.EndsWith("Manager"))
                .AsSelf().InstancePerRequest();

            
            builder.RegisterAssemblyTypes(typeof(MovieService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .InstancePerRequest();


            builder.Register(context =>
            {
                var config = new MapperConfiguration(x =>
                {
                    x.AddProfiles(typeof(MovieProfile).Assembly);
                    x.AddProfiles(typeof(Mappings.MovieProfile).Assembly);
                });

                return config;
            }).SingleInstance()
                .AutoActivate()
                .AsSelf();

            builder.Register(tempContext =>
            {
                var ctx = tempContext.Resolve<IComponentContext>();
                var config = ctx.Resolve<MapperConfiguration>();

                return config.CreateMapper();
            }).As<IMapper>();

            var container = builder.Build();
            return container;   
        }   
    }
}