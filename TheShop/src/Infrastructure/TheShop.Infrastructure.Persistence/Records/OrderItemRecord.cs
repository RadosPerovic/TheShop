namespace TheShop.Infrastructure.Persistence.Records
{
    public class OrderItemRecord : Record<int>
    {
        public int OrderId { get; set; }
        public int ArticleId { get; set; }
        public int SupplierId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }

        public OrderRecord Order { get; set; }
        public ArticleRecord Article { get; set; }
        public SupplierRecord Supplier { get; set; }
    }
}
