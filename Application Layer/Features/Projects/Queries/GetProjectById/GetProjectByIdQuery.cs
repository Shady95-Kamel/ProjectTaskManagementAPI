using Application_Layer.Common;
using Application_Layer.DTOs;
using Domain.Entities;
using MediatR;

namespace Application_Layer.Features.Projects.Queries.GetProjectById
{
    public class GetProjectByIdQuery
        : IRequest<ApiResponse<ProjectDTO>>
    {
        public int Id { get; set; }
    }
}