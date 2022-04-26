
using TheShop.Core.Domain.Enums;

namespace TheShop.Infrastructure.Persistence.Records
{
    public class OrderStatusTypeRecord : Record<OrderStatusType>
    {
        public string Name { get; set; }

        public List<OrderRecord> Orders { get; set; }
    }
}
