using Application_Layer.Features.Users.Commands.Register;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Features.Users.Commands.Register
{
   public class RegisterUserCommandValidator: AbstractValidator<RegisterUserCommand>
   {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Email)
                .NotEmpty();

            RuleFor(x => x.Password)
               .NotEmpty();
        }
   }
}
