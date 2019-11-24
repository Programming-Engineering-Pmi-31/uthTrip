namespace uthTripProject.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Ninject.Modules;
    using uthTrip.BLL.Interfaces;
    using uthTrip.BLL.Services;
    public class DestinationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDestinationService>().To<DestinationService>();
        }
    }
}