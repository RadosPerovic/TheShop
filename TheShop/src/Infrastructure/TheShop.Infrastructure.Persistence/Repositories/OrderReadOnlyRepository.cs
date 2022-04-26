using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheShop.Core.Domain.Entities.Orders;
using TheShop.Core.Domain.Entities.Orders.ReadModels;
using TheShop.Infrastructure.Persistence.Extensions;
using TheShop.Infrastructure.Persistence.Records;
using TheShop.Infrastructure.Persistence.Repositories.Base;

namespace TheShop.Infrastructure.Persistence.Repositories
{
    public class OrderReadOnlyRepository : ReadOnlyRepository<OrderReadModel, OrderRecord>, IOrderReadOnlyRepository
    {
        public OrderReadOnlyRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<OrderRecord> BaseQuery => _context.Orders
                                                                    .IncludeForReadModel();
    }
}
