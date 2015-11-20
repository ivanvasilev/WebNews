namespace CrowdSourcedNews.Api.Tests.RouteTests
{
    using System.Net.Http;

    using CrowdSourcedNews.Api.Controllers;
    using CrowdSourcedNews.Api.Models.NewsArticle;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MyTested.WebApi;

    [TestClass]
    public class ProjectsControllerTests
    {
        [TestMethod]
        public void GetShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/NewsArticles")
                .To<NewsArticlesController>(c => c.Get());
        }

        [TestMethod]
        public void GetWithIdShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/NewsArticles/1")
                .To<NewsArticlesController>(c => c.Get(1));
        }

        [TestMethod]
        public void GetWithCategoryShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/NewsArticles?category=TestCategory1")
                .To<NewsArticlesController>(c => c.Get("TestCategory1"));
        }

        [TestMethod]
        public void PostShouldMapCorrectly()
        {
            MyWebApi
                .Routes()
                .ShouldMap("api/NewsArticles")
                .WithHttpMethod(HttpMethod.Post)
                .WithJsonContent(@"{ ""Name"": ""TestArticle1"", ""Content"": ""TestContent"" }")
                .To<NewsArticlesController>(c => c.Post(new NewsArticleRequestModel()
                {
                    Name = "TestArticle1",
                    Content = "TestContent"
                }));
        }
    }
}
