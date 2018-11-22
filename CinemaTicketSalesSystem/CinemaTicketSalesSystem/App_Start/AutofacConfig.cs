using Autofac;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Autofac.Integration.Mvc;
using ApplicationDbMovies.Contexts;
using ApplicationDbMovies.Models;
using CinemaTicketSalesBusinessLogic.Models;
using CinemaTicketSalesBusinessLogic.Queries;
using CinemaTicketSalesBusinessLogic.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using ApplicationDbMovies.Configurations;
using CinemaTicketSalesBusinessLogic.Mappings;
using CinemaTicketSalesBusinessLogic.CRUD;

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
            builder.Register<IdentityFactoryOptions<ApplicationDbContext>>(c => new IdentityFactoryOptions<ApplicationDbContext>()
            {
                DataProtectionProvider = new Microsoft.Owin.Security.DataProtection.DpapiDataProtectionProvider("CinemaTicketSalesSystem")
            }).InstancePerRequest();
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<MovieService>().As<IMovieService>().InstancePerRequest();
            builder.RegisterType<ActorService>().As<IActorService>().InstancePerRequest();
            builder.RegisterType<ProducerService>().As<IProducerService>().InstancePerRequest();
            builder.RegisterType<GenreService>().As<IGenreService>().InstancePerRequest();


            builder.Register(context =>
            {
                var config = new MapperConfiguration(x =>
                {
                    x.AddProfiles(typeof(MovieProfile).Assembly);
                    x.AddProfiles(typeof(PictureProfile).Assembly);
                    x.AddProfiles(typeof(ActorsProfile).Assembly);
                    x.AddProfiles(typeof(ProducersProfile).Assembly);
                    x.AddProfiles(typeof(GenresProfile).Assembly);
                    x.AddProfiles(typeof(Mappings.MovieProfile).Assembly);
                    x.AddProfiles(typeof(Mappings.ActorsProfile).Assembly);
                    x.AddProfiles(typeof(Mappings.ProducersProfile).Assembly);
                    x.AddProfiles(typeof(Mappings.GenresProfile).Assembly);


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