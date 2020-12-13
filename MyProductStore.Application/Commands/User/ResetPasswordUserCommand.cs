﻿using MediatR;

namespace MyProductStore.Application.Commands.User
{
    public class ResetPasswordUserCommand : IRequest<string>
    {
        public string Token { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
