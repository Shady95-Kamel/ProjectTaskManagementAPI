using Application_Layer.Common;
using Application_Layer.DTOs;
using MediatR;

namespace Application_Layer.Features.Projects.Queries.GetAllProjects
{
    public class GetAllProjectsQuery
        : IRequest<ApiResponse<IEnumerable<ProjectDTO>>>
    {
        public string UserId { get; set; }
    }
}