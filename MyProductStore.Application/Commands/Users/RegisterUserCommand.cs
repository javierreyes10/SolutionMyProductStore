using MyProductStore.Application.DTOs.Input;

namespace MyProductStore.Application.Commands.Users
{
    public class RegisterUserCommand : BaseUserCommand
    {
        public RegisterUserCommand(UserInputDto userInputDto) : base(userInputDto)
        {
        }
    }
}
