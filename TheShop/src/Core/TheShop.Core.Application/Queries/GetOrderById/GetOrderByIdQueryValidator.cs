using FluentValidation;

namespace TheShop.Core.Application.Queries.GetOrderById
{
    public class GetOrderByIdQueryValidator : AbstractValidator<GetOrderByIdQuery>
    {
        public GetOrderByIdQueryValidator()
        {
            RuleFor(e => e.Id)
                .NotEmpty()
                .WithMessage("Parameter Id can't be empty.");
        }
    }
}
