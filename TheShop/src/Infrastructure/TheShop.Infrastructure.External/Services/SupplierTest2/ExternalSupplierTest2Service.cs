using AutoMapper;
using TheShop.Core.Application.Services.External;
using TheShop.Core.Domain.Entities.Articles;

namespace TheShop.Infrastructure.External.Services
{
    public class ExternalSupplierTest2Service : IExternalSupplierTest2Service
    {
        private readonly IMapper _mapper;

        public ExternalSupplierTest2Service(IMapper mapper)
        {
            _mapper = mapper;
        }

        public SupplierArticle GetSupplierArticleById(int id)
        {
            var externalArticle = SupplierArticleDataHelper.GetArticleByIdSupplierTest2(id);

            return _mapper.Map<SupplierArticle>(externalArticle);
        }
    }
}
