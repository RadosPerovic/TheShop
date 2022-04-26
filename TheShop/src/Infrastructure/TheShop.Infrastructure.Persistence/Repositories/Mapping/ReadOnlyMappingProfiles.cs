using AutoMapper;
using TheShop.Core.Domain.Entities.Customers;
using TheShop.Core.Domain.Entities.Customers.ReadModels;
using TheShop.Core.Domain.Entities.Orders.ReadModels;
using TheShop.Infrastructure.Persistence.Records;

namespace TheShop.Infrastructure.Persistence.Repositories.Mapping
{
    public class ReadOnlyMappingProfiles : Profile
    {
        public ReadOnlyMappingProfiles()
        {
            CreateMap<CustomerRecord, CustomerReadModel>();

            CreateMap<OrderRecord, OrderReadModel>()
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(e => e.OrderStatusId));

            CreateMap<OrderItemRecord, OrderItemReadModel>()
                .ForMember(dest => dest.ArticleId, opt => opt.MapFrom(e => e.Article.Id))
                .ForMember(dest => dest.ArticleName, opt => opt.MapFrom(e => e.Article.Name))
                .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(e => e.Supplier.Id))
                .ForMember(dest => dest.SupplierName, opt => opt.MapFrom(e => e.Supplier.Name));

        }
    }
}
