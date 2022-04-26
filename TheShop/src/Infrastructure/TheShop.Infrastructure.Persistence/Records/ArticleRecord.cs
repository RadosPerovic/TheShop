using TheShop.Core.Domain.Entities;
using TheShop.Core.Domain.Entities.Articles;

namespace TheShop.Infrastructure.Persistence.Records
{
    public class ArticleRecord : Record<int>, IMapFrom<Article>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public List<OrderItemRecord> OrderItems { get; set; }
    }
}
