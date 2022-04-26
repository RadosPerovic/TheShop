using Moq;
using System.Threading.Tasks;
using TheShop.Core.Domain.Entities.Orders;

namespace TheShop.Core.Application.UnitTest.Mocks.MockRepositories
{
    public static class MockOrderRepository
    {
        public static Mock<IOrderRepository> GetOrderRepository()
        {
            var mockRepository = new Mock<IOrderRepository>();

            mockRepository.Setup(e => e.AddAsync(It.IsAny<Order>())).Returns((Order order) =>
            {
                return Task.CompletedTask;
            });

            mockRepository.Setup(e => e.SaveChangesAsync()).Returns(() =>
            {
                return Task.CompletedTask;
            });

            return mockRepository;
        }
    }
}
