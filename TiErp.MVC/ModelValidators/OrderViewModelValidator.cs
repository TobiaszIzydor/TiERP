using FluentValidation;
using TiErp.Application.Order.Commands.CreateOrder;
using TiErp.MVC.Models;

namespace TiErp.MVC.ModelValidators
{
    public class OrderViewModelValidator : AbstractValidator<OrderViewModel>
    {
        public OrderViewModelValidator()
        {
            RuleFor(e => e.CustomerId)
                .NotEmpty().WithMessage("Klient nie może być pusty!");
            RuleFor(e => e.Items)
                .NotEmpty().WithMessage("Zamówienie musi posiadać produkty!");
            RuleForEach(e => e.Items)
                .ChildRules(item =>
                {
                    item.RuleFor(x => x.Quantity)
                        .GreaterThan(0)
                        .WithMessage("Ilość musi być większa od 0.");
                });
        }
    }
}
