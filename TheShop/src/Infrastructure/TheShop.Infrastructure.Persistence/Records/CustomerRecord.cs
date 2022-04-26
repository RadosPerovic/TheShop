using TheShop.Core.Domain.Entities;
using TheShop.Core.Domain.Entities.Customers;

namespace TheShop.Infrastructure.Persistence.Records
{
    public class CustomerRecord : Record<int>, IMapFrom<Customer>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public List<OrderRecord> Orders { get; set; }
    }
}
