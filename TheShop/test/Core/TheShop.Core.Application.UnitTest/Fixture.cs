
using Moq;
using TheShop.Core.Application.Commands.CreateOrder;
using TheShop.Core.Application.Services;
using TheShop.Core.Application.Services.External;
using TheShop.Core.Application.Services.Factory;
using TheShop.Core.Application.UnitTest.Mocks.MockExternalServices;
using TheShop.Core.Application.UnitTest.Mocks.MockRepositories;
using TheShop.Core.Domain.Entities.Articles;
using TheShop.Core.Domain.Entities.Customers;
using TheShop.Core.Domain.Entities.Orders;
using TheShop.Core.Domain.Entities.Suppliers;

namespace TheShop.Core.Application.UnitTest
{
    public class Fixture
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        private readonly Mock<ISupplierRepository> _mockSupplierRepository;
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IArticleRepository> _mockArticleRepository;
        private readonly Mock<IExternalSupplierTest1Service> _externalSupplierTest1Service;
        private readonly Mock<IExternalSupplierTest2Service> _externalSupplierTest2Service;
        private readonly Mock<IExternalSupplierTest3Service> _externalSupplierTest3Service;

        public Fixture()
        {
            _mockCustomerRepository = MockCustomerRepository.GetCustomerRepository();
            _mockSupplierRepository = MockSupplierRepository.GetSupplierRepository();
            _mockOrderRepository = MockOrderRepository.GetOrderRepository();
            _mockArticleRepository = MockArticleRepository.GetArticleRepository();
            _externalSupplierTest1Service = MockExternalSupplierTest1Service.GetExternalSupplierTest1Service();
            _externalSupplierTest2Service = MockExternalSupplierTest2Service.GetExternalSupplierTest2Service();
            _externalSupplierTest3Service = MockExternalSupplierTest3Service.GetExternalSupplierTest3Service();
        }

        public CreateOrderCommandHandler GetCreateOrderHandler()
        {
            IExternalSupplierServiceFactory factory = new ExternalSupplierServiceFactory(_externalSupplierTest1Service.Object,
                _externalSupplierTest2Service.Object,
                _externalSupplierTest3Service.Object);

            ISupplierArticleService supplierArticleService = new SupplierArticleService(_mockSupplierRepository.Object,
                factory);

            var handler = new CreateOrderCommandHandler(_mockCustomerRepository.Object,
                _mockOrderRepository.Object,
                _mockArticleRepository.Object,
                supplierArticleService);

            return handler;
        }
    }
}
