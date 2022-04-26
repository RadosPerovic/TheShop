using MediatR;
using TheShop.Core.Application.Responses;

namespace TheShop.Core.Application.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Result<CreateOrderCommandResponse>>
    {
        public int CustomerId { get; set; }
        public List<OrderArticleDetailsDto> Articles { get; set; }
    }

    public class OrderArticleDetailsDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int MaxExpectedPrice { get; set; }
    }
}
