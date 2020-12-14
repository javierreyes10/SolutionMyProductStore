using MediatR;
using MyProductStore.Application.DTOs.Input;
using MyProductStore.Application.DTOs.Output.User;

namespace MyProductStore.Application.Commands.User
{
    public class BaseUserCommand : IRequest<UserOutputDto>
    {
        public UserInputDto User { get; set; }

        public BaseUserCommand(UserInputDto putUserInputDto)
        {
            User = putUserInputDto;
        }
    }
}
