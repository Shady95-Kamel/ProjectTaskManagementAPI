using Application_Layer.Common;
using Application_Layer.DTOs;
using Application_Layer.Features.Tasks.Commands.UpdateTaskStatus;
using MediatR;
using Persistence_Layer.Repository.ProjectTaskRepo;

namespace Application_Layer.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskStatusCommandHandler
        : IRequestHandler<UpdateTaskStatusCommand,
            ApiResponse<TaskDTO>>
    {
        private readonly IProjectTaskRepository _projectTaskRepository;

        public UpdateTaskStatusCommandHandler(
            IProjectTaskRepository projectTaskRepository)
        {
            _projectTaskRepository = projectTaskRepository;
        }

        public async Task<ApiResponse<TaskDTO>> Handle(
            UpdateTaskStatusCommand request,
            CancellationToken cancellationToken)
        {
            var task = await _projectTaskRepository
                .GetByIdAsync(request.Id);

            if (task == null)
            {
                return ApiResponse<TaskDTO>
                    .FailResponse("Task not found", 404);
            }

            task.Status = request.Status;

            var response = new TaskDTO {Status = task.Status };

            _projectTaskRepository.Update(task);

            await _projectTaskRepository.SaveChangesAsync();

            return ApiResponse<TaskDTO>
                .SuccessResponse(
                    response,
                    "Task status updated successfully");
        }
    }
}