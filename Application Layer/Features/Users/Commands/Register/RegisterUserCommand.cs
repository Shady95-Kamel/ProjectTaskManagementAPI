using Application_Layer.Common;
using MediatR;

namespace Application_Layer.Features.Users.Commands.Register
{
    public class RegisterUserCommand
        : IRequest<ApiResponse<string>>
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}