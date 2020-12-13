using AutoMapper;
using MediatR;
using MyProductStore.Application.Commands.User;
using MyProductStore.Application.DTOs.Output.User;
using MyProductStore.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace MyProductStore.Application.Handlers.User
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, UserTokenOutputDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthenticateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UserTokenOutputDto> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.SingleOrDefaultAsync(u => u.UserName == request.UserName);

            //TODO: Custom Exception
            if (user == null || !BC.Verify(request.Password, user.PasswordHash))
                throw new Exception("Email or password is incorrect");

            return new UserTokenOutputDto
            {
                UserName = request.UserName,
                Token = Guid.NewGuid().ToString() //TODO: JWT Token
            };
        }
    }
}
