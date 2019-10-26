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

            NinjectModule tripModule = new TripModule();
            var kernelTrip = new StandardKernel(tripModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernelTrip)); AreaRegistration.RegisterAllAreas();

            //NinjectModule destinationModule = new DestinationModule();
            //var kernelDestin = new StandardKernel(destinationModule, serviceModule);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernelDestin));

            //NinjectModule daterangeModule = new DateRangesModule();
            //var kernelDateRange = new StandardKernel(daterangeModule, serviceModule);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernelDateRange));
        }
    }
}
