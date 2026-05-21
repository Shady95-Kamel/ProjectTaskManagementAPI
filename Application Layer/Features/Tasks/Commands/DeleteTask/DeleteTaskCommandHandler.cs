using Application_Layer.Common;
using MediatR;
using Persistence_Layer.Repository.ProjectTaskRepo;

namespace Application_Layer.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommandHandler
        : IRequestHandler<DeleteTaskCommand,
            ApiResponse<string>>
    {
        private readonly IProjectTaskRepository _projectTaskRepository;

        public DeleteTaskCommandHandler(
            IProjectTaskRepository projectTaskRepository)
        {
            _projectTaskRepository = projectTaskRepository;
        }

        public async Task<ApiResponse<string>> Handle(
            DeleteTaskCommand request,
            CancellationToken cancellationToken)
        {
            var task = await _projectTaskRepository
                .GetByIdAsync(request.Id);

            if (task == null)
            {
                return ApiResponse<string>
                    .FailResponse("Task not found", 404);
            }

            _projectTaskRepository.Delete(task);

            await _projectTaskRepository.SaveChangesAsync();

            return ApiResponse<string>
                .SuccessResponse(
                    null!,
                    "Task deleted successfully");
        }
    }
}