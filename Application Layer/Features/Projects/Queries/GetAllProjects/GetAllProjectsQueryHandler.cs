using Application_Layer.Common;
using Application_Layer.DTOs;
using Domain.Entities;
using MediatR;
using Persistence_Layer.Repository.ProjectRepo;

namespace Application_Layer.Features.Projects.Queries.GetAllProjects
{
    public class GetAllProjectsQueryHandler
        : IRequestHandler<GetAllProjectsQuery,
            ApiResponse<IEnumerable<ProjectDTO>>>
    {
        private readonly IProjectRepository _projectRepository;

        public GetAllProjectsQueryHandler(
            IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ApiResponse<IEnumerable<ProjectDTO>>> Handle(
            GetAllProjectsQuery request,
            CancellationToken cancellationToken)
        {
            var projects = await _projectRepository
                .GetAllAsync(request.UserId);


            var result = projects.Select(p => new ProjectDTO
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CreatedAt = p.CreatedAt
            });

            return ApiResponse<IEnumerable<ProjectDTO>>
                .SuccessResponse(result, "Projects retrieved successfully");
        }
    }
}