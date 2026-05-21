using Application_Layer.Common;
using Application_Layer.DTOs;
using Domain.Entities;
using MediatR;
using Persistence_Layer.Repository.ProjectRepo;

namespace Application_Layer.Features.Projects.Commands.CreateProject
{
    public class CreateProjectCommandHandler
        : IRequestHandler<CreateProjectCommand, ApiResponse<ProjectDTO>>
    {
        private readonly IProjectRepository _projectRepository;

        public CreateProjectCommandHandler(
            IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ApiResponse<ProjectDTO>> Handle(
            CreateProjectCommand request,
            CancellationToken cancellationToken)
        {
            var project = new Project
            {
                Name = request.Name,
                Description = request.Description,
                UserId = request.UserId,
                CreatedAt = DateTime.UtcNow
            };

            await _projectRepository.AddAsync(project);

            await _projectRepository.SaveChangesAsync();

            var response = new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                CreatedAt = project.CreatedAt
            };

            return ApiResponse<ProjectDTO>
                .SuccessResponse(response, "Project created successfully");
        }
    }
}