using MediatR;
using MyProductStore.Application.DTOs.Output.User;

namespace MyProductStore.Application.Commands.User
{
    public class DeleteUserCommand : IRequest<UserOutputDto>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}
