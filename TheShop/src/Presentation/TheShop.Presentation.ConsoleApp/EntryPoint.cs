using MediatR;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using TheShop.Core.Application.Commands.CreateOrder;
using TheShop.Core.Application.Queries.GetOrderById;
using TheShop.Core.Application.Responses;

namespace TheShop.Presentation.ConsoleApp
{
    public class EntryPoint
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EntryPoint> _logger;
        public EntryPoint(IMediator mediator,
            ILogger<EntryPoint> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        public async Task Run()
        {
            var createOrderCommand = GetCreateOrderCommand();
            var createOrderResult = await _mediator.Send(createOrderCommand);
            
            ValidateResult(createOrderResult);

            var getOrderByIdQuery = GetOrderByIdQuery();
            var getOrderByIdResult = await _mediator.Send(getOrderByIdQuery);

            ValidateResult(getOrderByIdResult);

            Console.ReadKey();
        }

        private void ValidateResult<T>(Result<T> result)
        {
            var typeName = typeof(T).Name;

            if(!result.IsSuccessful)
            {
                _logger.LogInformation("Unsuccessful response : {0}, type: {1}", result.Message, typeName);
                ConsoleAppHelper.WriteUnsuccessfulResult(typeName, result.Message);
                return;
            }

            var data = JsonConvert.SerializeObject(result.Data);
            _logger.LogInformation("Successful response : {0}, type: {1}", data, typeName);
            ConsoleAppHelper.WriteSuccessfulResult(typeName, data);
        }

        private GetOrderByIdQuery GetOrderByIdQuery()
        {
            return new GetOrderByIdQuery()
            {
                Id = 1
            };
        }

        private CreateOrderCommand GetCreateOrderCommand()
        {
            return new CreateOrderCommand()
            {
                CustomerId = 1,
                Articles = new List<OrderArticleDetailsDto>()
                {
                    new OrderArticleDetailsDto { Id = 1, MaxExpectedPrice = 500, Quantity = 10 },
                    new OrderArticleDetailsDto { Id = 2, MaxExpectedPrice = 600, Quantity = 2 }
                }
            };
        }
    }
}
