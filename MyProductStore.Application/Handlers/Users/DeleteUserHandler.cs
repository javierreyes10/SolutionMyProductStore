using MediatR;
using MyProductStore.Application.Commands.Users;
using MyProductStore.Application.DTOs.Output.User;
using MyProductStore.Application.Exceptions;
using MyProductStore.Core.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MyProductStore.Application.Handlers.Users
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, UserOutputDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public async Task<UserOutputDto> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Id != request.UserIdFromToken) throw new ApiBusinessException("Not Allowed to delete a different user");

            var user = await _unitOfWork.Users.GetByIdAsync(request.Id);

            if (user == null) return null;

            _unitOfWork.Users.Remove(user);
            await _unitOfWork.CommitAsync();

            return new UserOutputDto();
        }
    }
}
