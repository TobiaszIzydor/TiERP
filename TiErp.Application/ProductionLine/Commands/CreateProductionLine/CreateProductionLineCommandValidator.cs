using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiErp.Application.ProductionLine.Commands.CreateProductionLine
{
    public class CreateProductionLineCommandValidator : AbstractValidator<CreateProductionLineCommand>
    {
        public CreateProductionLineCommandValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Nazwa nie może być pusta")
                .MinimumLength(2).WithMessage("Nazwa powinna mieć conajmniej 2 litery.");
        }
    }
}
