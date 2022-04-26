using AutoMapper;
using TheShop.Core.Application.Services.External;
using TheShop.Core.Domain.Entities.Articles;

namespace TheShop.Infrastructure.External.Services
{
    public class ExternalSupplierTest3Service : IExternalSupplierTest3Service
    {
        private readonly IMapper _mapper;

        public ExternalSupplierTest3Service(IMapper mapper)
        {
            _mapper = mapper;
        }

        public SupplierArticle GetSupplierArticleById(int id)
        {
            var externalArticle = SupplierArticleDataHelper.GetArticleByIdSupplierTest3(id);

            return _mapper.Map<SupplierArticle>(externalArticle);
        }
    }
}
