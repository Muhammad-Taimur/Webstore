using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using AutoMapper;
using WebStoreWeb.Models;
using System.Reflection;

namespace WebStoreWeb.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder  = new ContainerBuilder();

            //builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            
                

            //Mapper Configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });

            //config.AssertConfigurationIsValid();

            //Register mapping Class
            builder.RegisterInstance(config.CreateMapper())
                .As<IMapper>()
                .SingleInstance();

            var container = builder.Build();
            //DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}