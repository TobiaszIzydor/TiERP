using FluentValidation;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiErp.Application.Employee.DTOs;

namespace TiErp.Application.Employee.Commands.CreateEmployee
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
                .NotEmpty().WithMessage("Nazwisko nie może być puste")
                .MinimumLength(2).WithMessage("Nazwisko powinno mieć conajmniej 2 litery.")
                .MaximumLength(25).WithMessage("Nazwisko nie powinno mieć więcej niż 25 liter.");
            RuleFor(e => e.Email)
                .EmailAddress().WithMessage("Nie jest to prawidłowy adres Email");
            RuleFor(e => e.Phone)
                .MinimumLength(8).WithMessage("Numer telefonu powinien mieć conajmniej 8 znaków.")
                .MaximumLength(12).WithMessage("Numer telefonu powinien nie powinien mieć więcej niż 12 znaków.");
        }
    }
}
