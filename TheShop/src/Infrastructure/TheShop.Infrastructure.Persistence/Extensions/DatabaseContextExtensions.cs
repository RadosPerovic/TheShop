using Microsoft.EntityFrameworkCore;
using TheShop.Infrastructure.Persistence.Records;

namespace TheShop.Infrastructure.Persistence.Extensions
{
    public static class DatabaseContextExtensions
    {
        public static IQueryable<OrderRecord> IncludeForReadModel(this IQueryable<OrderRecord> query) =>
            query.IncludeCustomer()
                 .IncludeOrderItems()
                 .IncludeOrderItemArticle()
                 .IncludeOrderItemSupplier();

        public static IQueryable<OrderRecord> IncludeCustomer(this IQueryable<OrderRecord> query) =>
            query.Include(e => e.Customer);

        public static IQueryable<OrderRecord> IncludeOrderItems(this IQueryable<OrderRecord> query) =>
            query.Include(e => e.OrderItems);

        public static IQueryable<OrderRecord> IncludeOrderItemArticle(this IQueryable<OrderRecord> query) =>
            query.Include(e => e.OrderItems)
                    .ThenInclude(e => e.Article);

        public static IQueryable<OrderRecord> IncludeOrderItemSupplier(this IQueryable<OrderRecord> query) =>
            query.Include(e => e.OrderItems)
                    .ThenInclude(e => e.Supplier);
    }
}
