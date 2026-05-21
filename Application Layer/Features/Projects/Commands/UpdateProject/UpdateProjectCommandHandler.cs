using Application_Layer.Common;
using Application_Layer.DTOs;
using Application_Layer.Interfaces.Repositories;
using Domain.Entities;
using MediatR;
using Persistence_Layer.Repository.ProjectRepo;

namespace Application_Layer.Features.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommandHandler
        : IRequestHandler<UpdateProjectCommand, ApiResponse<ProjectDTO>>
    {
        private readonly IProjectRepository _projectRepository;

        public UpdateProjectCommandHandler(
            IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ApiResponse<ProjectDTO>> Handle(
            UpdateProjectCommand request,
            CancellationToken cancellationToken)
        {

            var project = await _projectRepository
                .GetByIdAsync(request.Id);

            if (project == null)
            {
                return ApiResponse<ProjectDTO>
                    .FailResponse("Project not found", 404);
            }

            project.Name = request.Name;
            project.Description = request.Description;


            _projectRepository.Update(project);
            await _projectRepository.SaveChangesAsync();

            var response = new ProjectDTO
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                CreatedAt = project.CreatedAt
            };

            return ApiResponse<ProjectDTO>
                .SuccessResponse(response, "Project updated successfully");
        }
    }
}