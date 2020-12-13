using MediatR;

namespace MyProductStore.Application.Commands.User
{
    public class ForgotPasswordUserCommand : IRequest<string>
    {
        public string Email { get; set; }
    }
}
