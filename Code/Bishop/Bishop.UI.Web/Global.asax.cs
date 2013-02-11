namespace Bishop.UI.Web
{
    using System.Data.Entity;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using AutoMapper;

    using Bishop.Framework;
    using Bishop.Model;
    using Bishop.Model.Entities;
    using Bishop.Repositories;
    using Bishop.Services;
    using Bishop.UI.Web.App_Start;

    using Microsoft.Practices.Unity;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DontDropDbJustCreateTablesIfModelChangedStart.Start();
            this.RegisterTypes();
            this.MapModels();
        }

        private void RegisterTypes()
        {
            DependencyLocator.Locator = new Locator(new UnityContainer());
            DependencyLocator.Locator.RegisterType<DbContext, FormsContext>();
            DependencyLocator.Locator.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork>();
            DependencyLocator.Locator.RegisterType<IFormService, FormService>();
            DependencyLocator.Locator.RegisterType<IFillingSessionService, FillingSessionService>();
        }

        private void MapModels()
        {
            Mapper.CreateMap<Form, Models.Forms.UserForm>();
            Mapper.CreateMap<Topic, Models.Forms.Topic>();
            Mapper.CreateMap<Question, Models.Forms.Question>();
            Mapper.CreateMap<Answer, Models.Forms.Answer>();
        }
    }
}