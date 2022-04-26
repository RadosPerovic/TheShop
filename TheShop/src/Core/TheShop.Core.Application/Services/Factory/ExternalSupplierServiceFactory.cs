using TheShop.Core.Application.Services.External;

namespace TheShop.Core.Application.Services.Factory
{
    public class ExternalSupplierServiceFactory : IExternalSupplierServiceFactory
    {
        private readonly IExternalSupplierTest1Service _supplierTest1Service;
        private readonly IExternalSupplierTest2Service _supplierTest2Service;
        private readonly IExternalSupplierTest3Service _supplierTest3Service;

        public ExternalSupplierServiceFactory(IExternalSupplierTest1Service supplierTest1Service, 
            IExternalSupplierTest2Service supplierTest2Service, 
            IExternalSupplierTest3Service supplierTest3Service)
        {
            _supplierTest1Service = supplierTest1Service;
            _supplierTest2Service = supplierTest2Service;
            _supplierTest3Service = supplierTest3Service;
        }

        public IExternalSupplierService Create(string supplierName)
        {
            if (string.IsNullOrEmpty(supplierName))
                throw new Exception();

            IExternalSupplierService service;

            switch (supplierName)
            {
                case "SupplierTest1":
                    service = _supplierTest1Service;
                    break;

                case "SupplierTest2":
                    service = _supplierTest2Service;
                    break;

                case "SupplierTest3":
                    service = _supplierTest3Service;
                    break;

                default:
                    service = null;
                    break;
            }

            return service;
        }
    }
}
