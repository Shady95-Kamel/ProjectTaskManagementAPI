using Application_Layer.Common;
using Application_Layer.DTOs;
using Application_Layer.Interfaces.Repositories;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Persistence_Layer.Repository.ProjectRepo;
using Persistence_Layer.Repository.ProjectTaskRepo;

namespace Application_Layer.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommandHandler
        : IRequestHandler<CreateTaskCommand,
            ApiResponse<TaskDTO>>
    {
        private readonly IProjectTaskRepository _projectTaskRepository;
        private readonly IProjectRepository _projectRepository;

        public CreateTaskCommandHandler(
            IProjectTaskRepository projectTaskRepository,
            IProjectRepository projectRepository)
        {
            _projectTaskRepository = projectTaskRepository;
            _projectRepository = projectRepository;
        }

        public async Task<ApiResponse<TaskDTO>> Handle(
            CreateTaskCommand request,
            CancellationToken cancellationToken)
        {

            var project = await _projectRepository
                .GetByIdAsync(request.ProjectId);

            if (project == null)
            {
                return ApiResponse<TaskDTO>
                    .FailResponse("Project not found", 404);
            }

            var task = new ProjectTask
            {
                Title = request.Title,
                Description = request.Description,
                DueDate = request.DueDate,
                Priority = request.Priority,
                Status = TaskStatusEnum.Pending,
                ProjectId = request.ProjectId
            };

            await _projectTaskRepository.AddAsync(task);
            await _projectTaskRepository.SaveChangesAsync();


            var response = new TaskDTO
            {
                Title = task.Title,
                Description = task.Description,
                DueDate = task.DueDate,
                Priority = task.Priority,
                ProjectId = task.ProjectId
            };

            return ApiResponse<TaskDTO>
                .SuccessResponse(response, "Task created successfully");
        }
    }
}