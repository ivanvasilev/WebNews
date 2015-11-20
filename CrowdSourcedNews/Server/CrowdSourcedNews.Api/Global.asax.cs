namespace CrowdSourcedNews.Api
{
    using System.Reflection;

    using App_Start;
    using System.Web.Http;

    using CrowdSourcedNews.Common;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load(Assemblies.WebApi));
            DatabaseConfing.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
