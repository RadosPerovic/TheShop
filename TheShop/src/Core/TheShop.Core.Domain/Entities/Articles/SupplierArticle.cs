
using TheShop.Core.Domain.Common;
using TheShop.Core.Domain.Entities.Suppliers;

namespace TheShop.Core.Domain.Entities.Articles
{
    public class SupplierArticle : Article
    {
        private decimal _price;
        private Supplier _supplier;
        private int _quantityInStock;

        private SupplierArticle(string name,
            string description) : base(name, description)
        {

        }

        private SupplierArticle(string name,
            string description,
            decimal price,
            Supplier supplier,
            int quantityInStock) : base(name, description)
        {
            Price = price;
            Supplier = supplier;
            QuantityInStock = quantityInStock;
        }

        public static SupplierArticle Create(string name,
            string description,
            decimal price,
            Supplier supplier,
            int quantityInStock)
        {
            return new SupplierArticle(name, description, price, supplier, quantityInStock);
        }

        public decimal Price
        {
            get
            {
                return _price;
            }
            private set
            {
                CommonGuard.NotNegative(value);
                _price = value;
            }
        }

        public Supplier Supplier
        {
            get
            {
                return _supplier;
            }
            private set
            {
                CommonGuard.NotNull(value);
                _supplier = value;
            }
        }

        public int QuantityInStock
        {
            get
            {
                return _quantityInStock;
            }
            private set
            {
                CommonGuard.NotNegative(value);
                _quantityInStock = value;
            }
        }

        public void SetSupplier(Supplier supplier)
        {
            Supplier = supplier;
        }
    }
}
