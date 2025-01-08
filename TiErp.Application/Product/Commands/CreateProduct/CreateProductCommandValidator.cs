using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Customer.Commands.CreateCustomer;

namespace TiErp.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("Nazwa nie może być pusta")
                .MinimumLength(2).WithMessage("Nazwa powinna mieć conajmniej 2 litery.");
        }
    }
}
