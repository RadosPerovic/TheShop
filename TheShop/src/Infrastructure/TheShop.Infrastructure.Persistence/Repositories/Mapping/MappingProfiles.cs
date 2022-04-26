using AutoMapper;
using TheShop.Core.Domain.Entities.Articles;
using TheShop.Core.Domain.Entities.Customers;
using TheShop.Core.Domain.Entities.Orders;
using TheShop.Core.Domain.Entities.Suppliers;
using TheShop.Core.Domain.Enums;
using TheShop.Infrastructure.Persistence.Records;

namespace TheShop.Infrastructure.Persistence.Repositories.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CustomerRecord>()
                .ReverseMap();

            CreateMap<Article, ArticleRecord>()
                .ReverseMap();

            CreateMap<Supplier, SupplierRecord>()
                .ReverseMap();

            CreateMap<Order, OrderRecord>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(e => e.Customer.Id))
                .ForMember(dest => dest.OrderStatusId, opt => opt.MapFrom(e => e.OrderStatus))
                .ForMember(dest => dest.Customer, opt => opt.Ignore())
                .ForMember(dest => dest.OrderStatus, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<OrderItem, OrderItemRecord>()
                .ForMember(dest => dest.ArticleId, opt => opt.MapFrom(e => e.SupplierArticle.Id))
                .ForMember(dest => dest.SupplierId, opt => opt.MapFrom(e => e.SupplierArticle.Supplier.Id))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(e => e.Quantity))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(e => e.SupplierArticle.Price))
                .ForMember(dest => dest.Supplier, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
