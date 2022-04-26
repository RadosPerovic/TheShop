using TheShop.Core.Application.Services.External;

namespace TheShop.Core.Application.Services.Factory
{
    public interface IExternalSupplierServiceFactory
    {
        IExternalSupplierService Create(string supplierName);
    }
}
