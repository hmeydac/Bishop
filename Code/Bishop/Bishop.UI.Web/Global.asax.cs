namespace Bishop.UI.Web
{
    using System.Data.Entity;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using AutoMapper;

    using Bishop.Model;
    using Bishop.Model.Entities;
    using Bishop.Repositories;
    using Bishop.Services;
    using Bishop.UI.Web.App_Start;

    using Microsoft.Practices.Unity;

    public class MvcApplication : System.Web.HttpApplication
    {
        public void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            this.RegisterTypes();
            this.MapModels();
        }

        private void RegisterTypes()
        {
            var container = new UnityContainer();
            DependencyInjectionConfig.RegisterDependencyResolver(container);
            container.RegisterType<DbContext, FormsContext>();
            container.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork>();
            container.RegisterType<IFormService, FormService>();
            container.RegisterType<IFillingSessionService, FillingSessionService>();
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