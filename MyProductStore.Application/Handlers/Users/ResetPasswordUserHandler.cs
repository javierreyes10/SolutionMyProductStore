using AutoMapper;
using MediatR;
using MyProductStore.Application.Commands.Users;
using MyProductStore.Application.Exceptions;
using MyProductStore.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;

namespace MyProductStore.Application.Handlers.Users
{
    public class ResetPasswordUserHandler : IRequestHandler<ResetPasswordUserCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ResetPasswordUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<string> Handle(ResetPasswordUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.SingleOrDefaultAsync(u =>
            u.ResetToken == request.Token.Trim().ToUpper() && u.ResetTokenExpires > DateTime.UtcNow);

            if (user == null) throw new ApiBusinessException("Invalid Token");

            user.PasswordHash = BC.HashPassword(request.Password);
            user.ResetToken = null;
            user.ResetTokenExpires = null;

            await _unitOfWork.CommitAsync();

            return "You password has been reset. You can go to the authenticate endpoint and try again";
        }
    }
}
