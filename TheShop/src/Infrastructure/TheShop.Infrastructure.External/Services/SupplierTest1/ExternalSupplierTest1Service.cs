using AutoMapper;
using TheShop.Core.Application.Services.External;
using TheShop.Core.Domain.Entities.Articles;

namespace TheShop.Infrastructure.External.Services
{
    public class ExternalSupplierTest1Service : IExternalSupplierTest1Service
    {
        private readonly IMapper _mapper;

        public ExternalSupplierTest1Service(IMapper mapper)
        {
            _mapper = mapper;
        }

        public SupplierArticle GetSupplierArticleById(int id)
        {
            var externalArticle = SupplierArticleDataHelper.GetArticleByIdSupplierTest1(id);

            return _mapper.Map<SupplierArticle>(externalArticle);
        }
    }
}
