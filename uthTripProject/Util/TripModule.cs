namespace UthTripProject.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Ninject.Modules;
    using UthTrip.BLL.Interfaces;
    using UthTrip.BLL.Services;

    public class UthTripModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ITripService>().To<TripService>();
            this.Bind<IUserService>().To<UserService>();
            this.Bind<IRightsService>().To<RightsService>();

        }
    }
}