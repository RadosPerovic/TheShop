using System.Collections.Generic;
using TheShop.Core.Application.Commands.CreateOrder;

namespace TheShop.Core.Application.UnitTest.Commands.CreateOrder
{
    public static class CreateOrderCommandHelper
    {
        public static CreateOrderCommand GetValidCreateOrderCommand()
        {
            return new CreateOrderCommand()
            {
                CustomerId = 1,
                Articles = new List<OrderArticleDetailsDto>()
                {
                    new OrderArticleDetailsDto { Id = 1, MaxExpectedPrice = 500, Quantity = 10 }
                }
            };
        }

        public static CreateOrderCommand GetNonExistingArticleCreateOrderCommand()
        {
            return new CreateOrderCommand()
            {
                CustomerId = 1,
                Articles = new List<OrderArticleDetailsDto>()
                {
                    new OrderArticleDetailsDto { Id = 1, MaxExpectedPrice = 500, Quantity = 10 },
                    new OrderArticleDetailsDto { Id = 5, MaxExpectedPrice = 500, Quantity = 10 }
                }
            };
        }

        public static CreateOrderCommand GetNonExistingCustomerCreateOrderCommand()
        {
            return new CreateOrderCommand()
            {
                CustomerId = 99,
                Articles = new List<OrderArticleDetailsDto>()
                {
                    new OrderArticleDetailsDto { Id = 1, MaxExpectedPrice = 500, Quantity = 10 },
                    new OrderArticleDetailsDto { Id = 2, MaxExpectedPrice = 500, Quantity = 10 }
                }
            };
        }

        public static CreateOrderCommand GetBadQuantityCreatedOrderCommand()
        {
            return new CreateOrderCommand()
            {
                CustomerId = 1,
                Articles = new List<OrderArticleDetailsDto>()
                {
                    new OrderArticleDetailsDto { Id = 1, MaxExpectedPrice = 500, Quantity = 99 }
                }
            };
        }

        public static CreateOrderCommand GetInappropriateMaxExpectedPrice()
        {
            return new CreateOrderCommand()
            {
                CustomerId = 1,
                Articles = new List<OrderArticleDetailsDto>()
                {
                    new OrderArticleDetailsDto { Id = 1, MaxExpectedPrice = 100, Quantity = 5 }
                }
            };
        }
    }
}
