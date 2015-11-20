using CrowdSourcedNews.Api.Infrastructure.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using AutoMapper;

using CrowdSourcedNews.Models;

namespace CrowdSourcedNews.Api.Models.Comment
{
    public class CommentResponseModel : IMapFrom<CrowdSourcedNews.Models.Comment>, IHaveCustomMappings
    {
        public string Author { get; set; }

        public string Content { get; set; }

        public void CreateMappings(IConfiguration config)
        {
            config.CreateMap<CrowdSourcedNews.Models.Comment, CommentResponseModel>()
                .ForMember(p => p.Author, opts => opts.MapFrom(p => p.Author.UserName));
        }
    }
}