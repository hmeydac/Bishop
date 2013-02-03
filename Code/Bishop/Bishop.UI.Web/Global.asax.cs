namespace Bishop.UI.Web
{
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using AutoMapper;

    using Bishop.Model.Entities;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            this.MapModels();
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