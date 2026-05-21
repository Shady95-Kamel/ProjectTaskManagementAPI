using FluentValidation;

namespace Application_Layer.Features.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandValidator
        : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(x => x.Id)
               .NotEmpty();

            RuleFor(x => x.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty();
        }
    }
}