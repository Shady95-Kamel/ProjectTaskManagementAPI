using Application_Layer.Common;
using Application_Layer.DTOs;
using MediatR;

namespace Application_Layer.Features.Users.Commands.Login
{
    public class LoginCommand
        : IRequest<ApiResponse<AuthResponseDTO>>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}