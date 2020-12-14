using MyProductStore.Application.DTOs.Input;

namespace MyProductStore.Application.Commands.User
{
    public class PutUserCommand : BaseUserCommand
    {
        public int Id { get; set; }
        public int UserIdFromToken { get; set; }

        public PutUserCommand(int id, UserInputDto putUserInputDto, int userIdFromToken) : base(putUserInputDto)
        {
            Id = id;
            UserIdFromToken = userIdFromToken;
        }
    }
}
