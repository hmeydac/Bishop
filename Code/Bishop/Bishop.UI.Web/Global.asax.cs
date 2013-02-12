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
            
            container.RegisterType<DbContext, FormsContext>("FormContext");
            container.RegisterType<DbContext, CustomerContext>("CustomerContext");

            container.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork>("FormUnitOfWork", 
                new InjectionConstructor(new ResolvedParameter<DbContext>("FormContext")));
            container.RegisterType<IUnitOfWork, EntityFrameworkUnitOfWork>("CompanyUnitOfWork", 
                new InjectionConstructor(new ResolvedParameter<DbContext>("CustomerContext")));

            container.RegisterType<IFormService, FormService>(new InjectionConstructor(
                new ResolvedParameter<IUnitOfWork>("FormUnitOfWork")));
            container.RegisterType<IFillingSessionService, FillingSessionService>(
                new InjectionConstructor(new ResolvedParameter<IUnitOfWork>("FormUnitOfWork")));
            container.RegisterType<ICompanyService, CompanyService>(
                new InjectionConstructor(new ResolvedParameter<IUnitOfWork>("CompanyUnitOfWork")));
        }

        private void MapModels()
        {
            Mapper.CreateMap<Form, Models.Forms.UserForm>();
            Mapper.CreateMap<Topic, Models.Forms.Topic>();
            Mapper.CreateMap<Question, Models.Forms.Question>();
            Mapper.CreateMap<Answer, Models.Forms.Answer>();
            Mapper.CreateMap<Company, Models.Customer.Company>();
        }
    }
}