﻿using FluentValidation;
using MyProductStore.Application.Commands.Users;

namespace MyProductStore.Infrastructure.Validators
{
    public class ForgotPasswordUserValidator : AbstractValidator<ForgotPasswordUserCommand>
    {
        public ForgotPasswordUserValidator()
        {
            RuleFor(u => u.Email)
             .NotNull()
             .NotEmpty()
             .WithMessage("User Email is required");

            RuleFor(u => u.Email)
             .EmailAddress()
             .WithMessage("User Email must be a valid email format");
        }
    }
}
