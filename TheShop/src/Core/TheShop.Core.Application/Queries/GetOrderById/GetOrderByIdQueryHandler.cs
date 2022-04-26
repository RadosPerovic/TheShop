using MediatR;
using TheShop.Core.Application.Responses;
using TheShop.Core.Domain.Entities.Orders;

namespace TheShop.Core.Application.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Result<GetOrderByIdQueryResponse>>
    {
        private readonly IOrderReadOnlyRepository _orderReadOnlyRepository;

        public GetOrderByIdQueryHandler(IOrderReadOnlyRepository orderReadOnlyRepository)
        {
            _orderReadOnlyRepository = orderReadOnlyRepository;
        }

        public async Task<Result<GetOrderByIdQueryResponse>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var readModel = await _orderReadOnlyRepository.GetByIdAsync(request.Id);

            if (readModel is null)
                return Result<GetOrderByIdQueryResponse>.Failure(string.Format(Messages.OrderNotFound, request.Id.ToString()));

            return Result<GetOrderByIdQueryResponse>.Success(new GetOrderByIdQueryResponse
            {
                Order = readModel
            });
        }
    }
}
