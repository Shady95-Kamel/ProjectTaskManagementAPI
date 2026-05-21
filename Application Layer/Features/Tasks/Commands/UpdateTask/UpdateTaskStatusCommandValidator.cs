using Application_Layer.Features.Tasks.Commands.UpdateTaskStatus;
using FluentValidation;

namespace Application_Layer.Features.Projects.Commands.UpdateTask
{
    public class UpdateTaskCommandValidator
        : AbstractValidator<UpdateTaskStatusCommand>
    {
        public UpdateTaskCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();

            RuleFor(x => x.Status)
                .NotEmpty();
        }
    }
}