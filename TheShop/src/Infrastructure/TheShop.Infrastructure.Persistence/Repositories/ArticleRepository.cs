using AutoMapper;
using TheShop.Core.Domain.Entities.Articles;
using TheShop.Infrastructure.Persistence.Records;
using TheShop.Infrastructure.Persistence.Repositories.Base;

namespace TheShop.Infrastructure.Persistence.Repositories
{
    public class ArticleRepository : Repository<Article, ArticleRecord>, IArticleRepository
    {
        public ArticleRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<ArticleRecord> BaseQuery => _context.Articles;
    }
}
