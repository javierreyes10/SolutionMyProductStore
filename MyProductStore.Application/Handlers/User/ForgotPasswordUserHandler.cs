using AutoMapper;
using MediatR;
using MyProductStore.Application.Commands.User;
using MyProductStore.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyProductStore.Application.Handlers.User
{
    public class ForgotPasswordUserHandler : IRequestHandler<ForgotPasswordUserCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ForgotPasswordUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<string> Handle(ForgotPasswordUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.SingleOrDefaultAsync(u => u.Email == request.Email);

            //TODO custom exceptions
            if (user == null) throw new Exception("The email doesn't exist");

            user.ResetToken = RandomTokenString();
            user.ResetTokenExpires = DateTime.UtcNow.AddMinutes(15);

            await _unitOfWork.CommitAsync();

            //TODO Send email

            return $"An email has been sent to {user.Email}. Please follow the instructions to reset your password";

        }

        private string RandomTokenString()
        {
            return Guid.NewGuid().ToString().ToUpper();
        }
    }
}
