namespace CrowdSourcedNews.Data
{
    using CrowdSourcedNews.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class CrowdSourcedNewsDbContext : IdentityDbContext<User>, ICrowdSourcedNewsDbContext
    {
        public CrowdSourcedNewsDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<NewsArticle> NewsArticles { get; set; }

        public virtual IDbSet<Image> Images { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Category> Categories { get; set; }

        public static CrowdSourcedNewsDbContext Create()
        {
            return new CrowdSourcedNewsDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
