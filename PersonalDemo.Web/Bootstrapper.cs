using System.Web.Mvc;
using Microsoft.Practices.Unity;
using System.Web.Http;
using PersonalDemo.Service;
using PersonalDemo.Service.Profiles;
using PersonalDemo.Service.Projects;
using PersonalDemo.Service.Referees;
using PersonalDemo.Web.Controllers.API;
using PersonalDemo.Web.Controllers.MVC;
using PersonalDemo.Web.Infrastructure;

namespace PersonalDemo.Web
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            // register dependency resolver for WebAPI RC
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
            // if you still use the beta version - change above line to:
            //GlobalConfiguration.Configuration.ServiceResolver.SetResolver(new Unity.WebApi.UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();            

            ServiceLayerBootstrapper.RegisterTypes(container);

            container.RegisterType<HomeController>();
            container.RegisterType<ProjectDataController>();
            container.RegisterType<ProfileDataController>();
            container.RegisterType<RefereeDataController>();
            container.RegisterType<SkillSumDataController>();
            container.RegisterType<EducationDataController>();
            container.RegisterType<WorkExpDataController>();

            return container;
        }
    }
}