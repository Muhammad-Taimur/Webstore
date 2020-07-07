﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebStoreWeb.App_Start;

namespace WebStoreWeb
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Registring Container Globally.
            ContainerConfig.RegisterContainer(GlobalConfiguration.Configuration);

            //Enabling cors
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            //EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
        }
    }
}
