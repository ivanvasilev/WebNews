namespace CrowdSourcedNews.Api.Tests
{
    using System.Reflection;
    using System.Web.Http;

    using CrowdSourcedNews.Common;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MyTested.WebApi;

    [TestClass]
    public class TestInitialize
    {
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            AutoMapperConfig.RegisterMappings(Assembly.Load(Assemblies.WebApi));
            
            MyWebApi.IsRegisteredWith(WebApiConfig.Register);
        }
    }
}