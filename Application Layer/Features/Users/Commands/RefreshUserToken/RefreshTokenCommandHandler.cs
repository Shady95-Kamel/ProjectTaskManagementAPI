using Application_Layer.Common;
using Application_Layer.DTOs;
using Application_Layer.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure_Layer.Security.JWT;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application_Layer.Features.Users.Commands.RefreshUserToken
{
    public class RefreshTokenCommandHandler
        : IRequestHandler<RefreshTokenCommand, ApiResponse<AuthResponseDTO>>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<User> _userManager;
        private readonly IJwtService _jwtService;

        public RefreshTokenCommandHandler(
            IRefreshTokenRepository refreshTokenRepository,
            UserManager<User> userManager,
            IJwtService jwtService)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userManager = userManager;
            _jwtService = jwtService;
        }

        public async Task<ApiResponse<AuthResponseDTO>> Handle(
            RefreshTokenCommand request,
            CancellationToken cancellationToken)
        {
            var storedToken = await _refreshTokenRepository
                .GetByTokenAsync(request.RefreshToken);

            if (storedToken == null)
            {
                return ApiResponse<AuthResponseDTO>
                    .FailResponse("Invalid refresh token", 401);
            }

            if (storedToken.IsRevoked)
            {
                return ApiResponse<AuthResponseDTO>
                    .FailResponse("Refresh token revoked", 401);
            }

            if (storedToken.ExpiresAt < DateTime.UtcNow)
            {
                return ApiResponse<AuthResponseDTO>
                    .FailResponse("Refresh token expired", 401);
            }

            var user = await _userManager
                .FindByIdAsync(storedToken.UserId);

            if (user == null)
            {
                return ApiResponse<AuthResponseDTO>
                    .FailResponse("User not found", 401);
            }

            storedToken.IsRevoked = true;

            var newAccessToken = _jwtService.GenerateToken(user);
            var newRefreshToken = _jwtService.GenerateRefreshToken();

            await _refreshTokenRepository.AddAsync(new RefreshToken
            {
                Token = newRefreshToken,
                UserId = user.Id,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(7),
                IsRevoked = false
            });

            await _refreshTokenRepository.SaveChangesAsync();

            return ApiResponse<AuthResponseDTO>
                .SuccessResponse(
                    new AuthResponseDTO
                    {
                        Token = newAccessToken,
                        RefreshToken = newRefreshToken
                    },
                    "Token refreshed successfully");
        }
    }
}