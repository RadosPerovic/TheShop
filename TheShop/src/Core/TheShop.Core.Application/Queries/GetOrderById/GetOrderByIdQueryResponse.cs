using TheShop.Core.Domain.Entities.Orders.ReadModels;

namespace TheShop.Core.Application.Queries.GetOrderById
{
    public class GetOrderByIdQueryResponse
    {
        public OrderReadModel Order { get; set; }
    }
}
