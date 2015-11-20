namespace CrowdSourcedNews.Api.Tests.ControllerTests
{
    using System.Collections.Generic;

    using CrowdSourcedNews.Api.Controllers;
    using CrowdSourcedNews.Api.Models.NewsArticle;
    using CrowdSourcedNews.Api.Tests.Setups;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using MyTested.WebApi;

    [TestClass]
    public class NewsArticlesControllerTests
    {
        private IControllerBuilder<NewsArticlesController> controller;

        [TestInitialize]
        public void Init()
        {
            this.controller =
                MyWebApi.Controller<NewsArticlesController>()
                    .WithResolvedDependencies(Services.GetNewsArticlesService(), Services.GetPubnubBroadcaster());
        }

        [TestMethod]
        public void GetShouldReturnOkWithProperResponse()
        {
            this.controller.Calling(c => c.Get())
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<NewsArticleResponseModel>>()
                .Passing(na => na.Count == 12);
        }

        [TestMethod]
        public void GetShouldReturnNotFoundWhenInvalidCategoryIsProvided()
        {
            this.controller.Calling(c => c.Get("IvalidCategory")).ShouldReturn().NotFound();
        }

        [TestMethod]
        public void GetShouldReturnOkWithProperResponseWhenValidCategoryIsProvided()
        {
            this.controller.Calling(c => c.Get("TestCatergory1"))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<List<NewsArticleResponseModel>>()
                .Passing(na => na.Count == 2);
        }

        [TestMethod]
        public void GetShouldReturnOkWithProperResponseWhenValidIdIsProvided()
        {
            this.controller.Calling(c => c.Get(2))
                .ShouldReturn()
                .Ok()
                .WithResponseModelOfType<NewsArticleResponseModel>()
                .Passing(na => na.Id == 2);
        }

        [TestMethod]
        public void GetShouldReturnNotFoundWhenInvalidIdIsProvided()
        {
            this.controller.Calling(c => c.Get(50)).ShouldReturn().NotFound();
        }

        [TestMethod]
        public void GetByIdShouldReturnBadRequestWithNullCategory()
        {
            this.controller.Calling(c => c.Get(null))
                .ShouldReturn()
                .BadRequest()
                .WithErrorMessage("Category name cannot be null or empty.");
        }

        [TestMethod]
        public void GetByIdShouldReturnBadRequestWithEmptyCategory()
        {
            this.controller.Calling(c => c.Get(string.Empty))
                .ShouldReturn()
                .BadRequest()
                .WithErrorMessage("Category name cannot be null or empty.");
        }

        [TestMethod]
        public void PostShouldHaveAuthorizedAttribute()
        {
            this.controller.Calling(c => c.Post(new NewsArticleRequestModel()))
                .ShouldHave()
                .ActionAttributes(attr => attr.RestrictingForAuthorizedRequests());
        }

        [TestMethod]
        public void PostShouldValidateModelState()
        {
            this.controller.Calling(c => c.Post(new NewsArticleRequestModel { Name = new string('s', 201) }))
                .ShouldHave()
                .InvalidModelState();
        }

        [TestMethod]
        public void PostShouldReturnBadRequestWithInvalidModel()
        {
            this.controller.Calling(c => c.Post(new NewsArticleRequestModel { Name = new string('s', 201) }))
                .ShouldReturn()
                .BadRequest()
                .WithModelStateFor<NewsArticleRequestModel>()
                .ContainingModelStateErrorFor(m => m.Name);
        }
    }
}