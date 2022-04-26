using TheShop.Core.Application.Responses;
using TheShop.Core.Domain.Entities.Articles;

namespace TheShop.Core.Application.Services
{
    public interface ISupplierArticleService
    {
        Task<Result<List<SupplierArticle>>> GetSupplierArticlesById(int articleId);
    }
}
