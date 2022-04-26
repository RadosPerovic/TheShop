using TheShop.Core.Domain.Entities;
using TheShop.Core.Domain.Entities.Suppliers;
using TheShop.Core.Domain.Enums;

namespace TheShop.Infrastructure.Persistence.Records
{
    public class SupplierRecord : Record<int>, IMapFrom<Supplier>
    {
        public string Name { get; set; }

        public List<OrderItemRecord> OrderItems { get; set; }
    }
}
