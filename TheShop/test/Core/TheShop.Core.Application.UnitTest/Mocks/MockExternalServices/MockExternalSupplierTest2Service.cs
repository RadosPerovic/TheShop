using Moq;
using System.Collections.Generic;
using TheShop.Core.Application.Services.External;
using TheShop.Core.Domain.Entities.Articles;
using TheShop.Core.Domain.Entities.Suppliers;

namespace TheShop.Core.Application.UnitTest.Mocks.MockExternalServices
{
    public static class MockExternalSupplierTest2Service
    {
        public static Mock<IExternalSupplierTest2Service> GetExternalSupplierTest2Service()
        {
            var supplierArticles = new Dictionary<int, SupplierArticle>();
            var supplier = Supplier.Create("SupplierTest2");

            var supplierArticle1 = SupplierArticle.Create("Article1", "this is some desc1", 550, supplier, 50);
            supplierArticles.Add(1, supplierArticle1);

            var mockExternalService = new Mock<IExternalSupplierTest2Service>();
            mockExternalService.Setup(x => x.GetSupplierArticleById(It.IsAny<int>())).Returns((int id) =>
            {
                return supplierArticles[id];
            });

            return mockExternalService;
        }
    }
}
