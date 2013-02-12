namespace Bishop.UI.Web.App_Start
{
    using System.Web.Mvc;

    using Bishop.Framework;

    using Microsoft.Practices.Unity;

    public class DependencyInjectionConfig
    {
        public static void RegisterDependencyResolver(IUnityContainer container)
        {
            var resolver = new UnityDependencyResolver(container);
            DependencyResolver.SetResolver(resolver);
        }
    }
}