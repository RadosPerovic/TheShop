namespace TheShop.Infrastructure.External.Records
{
    public class SupplierArticleExternalRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int QuantityInStock { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
