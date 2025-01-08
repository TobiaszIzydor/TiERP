using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Employee.Commands.CreateEmployee;

namespace TiErp.Application.Order.Commands.CreateOrder
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(e => e.Order.CustomerId)
                .NotEmpty().WithMessage("Klient nie może być pusty!");
        }
    }
}
