using MediatR;
using TheShop.Core.Application.Responses;

namespace TheShop.Core.Application.Queries.GetOrderById
{
    public class GetOrderByIdQuery : IRequest<Result<GetOrderByIdQueryResponse>>
    {
        public int Id { get; set; }
    }
}
