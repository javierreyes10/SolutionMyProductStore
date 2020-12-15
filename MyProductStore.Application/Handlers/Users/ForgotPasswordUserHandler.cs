using AutoMapper;
using MediatR;
using MyProductStore.Application.Commands.Users;
using MyProductStore.Application.Exceptions;
using MyProductStore.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyProductStore.Application.Handlers.Users
{
    public class ForgotPasswordUserHandler : IRequestHandler<ForgotPasswordUserCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public ForgotPasswordUserHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailService = emailService;
        }
        public async Task<string> Handle(ForgotPasswordUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _unitOfWork.Users.SingleOrDefaultAsync(u => u.Email == request.Email);

            if (user == null) throw new ApiBusinessException("The email doesn't exist");

            user.ResetToken = RandomTokenString();
            user.ResetTokenExpires = DateTime.UtcNow.AddMinutes(15);

            await _unitOfWork.CommitAsync();

            await SendResetPasswordEmailAsync(user);

            return $"An email has been sent to {user.Email}. Please follow the instructions to reset your password";

        }

        private string RandomTokenString() => Guid.NewGuid().ToString().ToUpper();

        private async Task SendResetPasswordEmailAsync(Core.Entities.User user)
        {
            var message = $@"Hi there,
                            
                            <p>To reset your password, please go to <code>/api/users/reset-password</code> endpoint and provide the token below </p>
                            <p><code>{user.ResetToken}</code></p>";

            await _emailService.SendAsync(
                to: user.Email,
                subject: "My Product Store API - Reset Password",
                html: $@"<h4>Reset Password Email</h4>
                            {message}"
                );
        }
    }
}
