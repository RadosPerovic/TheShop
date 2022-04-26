using TheShop.Core.Domain.Entities.Orders.ReadModels;

namespace TheShop.Core.Domain.Entities.Orders
{
    public interface IOrderReadOnlyRepository : IReadOnlyRepository<OrderReadModel>
    {

    }
}
