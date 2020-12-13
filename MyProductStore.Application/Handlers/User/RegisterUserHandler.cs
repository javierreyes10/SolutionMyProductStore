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
    public class RegisterUserHandler : IRequestHandler<RegisterUserCommand, UserOutputDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UserOutputDto> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var userDb = await _unitOfWork.Users.SingleOrDefaultAsync(u => u.Email == request.Email || u.UserName == request.UserName);
            if (userDb != null) throw new Exception("User with this email/username already exists");

            var user = _mapper.Map<RegisterUserCommand, Core.Entities.User>(request);

            user.PasswordHash = BC.HashPassword(request.Password);

            await _unitOfWork.Users.AddAsync(user);
            var result = await _unitOfWork.CommitAsync();

            //TODO: Create my own exceptions
            if (result <= 0) throw new Exception("The User cannot be created");

            return _mapper.Map<Core.Entities.User, UserOutputDto>(user);
        }
    }
}
