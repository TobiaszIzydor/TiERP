using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Employee.Commands.CreateEmployee;

namespace TiErp.Application.Customer.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
    public CreateCustomerCommandValidator()
    {
        RuleFor(e => e.Name)
            .NotEmpty().WithMessage("Nazwa nie może być pusta")
            .MinimumLength(2).WithMessage("Nazwa powinna mieć conajmniej 2 litery.");
        RuleFor(e => e.Address)
            .NotEmpty().WithMessage("Adres nie może być pusty")
            .MinimumLength(5).WithMessage("Adres powinien mieć conajmniej 5 znaków.");
        RuleFor(e => e.Phone)
            .MinimumLength(8).WithMessage("Numer telefonu powinien mieć conajmniej 8 znaków.")
            .MaximumLength(12).WithMessage("Numer telefonu powinien nie powinien mieć więcej niż 12 znaków.");
    }
    }
}
