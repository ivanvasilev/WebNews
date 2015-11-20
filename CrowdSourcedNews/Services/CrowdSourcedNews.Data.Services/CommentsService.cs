namespace CrowdSourcedNews.Data.Services
{
    using System;
    using System.Linq;
    using Contracts;
    using Models;

    public class CommentsService : ICommentsService
    {
        private readonly IRepository<Comment> comments;

        private readonly IRepository<NewsArticle> newsArticles;

        private readonly IRepository<User> users;

        public CommentsService(IRepository<NewsArticle> newsArticleRepository, IRepository<Comment> commentsRepository, IRepository<User> usersRepository)
        {
            this.newsArticles = newsArticleRepository;
            this.comments = commentsRepository;
            this.users = usersRepository;
        }

        public int Add(Comment model, string username)
        {
            var currentUserId = this.users.All()
                .Where(u => u.UserName == username)
                .Select(u => u.Id)
                .First();
            
            model.AuthorId = currentUserId;
            
            this.comments.Add(model);

            this.comments.SaveChanges();

            var article = this.newsArticles
                .All()
                .FirstOrDefault(a => a.Id == model.NewsArticleId);

            article.Comments.Add(model);
            this.newsArticles.Update(article);
            
            return model.Id;
        }

        public IQueryable<Comment> All()
        {
            return this.comments.All();
        }

        public int SaveChanges()
        {
            return this.comments.SaveChanges();
        }
    }
}
