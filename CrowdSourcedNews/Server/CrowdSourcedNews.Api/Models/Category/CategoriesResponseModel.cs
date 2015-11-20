using CrowdSourcedNews.Api.Infrastructure.Mappings;
using CrowdSourcedNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace CrowdSourcedNews.Api.Models.Category
{
    public class CategoriesResponseModel : IMapFrom<CrowdSourcedNews.Models.Category>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<CrowdSourcedNews.Models.Category, CategoriesResponseModel>();
        }
    }
}