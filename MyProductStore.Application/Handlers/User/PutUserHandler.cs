using AutoMapper;
using MediatR;
using MyProductStore.Application.Commands.User;
using MyProductStore.Application.DTOs.Output.User;
using MyProductStore.Application.Exceptions;
using MyProductStore.Core.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MyProductStore.Application.Handlers.User
{
    public class PutUserHandler : IRequestHandler<PutUserCommand, UserOutputDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PutUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<UserOutputDto> Handle(PutUserCommand request, CancellationToken cancellationToken)
        {
            if (request.Id != request.UserIdFromToken) throw new ApiBusinessException("Not Allowed to update a different user");

            var user = await _unitOfWork.Users.GetByIdAsync(request.Id);
            var userRequest = request.User;

            if (user == null) return null;

            if (userRequest.Email != user.Email &&
                await _unitOfWork.Users.SingleOrDefaultAsync(u => u.Email == userRequest.Email) != null)
                throw new ApiBusinessException("There is already an account with this email");

            if (userRequest.UserName != user.UserName &&
               await _unitOfWork.Users.SingleOrDefaultAsync(u => u.UserName == userRequest.UserName) != null)
                throw new ApiBusinessException("There is already an account with this username");


            _mapper.Map(request.User, user);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Core.Entities.User, UserOutputDto>(user);
        }
    }
}
