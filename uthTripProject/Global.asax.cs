namespace UthTripProject
{
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
    using UthTrip.BLL.Infrastructure;
    using UthTripProject.Util;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule serviceModule = new ServiceModule("DefaultConnection");

            NinjectModule tripModule = new UthTripModule();
            var kernelTrip = new StandardKernel(tripModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernelTrip));

            AreaRegistration.RegisterAllAreas();
        }
    }
}
