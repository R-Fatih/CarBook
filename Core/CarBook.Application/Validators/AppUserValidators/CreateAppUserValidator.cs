using CarBook.Application.Features.Mediator.Commands.AppUserCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.AppUserValidators
{
    public class CreateAppUserValidator:AbstractValidator<CreateAppUserCommand>
    {
        public CreateAppUserValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş olamaz.")
                .NotNull().WithMessage("Email boş olamaz.")
                .EmailAddress().WithMessage("Lütfen geçerli bir mail adresi girin.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş olamaz.")
                .MinimumLength(6).WithMessage("Şifreniz 6 karakterden fazla olmalıdır");
            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("İsim boş olamaz.")
               .NotNull().WithMessage("İsim boş olamaz.");
            RuleFor(x => x.Surname)
              .NotEmpty().WithMessage("Soyisim boş olamaz.")
              .NotNull().WithMessage("Soyisim boş olamaz.");

        }
    }
}
