using FluentValidation;
using MyProductStore.Application.DTOs.Input;
using System;

namespace MyProductStore.Application.Validators
{
    public class UserValidator : AbstractValidator<UserInputDto>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name)
               .NotNull()
               .NotEmpty()
               .WithMessage("User Name is required");

            RuleFor(p => p.Name)
                .MaximumLength(100)
                .WithMessage("User Name cannot be greater than 100");


            RuleFor(p => p.Phone)
                .Matches("^\\d{8}$")
                .WithMessage("User Phone can contain numbers only");

            RuleFor(p => p.Phone)
              .NotNull()
              .NotEmpty()
              .WithMessage("User Phone is required");

            RuleFor(p => p.BirthdDate)
              .NotNull()
              .NotEmpty()
              .WithMessage("User Birth date is required");

            RuleFor(p => p.BirthdDate)
              .Must(d => !d.Equals(default(DateTime)))
              .WithMessage("User Birth date must have a validate date format");

            RuleFor(p => p.Email)
             .NotNull()
             .NotEmpty()
             .WithMessage("User Email is required");

            RuleFor(p => p.Email)
             .EmailAddress()
             .WithMessage("User Email must be a valid email format");

            RuleFor(p => p.Password)
            .NotNull()
            .NotEmpty()
            .WithMessage("User Password is required");
        }
    }
}
