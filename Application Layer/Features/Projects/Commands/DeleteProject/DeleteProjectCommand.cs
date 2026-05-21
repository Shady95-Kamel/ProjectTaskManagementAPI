using Application_Layer.Common;
using MediatR;

namespace Application_Layer.Features.Projects.Commands.DeleteProject
{
    public class DeleteProjectCommand
        : IRequest<ApiResponse<string>>
    {
        public int Id { get; set; }
    }
}