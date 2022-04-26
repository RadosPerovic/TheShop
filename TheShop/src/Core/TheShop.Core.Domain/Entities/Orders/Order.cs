using TheShop.Core.Domain.Common;
using TheShop.Core.Domain.Entities.Customers;
using TheShop.Core.Domain.Enums;

namespace TheShop.Core.Domain.Entities.Orders
{
    public class Order : Entity
    {
        private Customer _customer;
        private OrderStatusType _orderStatus;
        private decimal _total;
        private DateTime _createdDate;
        private DateTime? _placedDate;

        private List<OrderItem> _orderItems; 

        private Order(Customer customer,
        OrderStatusType orderStatus)
        {
            Customer = customer;
            OrderStatus = orderStatus;

            OrderItems = new List<OrderItem>();
            CreatedDate = DateTime.Now;
        }

        public static Order Create(Customer customer,
            OrderStatusType orderStatusType)
        {
            return new Order(customer, orderStatusType);
        } 

        public Customer Customer
        {
            get
            {
                return _customer;
            }
            private set
            {
                CommonGuard.NotNull(value);
                _customer = value;
            }
        }

        public OrderStatusType OrderStatus
        {
            get
            {
                return _orderStatus;
            }
            private set
            {
                CommonGuard.NotNone(value, OrderStatusType.None);
                _orderStatus = value;
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

        public List<OrderItem> OrderItems
        {
            get
            {
                return _orderItems;
            }
            private set
            {
                CommonGuard.NotNull(value);
                _orderItems = value;
            }
        } 

        public DateTime CreatedDate
        {
            get
            {
                return _createdDate;
            }
            private set 
            {
                CommonGuard.NotNull(value);
                _createdDate = value;
            }
        }

        public DateTime? PlacedDate
        {
            get
            {
                return _placedDate;
            }
            private set
            {
                _placedDate = value;
            }
        }

        public void AddOrderItem(OrderItem item)
        {
            if (OrderItems is null)
                throw new ArgumentException();

            if (item is null)
                throw new ArgumentException();

            OrderItems.Add(item);
        }

        public void Calculate()
        {
            if (OrderItems is null || !OrderItems.Any())
            {
                Total = 0;
                return;
            }

            foreach (var item in OrderItems)
            {
                item.CalculatePrice();
                Total += item.Total;
            }
        }

        public void PlaceOrder()
        {
            if (OrderStatus != OrderStatusType.InProgress)
                throw new ArgumentException();

            OrderStatus = OrderStatusType.Placed;
            PlacedDate = DateTime.Now;
        }
    }
}
