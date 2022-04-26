using FluentAssertions;
using System;
using System.Linq;
using TheShop.Core.Domain.Entities.Articles;
using TheShop.Core.Domain.Entities.Customers;
using TheShop.Core.Domain.Entities.Orders;
using TheShop.Core.Domain.Entities.Suppliers;
using TheShop.Core.Domain.Enums;
using Xunit;

namespace TheShop.Core.Domain.UnitTest.Orders
{
    public class OrderTest
    {
        [Fact]
        public void Construct_Valid_Created()
        {
            //Arrange

            var customer = Customer.Create("Customer1", "CustomerSurname1", "customer1@gmail.com");
            var orderStatus = OrderStatusType.InProgress;

            //Act

            var order = Order.Create(customer, orderStatus);

            //Assert

            order.Customer.Should().Be(customer);
            order.OrderStatus.Should().Be(orderStatus);
        }

        [Fact]
        public void Constuct_Invalid_CustomerNull_ExceptionThrown()
        {
            //Arrange

            Customer customer = null;
            var orderStatus = OrderStatusType.InProgress;

            //Act

            Action customerNull = () => Order.Create(customer, orderStatus);

            //Assert
            
            customerNull.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Construct_Invalid_OrderStatusNone_ExceptionThrown()
        {
            //Arrange

            var customer = Customer.Create("Customer1", "CustomerSurname1", "customer1@gmail.com");
            var orderStatus = OrderStatusType.None;

            //Act

            Action customerNull = () => Order.Create(customer, orderStatus);

            //Assert

            customerNull.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void AddOrderItem_Valid()
        {
            //Arrange

            var customer = Customer.Create("Customer1", "CustomerSurname1", "customer1@gmail.com");
            var orderStatus = OrderStatusType.InProgress;

            var order = Order.Create(customer, orderStatus);

            var supplier = Supplier.Create("SupplierTest1");
            var supplierArticle = SupplierArticle.Create("Article1", "This is desc of some article", 500.12m, supplier, 20);

            var quantity = 5;
            var orderItem = OrderItem.Create(supplierArticle, quantity);

            //Act

            order.AddOrderItem(orderItem);
            var addedOrderItem = order.OrderItems.FirstOrDefault();

            //Assert

            addedOrderItem.Should().NotBeNull();
            addedOrderItem.SupplierArticle.Should().NotBeNull();
            addedOrderItem.SupplierArticle.Should().Be(supplierArticle);
            addedOrderItem.Quantity.Should().Be(quantity);
        }

        [Fact]
        public void AddOrderItem_Invalid_OrdetItemNull_ExceptionThrown()
        {
            //Arrange

            var customer = Customer.Create("Customer1", "CustomerSurname1", "customer1@gmail.com");
            var orderStatus = OrderStatusType.InProgress;

            var order = Order.Create(customer, orderStatus);

            OrderItem orderItem = null;

            //Act

            Action orderItemNull = () => order.AddOrderItem(orderItem);

            //Assert

            orderItemNull.Should().Throw<ArgumentException>();
        }
    }
}
