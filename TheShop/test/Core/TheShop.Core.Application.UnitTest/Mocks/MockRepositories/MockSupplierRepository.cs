using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TheShop.Core.Domain.Entities.Suppliers;

namespace TheShop.Core.Application.UnitTest.Mocks.MockRepositories
{
    public static class MockSupplierRepository
    {
        public static Mock<ISupplierRepository> GetSupplierRepository()
        {
            var suppliers = new List<Supplier>()
            {
                Supplier.Create("SupplierTest1"),
                Supplier.Create("SupplierTest2"),
                Supplier.Create("SupplierTest3"),
            };

            var mockRepository = new Mock<ISupplierRepository>();

            mockRepository.Setup(e => e.GetAllAsync()).Returns(() =>
            {
                return Task.FromResult(suppliers);
            });

            return mockRepository;
        }
    }
}
