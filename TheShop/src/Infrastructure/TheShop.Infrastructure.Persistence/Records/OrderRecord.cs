using TheShop.Core.Domain.Entities;
using TheShop.Core.Domain.Entities.Orders;
using TheShop.Core.Domain.Entities.Orders.ReadModels;
using TheShop.Core.Domain.Enums;

namespace TheShop.Infrastructure.Persistence.Records
{
    public class OrderRecord : Record<int>, IMapFrom<Order>, IMapFrom<OrderReadModel>
    {
        public int CustomerId { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public OrderStatusType OrderStatusId { get; set; }
        public DateTime? PlacedDate { get; set; }

        public CustomerRecord Customer { get; set; }
        public OrderStatusTypeRecord OrderStatus { get; set; }
        public List<OrderItemRecord> OrderItems { get; set; }
    }
}
