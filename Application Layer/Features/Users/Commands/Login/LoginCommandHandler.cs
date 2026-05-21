using Application_Layer.Common;
using Application_Layer.DTOs;
using Application_Layer.Features.Users.Commands.Login;
using Application_Layer.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure_Layer.Security.JWT;
using MediatR;

namespace Application_Layer.Features.Users.Commands.Login
{
    public class LoginCommandHandler
        : IRequestHandler<LoginCommand, ApiResponse<AuthResponseDTO>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtService _jwtService;

        public LoginCommandHandler(
            IUserRepository userRepository,
            IJwtService jwtService)
        {
            _userRepository = userRepository;
            _jwtService = jwtService;
        }

        public async Task<ApiResponse<AuthResponseDTO>> Handle(
            LoginCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _userRepository
                .GetByEmailAsync(request.Email);

            if (user == null)
            {
                return ApiResponse<AuthResponseDTO>
                    .FailResponse("Invalid email or password", 401);
            }

            var isValid = await _userRepository
                .CheckPasswordAsync(user, request.Password);

            if (!isValid)
            {
                return ApiResponse<AuthResponseDTO>
                    .FailResponse("Invalid email or password", 401);
            }

            var accessToken = _jwtService.GenerateToken(user);
            var refreshToken = _jwtService.GenerateRefreshToken();

            var refreshEntity = new RefreshToken
            {
                Token = refreshToken,
                UserId = user.Id,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            };

            await _userRepository.AddRefreshTokenAsync(refreshEntity);
            await _userRepository.SaveChangesAsync();

            var response = new AuthResponseDTO
            {
                Token = accessToken,
                RefreshToken = refreshToken
            };

            return ApiResponse<AuthResponseDTO>
                .SuccessResponse(response, "Login successful");
        }
    }
}