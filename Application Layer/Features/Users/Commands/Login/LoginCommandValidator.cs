using Application_Layer.Features.Users.Commands.Register;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Features.Users.Commands.Login
{
    public class LognaCommandValidator : AbstractValidator<LoginCommand>
    {
        public LognaCommandValidator()
        {

            RuleFor(x => x.Email)
                .NotEmpty();

            RuleFor(x => x.Password)
               .NotEmpty();
        }
    }
}
