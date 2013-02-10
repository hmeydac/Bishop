namespace Bishop.UI.Web
{
    using System.Data.Entity;
    using System.Web.Mvc;

    using Bishop.Model;
    using Bishop.Repositories;
    using Bishop.Services;

    using Microsoft.Practices.Unity;

    using Unity.Mvc3;

    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<DbContext, FormsContext>();
            container.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork>();

            // Register Services
            container.RegisterType<IFillingSessionService, FillingSessionService>();
            container.RegisterType<IFormService, FormService>();

            return container;
        }
    }
}