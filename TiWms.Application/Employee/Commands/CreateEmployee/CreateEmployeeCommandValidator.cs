using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiWms.Application.Employee.DTOs;

namespace TiWms.Application.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(e => e.FirstName)
                .NotEmpty().WithMessage("Imie nie może być puste")
                .MinimumLength(2).WithMessage("Imię powinno mieć conajmniej 2 litery.")
                .MaximumLength(25).WithMessage("Imię nie powinno mieć więcej niż 25 liter.");
            RuleFor(e => e.LastName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(25);
            RuleFor(e => e.Email)
                .EmailAddress();
            RuleFor(e => e.Phone)
                .MinimumLength(8)
                .MaximumLength(12);
        }
    }
}
