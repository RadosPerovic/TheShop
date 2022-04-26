using FluentValidation;

namespace TheShop.Core.Application.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(e => e.CustomerId)
                .NotEmpty()
                .WithMessage("CustomerId can't be empty!");

            RuleForEach(e => e.Articles)
                .ChildRules(e => e.RuleFor(e => e.Id)
                .NotEmpty()
                .WithMessage("Article id can't be empty"))
                .ChildRules(e => e.RuleFor(e => e.MaxExpectedPrice)
                .GreaterThan(0)
                .WithMessage("Article MaxExpecterPrice must be greater than 0"))
                .ChildRules(e => e.RuleFor(e => e.Quantity)
                .GreaterThan(0)
                .WithMessage("Article Quantity must be greater than 0"));
        }
    }
}
