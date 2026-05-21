using Application_Layer.Features.Projects.Commands.DeleteProject;
using FluentValidation;

namespace Application_Layer.Features.Projects.Commands.CreateProject
{
    public class DeleteProjectCommandValidator
        : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}