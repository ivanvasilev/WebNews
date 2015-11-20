namespace CrowdSourcedNews.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using CrowdSourcedNews.Models;

    public interface ICrowdSourcedNewsDbContext
    {
        IDbSet<NewsArticle> NewsArticles { get; set; }

        IDbSet<Image> Images { get; set; }

        IDbSet<Comment> Comments { get; set; }

        IDbSet<Category> Categories { get; set; }

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        void Dispose();
    }
}