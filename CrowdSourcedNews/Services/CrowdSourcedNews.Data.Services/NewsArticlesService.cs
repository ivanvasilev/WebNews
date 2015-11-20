namespace CrowdSourcedNews.Data.Services
{
    using System;
    using System.Linq;

    using CrowdSourcedNews.Data.Services.Contracts;
    using CrowdSourcedNews.Models;
    using System.Collections.Generic;

    public class NewsArticlesService : INewsArticlesService
    {
        private readonly IRepository<NewsArticle> newsArticles;

        private readonly IRepository<User> users;

        public NewsArticlesService(IRepository<NewsArticle> newsArticleRepository, IRepository<User> usersRepository)
        {
            this.newsArticles = newsArticleRepository;
            this.users = usersRepository;
        }

        public IQueryable<NewsArticle> All()
        {
            var result = this.newsArticles.All();

            return result;
        }

        //public int Add(NewsArticle model, string username)
        //{
        //    var currentUser = this.users.All().FirstOrDefault(u => u.UserName == username);

        //    if (currentUser == null)
        //    {
        //        throw new ArgumentException("Current user cannot be found!");
        //    }

        //    model.Author = currentUser;

        //    this.newsArticles.Add(model);
        //    this.newsArticles.SaveChanges();

        //    return model.Id;
        //}

        public int Add(string name, string content, int categoryId, ICollection<Image> images, string username)
        {
            var currentUser = this.users.All().FirstOrDefault(u => u.UserName == username);

            if (currentUser == null)
            {
                throw new ArgumentException("Current user cannot be found!");
            }

            var articleToAdd = new NewsArticle()
            {
                Name = name,
                Content = content,
                CategoryId = categoryId,
                Images = images,
                Author = currentUser,
                CreatedOn = DateTime.Now
            };

            this.newsArticles.Add(articleToAdd);
            this.newsArticles.SaveChanges();

            return articleToAdd.Id;
        }
    }
}