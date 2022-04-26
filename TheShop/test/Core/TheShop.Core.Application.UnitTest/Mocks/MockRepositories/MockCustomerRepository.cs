using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheShop.Core.Domain.Entities.Customers;

namespace TheShop.Core.Application.UnitTest.Mocks.MockRepositories
{
    public static class MockCustomerRepository
    {
        public static Mock<ICustomerRepository> GetCustomerRepository()
        {
            var customer1 = Customer.Create("CustomerName1", "CustomerSurname1", "customer1@gmail.com");
            var customer2 = Customer.Create("CustomerName2", "CustomerSurname2", "customer2@gmail.com");
            var customers = new Dictionary<int, Customer>();
            customers.Add(1, customer1);
            customers.Add(2, customer2);

            var mockRepository = new Mock<ICustomerRepository>();
            mockRepository.Setup(e => e.GetByIdAsync(It.IsAny<int>())).Returns((int id) =>
            {
                return Task.FromResult(customers.ContainsKey(id) ? customers[id] : null);
            });

            return mockRepository;
        }
    }
}
