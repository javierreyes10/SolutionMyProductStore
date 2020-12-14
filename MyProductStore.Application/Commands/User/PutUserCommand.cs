using MediatR;
using MyProductStore.Application.DTOs.Input;
using MyProductStore.Application.DTOs.Output.User;

namespace MyProductStore.Application.Commands.User
{
    public class PutUserCommand : IRequest<UserOutputDto>
    {
        public int Id { get; set; }
        public PutUserInputDto PutUserInputDto { get; set; }

        public int UserIdFromToken { get; set; }

        public PutUserCommand(int id, PutUserInputDto putUserInputDto, int userIdFromToken)
        {
            Id = id;
            PutUserInputDto = putUserInputDto;
            UserIdFromToken = userIdFromToken;
        }
    }
}
