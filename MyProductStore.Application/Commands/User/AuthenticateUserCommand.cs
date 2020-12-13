using MediatR;
using MyProductStore.Application.DTOs.Output.User;

namespace MyProductStore.Application.Commands.User
{
    public class AuthenticateUserCommand : IRequest<UserTokenOutputDto>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
