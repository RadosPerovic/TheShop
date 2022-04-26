using TheShop.Core.Domain.Entities.Customers.ReadModels;
using TheShop.Core.Domain.Enums;

namespace TheShop.Core.Domain.Entities.Orders.ReadModels
{
    public class OrderReadModel : IEntity
    {
        public int Id { get; set; }
        public CustomerReadModel Customer { get; set; }
        public OrderStatusType OrderStatus { get; set; }
        public decimal Total { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? PlacedDate { get; set; }
        public List<OrderItemReadModel> OrderItems { get; set; }
    }
}
