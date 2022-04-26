using Moq;
using System.Collections.Generic;
using TheShop.Core.Application.Services.External;
using TheShop.Core.Domain.Entities.Articles;
using TheShop.Core.Domain.Entities.Suppliers;

namespace TheShop.Core.Application.UnitTest.Mocks.MockExternalServices
{
    public static class MockExternalSupplierTest1Service
    {
        public static Mock<IExternalSupplierTest1Service> GetExternalSupplierTest1Service()
        {
            var supplierArticles = new Dictionary<int, SupplierArticle>();
            var supplier = Supplier.Create("SupplierTest1");

            var supplierArticle1 = SupplierArticle.Create("Article1", "this is some desc1", 500, supplier, 50);
            supplierArticles.Add(1, supplierArticle1);

            var mockExternalService = new Mock<IExternalSupplierTest1Service>();
            mockExternalService.Setup(x => x.GetSupplierArticleById(It.IsAny<int>())).Returns((int id) =>
            {
                return supplierArticles[id];
            });

            return mockExternalService;
        }
    }
}
