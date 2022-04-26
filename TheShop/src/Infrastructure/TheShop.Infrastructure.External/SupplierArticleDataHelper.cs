using TheShop.Infrastructure.External.Records;

namespace TheShop.Infrastructure.External
{
    public static  class SupplierArticleDataHelper
    {
        public static SupplierArticleExternalRecord GetArticleByIdSupplierTest1(int id)
        {
            return new SupplierArticleExternalRecord
            {
                Id = id,
                Name = "Article test1",
                QuantityInStock = 20,
                Description = "test",
                Price = 500
            };
        }

        public static SupplierArticleExternalRecord GetArticleByIdSupplierTest2(int id)
        {
            return new SupplierArticleExternalRecord
            {
                Id = id,
                Name = "Article test2",
                QuantityInStock = 10,
                Price = 550
            };
        }

        public static SupplierArticleExternalRecord GetArticleByIdSupplierTest3(int id)
        {
            return new SupplierArticleExternalRecord
            {
                Id = id,
                Name = "Article test3",
                QuantityInStock = 5,
                Price = 600
            };
        }

    }
}
