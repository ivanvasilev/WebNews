namespace CrowdSourcedNews.Api.App_Start
{
    using CrowdSourcedNews.Data;
    using Data.Migrations;
    using System.Data.Entity;

    public static class DatabaseConfing
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CrowdSourcedNewsDbContext, Configuration>());
            CrowdSourcedNewsDbContext.Create().Database.Initialize(true);
        }
    }
}