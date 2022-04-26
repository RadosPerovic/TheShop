using AutoMapper;
using TheShop.Core.Domain.Entities.Articles;
using TheShop.Infrastructure.External.Records;

namespace TheShop.Infrastructure.External.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SupplierArticleExternalRecord, SupplierArticle>()
                .ForMember(dest => dest.Supplier, opt => opt.Ignore());
        }
    }
}
