using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using uthTrip.BLL.Services;
using uthTrip.BLL.Interfaces;

namespace uthTripProject.Util
{
    public class DestinationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IDestinationService>().To<DestinationService>();
        }
    }
}