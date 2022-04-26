using TheShop.Core.Application.Responses;
using TheShop.Core.Application.Services.Factory;
using TheShop.Core.Domain.Entities.Articles;
using TheShop.Core.Domain.Entities.Suppliers;

namespace TheShop.Core.Application.Services
{
    public class SupplierArticleService : ISupplierArticleService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IExternalSupplierServiceFactory _externalSupplierServiceFactory;

        public SupplierArticleService(ISupplierRepository supplierRepository, 
            IExternalSupplierServiceFactory externalSupplierServiceFactory)
        {
            _supplierRepository = supplierRepository;
            _externalSupplierServiceFactory = externalSupplierServiceFactory;
        }

        public async Task<Result<List<SupplierArticle>>> GetSupplierArticlesById(int articleId)
        {
            var suppliers = await _supplierRepository.GetAllAsync();
            if (suppliers is null)
                return Result<List<SupplierArticle>>.Failure(Messages.SuppliersNotFound);

            var supplierArticles = new List<SupplierArticle>();

            foreach (var supplier in suppliers)
            {
                var externalSupplierService = _externalSupplierServiceFactory.Create(supplier.Name);
                if (externalSupplierService is null)
                    return Result<List<SupplierArticle>>.Failure(string.Format(Messages.ExternalServiceNotFound, supplier.Id, supplier.Name));

                var supplierArticle = externalSupplierService.GetSupplierArticleById(articleId);
                if (supplierArticle is null)
                    return Result<List<SupplierArticle>>.Failure(string.Format(Messages.ExternalArticleNotFound, articleId, supplier.Id));

                supplierArticle.SetSupplier(supplier);

                supplierArticles.Add(supplierArticle);
            }

            return Result<List<SupplierArticle>>.Success(supplierArticles);
        }
    }
}
