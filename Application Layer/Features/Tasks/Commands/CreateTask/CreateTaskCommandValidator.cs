using Application_Layer.Features.Tasks.Commands.CreateTask;
using FluentValidation;

namespace Application_Layer.Features.Projects.Commands.CreateTask
{
    public class CreateTaskCommandValidator
        : AbstractValidator<CreateTaskCommand>
    {
        public CreateTaskCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.ProjectId)
                .NotEmpty();

            RuleFor(x => x.Priority)
                .NotEmpty();
        }
    }
}