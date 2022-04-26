using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace TheShop.Core.Application.Behavior
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if(_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var failures = _validators
                    .Select(validator => validator.Validate(context))
                    .SelectMany(result => result.Errors)
                    .Where(failure => failure != null)
                    .ToList();

                if(failures.Any())
                {
                    GetErrorMessage(failures, out var errorMessage);
                    throw new Exception(errorMessage);
                }
            }

            return next();
        }

        private void GetErrorMessage(List<ValidationFailure> failures, out string errorMessage)
        {
            errorMessage = string.Empty;

            foreach (var failure in failures)
                errorMessage += failure.ErrorMessage + "; ";
        }
    }
}
