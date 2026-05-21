using Application_Layer.Common;
using Application_Layer.DTOs;
using Domain.Entities;
using MediatR;
using Persistence_Layer.Repository.ProjectTaskRepo;

namespace Application_Layer.Features.Tasks.Queries.GetTasksByProject
{
    public class GetTasksByProjectQueryHandler
        : IRequestHandler<GetTasksByProjectQuery,
            ApiResponse<IEnumerable<TaskDTO>>>
    {
        private readonly IProjectTaskRepository _projectTaskRepository;

        public GetTasksByProjectQueryHandler(
            IProjectTaskRepository projectTaskRepository)
        {
            _projectTaskRepository = projectTaskRepository;
        }

        public async Task<ApiResponse<IEnumerable<TaskDTO>>> Handle(
            GetTasksByProjectQuery request,
            CancellationToken cancellationToken)
        {
            var tasks = await _projectTaskRepository
                .GetTasksByProjectIdAsync(request.ProjectId);


            var response = tasks.Select(c => new TaskDTO 
            {
                Title = c.Title,
                Description = c.Description,
                Priority = c.Priority,
                ProjectId = c.ProjectId,
                DueDate = c.DueDate,
            });

            return ApiResponse<IEnumerable<TaskDTO>>
                .SuccessResponse(
                    response,
                    "Tasks retrieved successfully");
        }
    }
}