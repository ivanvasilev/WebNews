using CrowdSourcedNews.Api.Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;

namespace CrowdSourcedNews.Api.Models.Image
{
    public class ImageResponseModel : IMapFrom<CrowdSourcedNews.Models.Image>
    {
        public string Url { get; set; }
    }
}