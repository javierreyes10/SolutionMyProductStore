using MediatR;
using MyProductStore.Application.Commands.Users;
using MyProductStore.Application.DTOs.Output.User;
using MyProductStore.Application.Exceptions;
using MyProductStore.Core.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace MyProductStore.Application.Handlers.Users
{
    public class AuthenticateUserHandler : IRequestHandler<AuthenticateUserCommand, UserTokenOutputDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenBuilder _jwtTokenBuilder;

        public AuthenticateUserHandler(IUnitOfWork unitOfWork, IJwtTokenBuilder jwtTokenBuilder)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenBuilder = jwtTokenBuilder;
        }
        public async Task<UserTokenOutputDto> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.SingleOrDefaultAsync(u => u.Email == request.Email);

            if (user == null || !BC.Verify(request.Password, user.PasswordHash))
                throw new ApiBusinessException("Email or password is incorrect");

            return new UserTokenOutputDto
            {
                Email = request.Email,
                Token = _jwtTokenBuilder.BuildToken(user)
            };
        }
    }
}
