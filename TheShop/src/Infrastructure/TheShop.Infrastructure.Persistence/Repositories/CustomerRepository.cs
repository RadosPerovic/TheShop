using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TheShop.Core.Domain.Entities.Customers;
using TheShop.Infrastructure.Persistence.Records;
using TheShop.Infrastructure.Persistence.Repositories.Base;

namespace TheShop.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer, CustomerRecord>, ICustomerRepository
    {
        public CustomerRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        protected override IQueryable<CustomerRecord> BaseQuery => _context.Customers;
    }
}
