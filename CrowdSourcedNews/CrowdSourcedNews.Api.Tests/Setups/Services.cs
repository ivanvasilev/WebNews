namespace CrowdSourcedNews.Api.Tests.Setups
{
    using CrowdSourcedNews.Data.Services;
    using CrowdSourcedNews.Data.Services.Contracts;
    using CrowdSourcedNews.Notification.Services;

    using Moq;

    public static class Services
    {
        public static INewsArticlesService GetNewsArticlesService()
        {
            return new NewsArticlesService(Repositories.GetNewsArticleRepository(), Repositories.GetUsersRepository());
        }

        public static ICommentsService GetGamesService()
        {
            return new CommentsService(Repositories.GetNewsArticleRepository(), Repositories.GetCommentRepository(), Repositories.GetUsersRepository());
        }

        public static ICategoriesService GetGuessService()
        {
            return new CategoriesService(Repositories.GetCategoryRepository());
        }

        public static IPubnubBroadcaster GetPubnubBroadcaster()
        {
            var pubNub = new Mock<IPubnubBroadcaster>();

            pubNub.Setup(r => r.SendNotification(It.IsAny<string>(),
                    It.IsAny<string>())).Verifiable();

            return pubNub.Object;
        }
    }
}