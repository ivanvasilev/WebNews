using AutoMapper;
using AutoMapper.QueryableExtensions;
using CrowdSourcedNews.Api.Models.Category;
using CrowdSourcedNews.Data.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrowdSourcedNews.Api.Controllers
{
    public class CategoriesController : ApiController
    {
        private readonly ICategoriesService categories;

        public CategoriesController(ICategoriesService categories)
        {
            this.categories = categories;
        }

        public IHttpActionResult Get()
        {
            var result = this.categories
                .All()
                .ProjectTo<CategoriesResponseModel>()
                .ToList();

            if (result.Count == 0)
            {
                return this.NotFound();
            }

            return this.Ok(result);
        }
    }
}
