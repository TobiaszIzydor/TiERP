using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiErp.Application.ProductionItem.Commands.CreateProductionItem
{
    public class CreateProductionItemCommandValidator : AbstractValidator<CreateProductionItemCommand>
    {
        public CreateProductionItemCommandValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Nazwa nie może być pusta")
                .MinimumLength(2).WithMessage("Nazwa powinna mieć conajmniej 2 litery.");
            RuleFor(e => e.WareHouseLocationCode)
                .NotEmpty().WithMessage("Lokalizacja nie powinna być pusta");
            RuleFor(e => e.EAN13)
                .NotEmpty().WithMessage("Kod EAN nie powinien być pusty.")
                .MinimumLength(13).WithMessage("Kod EAN powinien mieć dokładnie 13 znaków.")
                .MaximumLength(13).WithMessage("Kod EAN powinien mieć dokładnie 13 znaków.");
        }
    }
}
