namespace CrowdSourcedNews.Data.Services.Contracts
{
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public interface INewsArticlesService
    {
        IQueryable<NewsArticle> All();

        //int Add(NewsArticle model, string username);

        int Add(string name, string content, int categoryId, ICollection<Image> images, string username);
    }
}
