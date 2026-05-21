using Application_Layer.Common;
using Application_Layer.DTOs;
using Domain.Entities;
using MediatR;

namespace Application_Layer.Features.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand
        : IRequest<ApiResponse<ProjectDTO>>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}