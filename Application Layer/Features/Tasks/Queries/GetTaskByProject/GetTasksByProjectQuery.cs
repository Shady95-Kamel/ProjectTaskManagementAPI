using Application_Layer.Common;
using Application_Layer.DTOs;
using Domain.Entities;
using MediatR;

namespace Application_Layer.Features.Tasks.Queries.GetTasksByProject
{
    public class GetTasksByProjectQuery
        : IRequest<ApiResponse<IEnumerable<TaskDTO>>>
    {
        public int ProjectId { get; set; }
    }
}