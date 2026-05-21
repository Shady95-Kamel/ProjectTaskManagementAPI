using Application_Layer.Common;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application_Layer.Features.Users.Commands.Register
{
    public class RegisterUserCommandHandler
        : IRequestHandler<RegisterUserCommand,
            ApiResponse<string>>
    {
        private readonly UserManager<User> _userManager;

        public RegisterUserCommandHandler(
            UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<ApiResponse<string>> Handle(
            RegisterUserCommand request,
            CancellationToken cancellationToken)
        {
            var existingUser = await _userManager
                .FindByEmailAsync(request.Email);

            if (existingUser != null)
            {
                return ApiResponse<string>
                    .FailResponse("Email already exists", 400);
            }

            var user = new User
            {
                UserName = request.UserName,
                Email = request.Email
            };

            var result = await _userManager
                .CreateAsync(user, request.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(", ",
                    result.Errors.Select(x => x.Description));

                return ApiResponse<string>
                    .FailResponse(errors, 400);
            }

            return ApiResponse<string>
                .SuccessResponse(
                    null!,
                    "User created successfully");
        }
    }
}