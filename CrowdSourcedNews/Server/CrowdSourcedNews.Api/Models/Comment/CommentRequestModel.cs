namespace CrowdSourcedNews.Api.Models.Comment
{
    using Infrastructure.Mappings;
    using CrowdSourcedNews.Models;
    using System.ComponentModel.DataAnnotations;

    public class CommentRequestModel : IMapFrom<Comment>
    {
        [Required]
        [MaxLength(10000)]
        public string Content { get; set; }

        public int NewsArticleId { get; set; }
    }
}