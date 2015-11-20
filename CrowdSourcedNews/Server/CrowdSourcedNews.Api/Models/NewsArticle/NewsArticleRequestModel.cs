namespace CrowdSourcedNews.Api.Models.NewsArticle
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using CrowdSourcedNews.Api.Infrastructure.Mappings;
    using CrowdSourcedNews.Models;
    using Image;

    public class NewsArticleRequestModel
    {
        [MaxLength(200)]
        public string Name { get; set; }

        [MaxLength(100000)]
        public string Content { get; set; }

        public int CategoryId { get; set; }

        public DateTime CreatedOn { get; set; }

        public virtual Category Category { get; set; }

        public ICollection<ImageRequestModel> Images { get; set; }
    }
}