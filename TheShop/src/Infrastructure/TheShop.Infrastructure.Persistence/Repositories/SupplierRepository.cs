using AutoMapper;
using TheShop.Core.Domain.Entities.Suppliers;
using TheShop.Infrastructure.Persistence.Records;
using TheShop.Infrastructure.Persistence.Repositories.Base;

namespace TheShop.Infrastructure.Persistence.Repositories
{
    public class SupplierRepository : Repository<Supplier, SupplierRecord>, ISupplierRepository
    {
        public SupplierRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<SupplierRecord> BaseQuery => _context.Suppliers;
    }
}
