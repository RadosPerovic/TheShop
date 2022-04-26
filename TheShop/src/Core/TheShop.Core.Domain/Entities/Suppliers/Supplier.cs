using TheShop.Core.Domain.Common;

namespace TheShop.Core.Domain.Entities.Suppliers
{
    public class Supplier : Entity
    {
        private string _name;

        protected Supplier(string name)
        {
            Name = name;
        }

        public static Supplier Create(string name)
        {
            return new Supplier(name);
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                CommonGuard.NotNullOrEmpty(value);
                _name = value;
            }
        }
    }
}
