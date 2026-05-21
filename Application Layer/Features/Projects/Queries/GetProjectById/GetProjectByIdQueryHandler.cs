using Application_Layer.Common;
using Application_Layer.DTOs;
using Domain.Entities;
using MediatR;
using Persistence_Layer.Repository.ProjectRepo;

namespace Application_Layer.Features.Projects.Queries.GetProjectById
{
    public class GetProjectByIdQueryHandler
        : IRequestHandler<GetProjectByIdQuery,
            ApiResponse<ProjectDTO>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetProjectByIdQueryHandler(
            IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ApiResponse<ProjectDTO>> Handle(
            GetProjectByIdQuery request,
            CancellationToken cancellationToken)
        {
            var project = await _projectRepository
                .GetByIdAsync(request.Id);

            if (project == null)
            {
                return ApiResponse<ProjectDTO>
                    .FailResponse("Project not found", 404);
            }

            var projectDTO = new ProjectDTO 
            {
                Id = request.Id,
                CreatedAt = project.CreatedAt,
                Description = project.Description,
                Name = project.Name,
            };

            return ApiResponse<ProjectDTO>
                .SuccessResponse(
                    projectDTO,
                    "Project retrieved successfully");
        }
    }
}