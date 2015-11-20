namespace CrowdSourcedNews.Api.Controllers
{
    using AutoMapper;
    using Data.Services.Contracts;
    using CrowdSourcedNews.Models;
    using Models.Comment;
    using System.Web.Http;

    public class CommentsController : ApiController
    {
        private readonly ICommentsService comments;

        public CommentsController(ICommentsService comments)
        {
            this.comments = comments;
        }
        
        [Authorize]
        //[Route("~/api/newsarticles/{id}")]
        [HttpPost]
        public IHttpActionResult PostComment(CommentRequestModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var dataModel = Mapper.Map<Comment>(model);

            var commentId = this.comments.Add(dataModel, this.User.Identity.Name);

            return this.Ok(commentId);
        }
    }
}