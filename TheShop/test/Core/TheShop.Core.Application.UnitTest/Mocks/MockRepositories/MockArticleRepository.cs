using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheShop.Core.Domain.Entities.Articles;

namespace TheShop.Core.Application.UnitTest.Mocks.MockRepositories
{
    public static class MockArticleRepository
    {
        public static Mock<IArticleRepository> GetArticleRepository()
        {
            var articles = new Dictionary<int, Article>();
            var article1 = Article.Create("Article1", "this is some desc1");
            var article2 = Article.Create("Article2", "this is some desc2");
            articles.Add(1, article1);
            articles.Add(2, article2);

            var mockRepository = new Mock<IArticleRepository>();

            mockRepository.Setup(e => e.GetByIdAsync(It.IsAny<int>())).Returns((int id) =>
            {
                return Task.FromResult(articles.ContainsKey(id) ? articles[id] : null);
            });

            return mockRepository;
        }
    }
}
