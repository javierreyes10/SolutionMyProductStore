using MediatR;
using MyProductStore.Application.DTOs.Output.User;
using System;

namespace MyProductStore.Application.Commands.User
{
    public class RegisterUserCommand : IRequest<UserOutputDto>
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string UserName { get; set; }
        public DateTime BirthdDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
