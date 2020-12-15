using FluentValidation;
using MyProductStore.Application.Commands.Users;

namespace MyProductStore.Application.Validators
{
    public class ResetPasswordUserValidator : AbstractValidator<ResetPasswordUserCommand>
    {
        public ResetPasswordUserValidator()
        {
            RuleFor(p => p.Token)
              .NotNull()
              .NotEmpty()
              .WithMessage("Token is required");

            RuleFor(p => p.Password)
            .NotNull()
            .NotEmpty()
            .WithMessage("User Password is required");

            RuleFor(p => p.ConfirmPassword)
            .NotNull()
            .NotEmpty()
            .WithMessage("ConfirmPassword is required");


            RuleFor(p => p.ConfirmPassword)
            .Must((p, ConfirmPassword) => ConfirmPassword == p.Password)
            .WithMessage("Password and ConfirmPassword must be equal");


        }
    }
}
