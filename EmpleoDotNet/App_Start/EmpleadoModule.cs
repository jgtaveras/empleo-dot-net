﻿using EmpleoDotNet.Data;
using EmpleoDotNet.Repository;
using EmpleoDotNet.Repository.Contracts;
using EmpleoDotNet.AppServices;
using EmpleoDotNet.Services;
using EmpleoDotNet.Services.Social.Twitter;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Ninject.Modules;
using Ninject.Web.Common;

namespace EmpleoDotNet.App_Start
{
    public class EmpleadoModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind<EmpleadoContext>().ToSelf().InRequestScope();

            Kernel.Bind<IJobOpportunityRepository>().To<JobOpportunityRepository>();
            Kernel.Bind<ITagRepository>().To<TagRepository>();
            Kernel.Bind<ILocationRepository>().To<LocationRepository>();
            Kernel.Bind<IUserProfileRepository>().To<UserProfileRepository>();

            Kernel.Bind<ILocationService>().To<LocationService>();
            Kernel.Bind<IJobOpportunityService>().To<JobOpportunityService>();
            Kernel.Bind<IAuthenticationService>().To<AuthenticationService>()
                .WithConstructorArgument("userManager", new UserManager<IdentityUser>(new UserStore<IdentityUser>(new EmpleadoContext())));

            Kernel.Bind<ITwitterService>().To<TwitterService>();
        }
    }
}