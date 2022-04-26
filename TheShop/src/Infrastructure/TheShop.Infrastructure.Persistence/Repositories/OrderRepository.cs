using AutoMapper;
using TheShop.Core.Domain.Entities.Orders;
using TheShop.Infrastructure.Persistence.Records;
using TheShop.Infrastructure.Persistence.Repositories.Base;

namespace TheShop.Infrastructure.Persistence.Repositories
{
    public class OrderRepository : Repository<Order, OrderRecord>, IOrderRepository
    {
        public OrderRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<OrderRecord> BaseQuery => _context.Orders;
    }
}
