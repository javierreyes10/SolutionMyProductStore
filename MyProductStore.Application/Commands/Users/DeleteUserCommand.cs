using MediatR;
using MyProductStore.Application.DTOs.Output.User;

namespace MyProductStore.Application.Commands.Users
{
    public class DeleteUserCommand : IRequest<UserOutputDto>
    {
        public int Id { get; set; }
        public int UserIdFromToken { get; set; }

        public DeleteUserCommand(int id, int userIdFromToken)
        {
            Id = id;
            UserIdFromToken = userIdFromToken;
        }
    }
}
