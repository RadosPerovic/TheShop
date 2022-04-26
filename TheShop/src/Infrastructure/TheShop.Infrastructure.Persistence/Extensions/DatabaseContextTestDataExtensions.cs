using TheShop.Core.Domain.Enums;
using TheShop.Infrastructure.Persistence.Records;

namespace TheShop.Infrastructure.Persistence.Extensions
{
    public static class DatabaseContextTestDataExtensions
    {
        public static void AddTestData(this DatabaseContext context)
        {
            AddOrderStatusTypes(context);
            AddCustomers(context);
            AddSuppliers(context);
            AddArticles(context);

            context.SaveChanges();
        }

        private static List<TRecord> GetEnumRecords<TEnum, TRecord>(Func<TEnum, TRecord> converter) where TRecord : class
        {
            var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            var records = values.Select(converter).ToList();
            return records;
        }

        private static void AddOrderStatusTypes(DatabaseContext context)
        {
            var orderStatusTypeRecords = GetEnumRecords<OrderStatusType, OrderStatusTypeRecord>(e => new OrderStatusTypeRecord { Id = e, Name = e.ToString() });
            context.AddRange(orderStatusTypeRecords);
        }

        private static void AddCustomers(DatabaseContext context)
        {
            var customers = new List<CustomerRecord>()
            {
                new CustomerRecord{ Name = "CustomerName1", Surname = "CustomerSurname1", Email = "customer1@gmail.com"},
                new CustomerRecord{ Name = "CustomerName2", Surname = "CustomerSurname2", Email = "customer2@gmail.com"}
            };

            context.AddRange(customers);
        }

        private static void AddSuppliers(DatabaseContext context)
        {
            var suppliers = new List<SupplierRecord>()
            {
                new SupplierRecord() { Name = "SupplierTest1" },
                new SupplierRecord() { Name = "SupplierTest2" },
                new SupplierRecord() { Name = "SupplierTest3" }
            };

            context.AddRange(suppliers);
        }

        private static void AddArticles(DatabaseContext context)
        {
            var articles = new List<ArticleRecord>()
            {
                new ArticleRecord { Name = "Article1", Description = "this is some desc1" },
                new ArticleRecord { Name = "Article2", Description = "this is some desc2" },
            };

            context.AddRange(articles);
        }
    }
}
