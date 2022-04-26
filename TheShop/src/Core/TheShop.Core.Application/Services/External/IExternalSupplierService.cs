using TheShop.Core.Domain.Entities.Articles;

namespace TheShop.Core.Application.Services.External
{
    public interface IExternalSupplierService
    {
        SupplierArticle GetSupplierArticleById(int id);
    }
}
