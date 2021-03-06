﻿using MediatR;
using MyProductStore.Application.DTOs.Output.User;

namespace MyProductStore.Application.Commands.Users
{
    public class AuthenticateUserCommand : IRequest<UserTokenOutputDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
