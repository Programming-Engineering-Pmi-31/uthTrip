﻿namespace UthTripProject.Util
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using Ninject.Modules;
    using UthTrip.BLL.Interfaces;
    using UthTrip.BLL.Services;

    public class UserModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IUserService>().To<UserService>();
        }
    }
}