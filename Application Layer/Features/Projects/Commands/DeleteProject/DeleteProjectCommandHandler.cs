using Application_Layer.Common;
using MediatR;
using Persistence_Layer.Repository.ProjectRepo;

namespace Application_Layer.Features.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommandHandler
        : IRequestHandler<DeleteProjectCommand,
            ApiResponse<string>>
    {
        private readonly IProjectRepository _projectRepository;

        public DeleteProjectCommandHandler(
            IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ApiResponse<string>> Handle(
            DeleteProjectCommand request,
            CancellationToken cancellationToken)
        {

            var project = await _projectRepository
                .GetByIdAsync(request.Id);

            if (project == null)
            {
                return ApiResponse<string>
                    .FailResponse("Project not found", 404);
            }


            _projectRepository.Delete(project);

            await _projectRepository.SaveChangesAsync();

            return ApiResponse<string>
                .SuccessResponse(
                    null!,
                    "Project deleted successfully");
        }
    }
}