namespace uthTripProject.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Ninject.Modules;
    using uthTrip.BLL.Interfaces;
    using uthTrip.BLL.Services;

    public class UserModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();

        }
    }
}