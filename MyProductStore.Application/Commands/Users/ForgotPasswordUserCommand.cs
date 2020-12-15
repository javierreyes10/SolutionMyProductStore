using MediatR;

namespace MyProductStore.Application.Commands.Users
{
    public class ForgotPasswordUserCommand : IRequest<string>
    {
        public string Email { get; set; }
    }
}
