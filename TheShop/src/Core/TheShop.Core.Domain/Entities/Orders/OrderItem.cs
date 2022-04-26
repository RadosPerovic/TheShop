using TheShop.Core.Domain.Common;
using TheShop.Core.Domain.Entities.Articles;

namespace TheShop.Core.Domain.Entities.Orders
{
    public class OrderItem : Entity
    {
        private SupplierArticle _supplierArticle;
        private int _quantity;
        private decimal _total;

        private OrderItem(SupplierArticle supplierArticle,
            int quantity)
        {
            SupplierArticle = supplierArticle;
            Quantity = quantity;
        }

        public static OrderItem Create(SupplierArticle supplierArticle, int quantity)
        {
            return new OrderItem(supplierArticle, quantity);
        }

        public SupplierArticle SupplierArticle
        {
            get
            {
                return _supplierArticle;
            }
            private set
            {
                CommonGuard.NotNull(value);
                _supplierArticle = value;
            }
        }

        public int Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                CommonGuard.NotNegative(value);
                _quantity = value;
            }
        }

        public decimal Total
        {
            get
            {
                return _total;
            }
            private set
            {
                CommonGuard.NotNegative(value);
                _total = value;
            }
        }
        public void CalculatePrice()
        {
            Total = Quantity * SupplierArticle.Price;
        }
    }
}
