namespace TheShop.Core.Domain.Entities.Orders.ReadModels
{
    public class OrderItemReadModel
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public string ArticleName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int Total { get; set; }
    }
}
