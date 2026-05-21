using Application_Layer.Common;
using Application_Layer.DTOs;
using MediatR;

namespace Application_Layer.Features.Users.Commands.RefreshUserToken
{
    public class RefreshTokenCommand
        : IRequest<ApiResponse<AuthResponseDTO>>
    {
        public string RefreshToken { get; set; }
    }
}