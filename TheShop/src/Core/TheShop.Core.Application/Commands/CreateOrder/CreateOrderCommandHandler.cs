using MediatR;
using TheShop.Core.Application.Responses;
using TheShop.Core.Application.Services;
using TheShop.Core.Domain.Entities.Articles;
using TheShop.Core.Domain.Entities.Customers;
using TheShop.Core.Domain.Entities.Orders;
using TheShop.Core.Domain.Enums;

namespace TheShop.Core.Application.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<CreateOrderCommandResponse>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IArticleRepository _articleRepository;
        private readonly ISupplierArticleService _supplierArticleService;

        public CreateOrderCommandHandler(ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            IArticleRepository articleRepository,
            ISupplierArticleService supplierArticleService)
        {
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
            _articleRepository = articleRepository;
            _supplierArticleService = supplierArticleService;
        }

        public async Task<Result<CreateOrderCommandResponse>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            if (customer is null)
                return Result<CreateOrderCommandResponse>.Failure(string.Format(Messages.ArticleNotFound, request.CustomerId));

            var order = Order.Create(customer,
                OrderStatusType.InProgress);

            foreach(var requestArticle in request.Articles)
            {
                var article = await _articleRepository.GetByIdAsync(requestArticle.Id);
                if (article is null)
                    return Result<CreateOrderCommandResponse>.Failure(string.Format(Messages.CustomerNotFound, requestArticle.Id));

                var filteredSupplierArticleResult = await GetFilteredSupplierArticle(requestArticle);
                if (!filteredSupplierArticleResult.IsSuccessful)
                    return Result<CreateOrderCommandResponse>.Failure(filteredSupplierArticleResult.Message);

                var orderItem = OrderItem.Create(filteredSupplierArticleResult.Data, requestArticle.Quantity);

                order.AddOrderItem(orderItem);
            }

            order.Calculate();
            order.PlaceOrder();

            await _orderRepository.AddAsync(order);
            await _orderRepository.SaveChangesAsync();

            return Result<CreateOrderCommandResponse>.Success(new CreateOrderCommandResponse());
        }

        private async Task<Result<SupplierArticle>> GetFilteredSupplierArticle(OrderArticleDetailsDto requestArticle)
        { 
            var supplierArticlesResult = await _supplierArticleService.GetSupplierArticlesById(requestArticle.Id);
            if (!supplierArticlesResult.IsSuccessful)
                return Result<SupplierArticle>.Failure(supplierArticlesResult.Message);

            var supplierArticles = supplierArticlesResult.Data;
            var filteredArticle = supplierArticles
                .Where(e => e.QuantityInStock > requestArticle.Quantity && e.Price <= requestArticle.MaxExpectedPrice)
                .OrderBy(e => e.Price)
                .FirstOrDefault();

            if (filteredArticle is null)
                return Result<SupplierArticle>.Failure(string.Format(Messages.FilteredArticleNotFound, requestArticle.Quantity, requestArticle.MaxExpectedPrice));

            return Result<SupplierArticle>.Success(filteredArticle);
        }
    }
}
