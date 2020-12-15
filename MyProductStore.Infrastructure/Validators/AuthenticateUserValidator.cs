using FluentValidation;
using MyProductStore.Application.Commands.Users;

namespace MyProductStore.Infrastructure.Validators
{
    public class AuthenticateUserValidator : AbstractValidator<AuthenticateUserCommand>
    {
        public AuthenticateUserValidator()
        {
            RuleFor(u => u.Email)
               .NotNull()
               .NotEmpty()
               .WithMessage("Email is required");

            RuleFor(u => u.Email)
             .EmailAddress()
             .WithMessage("Email must be a valid email format");

            RuleFor(u => u.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("User Password is required");
        }
    }
}
