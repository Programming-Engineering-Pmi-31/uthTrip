using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using uthTrip.BLL.Infrastructure;
using uthTripProject.Util;

namespace uthTripProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule userModule = new UserModule();
            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
            var kernel = new StandardKernel(userModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));

            //NinjectModule tripModule = new TripModule();
            //NinjectModule serviceModuletrip = new ServiceModule("DefaultConnection");
            //var kernelTrip = new StandardKernel(tripModule, serviceModuletrip);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernelTrip));
        }
    }
}
