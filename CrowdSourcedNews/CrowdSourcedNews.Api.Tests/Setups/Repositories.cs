namespace CrowdSourcedNews.Api.Tests.Setups
{
    using System.Collections.Generic;
    using System.Linq;

    using CrowdSourcedNews.Data;
    using CrowdSourcedNews.Models;

    using Moq;

    public static class Repositories
    {
        public static IRepository<NewsArticle> GetNewsArticleRepository()
        {
            var repository = new Mock<IRepository<NewsArticle>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<NewsArticle>
                {
                    new NewsArticle { Id = 1, Name = "TestArticle1", Author = new User {Email = "TestUser1"}, Category = new Category {Name = "TestCatergory1"} },
                    new NewsArticle { Id = 2, Name = "TestArticle2", Author = new User {Email = "TestUser2"}, Category = new Category {Name = "TestCatergory2"} },
                    new NewsArticle { Id = 3, Name = "TestArticle3", Author = new User {Email = "TestUser3"}, Category = new Category {Name = "TestCatergory3"} },
                    new NewsArticle { Id = 4, Name = "TestArticle4", Author = new User {Email = "TestUser4"}, Category = new Category {Name = "TestCatergory4"} },
                    new NewsArticle { Id = 5, Name = "TestArticle5", Author = new User {Email = "TestUser5"}, Category = new Category {Name = "TestCatergory5"} },
                    new NewsArticle { Id = 6, Name = "TestArticle6", Author = new User {Email = "TestUser6"}, Category = new Category {Name = "TestCatergory6"} },
                    new NewsArticle { Id = 7, Name = "TestArticle7", Author = new User {Email = "TestUser7"}, Category = new Category {Name = "TestCatergory7"} },
                    new NewsArticle { Id = 8, Name = "TestArticle8", Author = new User {Email = "TestUser8"}, Category = new Category {Name = "TestCatergory8"} },
                    new NewsArticle { Id = 9, Name = "TestArticle9", Author = new User {Email = "TestUser9"}, Category = new Category {Name = "TestCatergory9"} },
                    new NewsArticle { Id = 10, Name = "TestArticle10", Author = new User {Email = "TestUser1"}, Category = new Category {Name = "TestCatergory1"} },
                    new NewsArticle { Id = 11, Name = "TestArticle11", Author = new User {Email = "TestUser2"}, Category = new Category {Name = "TestCatergory2"} },
                    new NewsArticle { Id = 12, Name = "TestArticle12", Author = new User {Email = "TestUser3"}, Category = new Category {Name = "TestCatergory3"} }
                    }.AsQueryable();
            });

            return repository.Object;
        }

        public static IRepository<User> GetUsersRepository()
        {
            var repository = new Mock<IRepository<User>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<User>
                {
                    new User { Email = "TestUser 1" },
                    new User { Email = "TestUser 2"},
                    new User { Email = "TestUser 3" },
                    new User { Email = "TestUser 4" },
                    new User { Email = "TestUser 5" },
                    new User { Email = "TestUser 6"},
                    new User { Email = "TestUser 7"},
                    new User { Email = "TestUser 8" },
                    new User { Email = "TestUser 9" },
                    new User { Email = "TestUser 10"},
                }.AsQueryable();
            });

            return repository.Object;
        }

        public static IRepository<Comment> GetCommentRepository()
        {
            var repository = new Mock<IRepository<Comment>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<Comment>
                {
                    new Comment {Author = new User {Email = "TestUser1"}, Content = "TestComment1"},
                    new Comment {Author = new User {Email = "TestUser2"}, Content = "TestComment2"},
                    new Comment {Author = new User {Email = "TestUser3"}, Content = "TestComment3"},
                    new Comment {Author = new User {Email = "TestUser4"}, Content = "TestComment4"},
                    new Comment {Author = new User {Email = "TestUser5"}, Content = "TestComment5"},
                    new Comment {Author = new User {Email = "TestUser6"}, Content = "TestComment6"},
                    new Comment {Author = new User {Email = "TestUser7"}, Content = "TestComment7"},
                    new Comment {Author = new User {Email = "TestUser8"}, Content = "TestComment8"},
                    new Comment {Author = new User {Email = "TestUser9"}, Content = "TestComment9"},
                    new Comment {Author = new User {Email = "TestUser10"}, Content = "TestComment10"},
                }.AsQueryable();
            });

            return repository.Object;
        }

        public static IRepository<Category> GetCategoryRepository()
        {
            var repository = new Mock<IRepository<Category>>();

            repository.Setup(r => r.All()).Returns(() =>
            {
                return new List<Category>
                {
                    new Category {Name = "TestCategory1"},
                    new Category {Name = "TestCategory2"},
                    new Category {Name = "TestCategory3"},
                    new Category {Name = "TestCategory4"},
                    new Category {Name = "TestCategory5"},
                    new Category {Name = "TestCategory6"},
                    new Category {Name = "TestCategory7"},
                    new Category {Name = "TestCategory8"},
                    new Category {Name = "TestCategory9"},
                    new Category {Name = "TestCategory10"}
                    }.AsQueryable();
            });

            return repository.Object;
        }
    }
}