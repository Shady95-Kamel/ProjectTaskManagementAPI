using Application_Layer.Features.Tasks.Commands.DeleteTask;
using FluentValidation;

namespace Application_Layer.Features.Projects.Commands.DeleteTask
{
    public class DeleteTaskCommandValidator
        : AbstractValidator<DeleteTaskCommand>
    {
        public DeleteTaskCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}