using AutoMapper;
using MediatR;
using MyProductStore.Application.Commands.User;
using MyProductStore.Application.DTOs.Input;
using MyProductStore.Application.DTOs.Output.User;
using MyProductStore.Application.Exceptions;
using MyProductStore.Application.JwtToken;
using MyProductStore.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;


namespace MyProductStore.Application.Handlers.Users
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserOutputDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IJwtTokenBuilder _jwtTokenBuilder;

        public RegisterUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IJwtTokenBuilder jwtTokenBuilder)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _jwtTokenBuilder = jwtTokenBuilder;
        }
        public async Task<UserOutputDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userDb = await _unitOfWork.Users.SingleOrDefaultAsync(u => u.Email == request.User.Email || u.UserName == request.User.UserName);
            if (userDb != null) throw new ApiBusinessException("User with this email/username already exists");

            var user = _mapper.Map<UserInputDto, Core.Entities.User>(request.User);

            user.PasswordHash = BC.HashPassword(request.User.Password);

            await _unitOfWork.Users.AddAsync(user);
            var result = await _unitOfWork.CommitAsync();

            if (result <= 0) throw new Exception("There was an error with the registration. Please try again");

            var userOutputDto = _mapper.Map<Core.Entities.User, UserOutputDto>(user);
            userOutputDto.Token = _jwtTokenBuilder.BuildToken(user);

            return userOutputDto;
        }
    }
}
