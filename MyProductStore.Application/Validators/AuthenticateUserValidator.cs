using FluentValidation;
using MyProductStore.Application.Commands.Users;

namespace MyProductStore.Application.Validators
{
    public class AuthenticateUserValidator : AbstractValidator<AuthenticateUserCommand>
    {
        public AuthenticateUserValidator()
        {
            RuleFor(u => u.UserName)
               .NotNull()
               .NotEmpty()
               .WithMessage("UserName is required");

            RuleFor(p => p.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("User Password is required");
        }
    }
}
