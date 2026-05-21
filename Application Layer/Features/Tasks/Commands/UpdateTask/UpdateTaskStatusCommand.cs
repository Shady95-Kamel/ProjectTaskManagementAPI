using Application_Layer.Common;
using Application_Layer.DTOs;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application_Layer.Features.Tasks.Commands.UpdateTaskStatus
{
    public class UpdateTaskStatusCommand
        : IRequest<ApiResponse<TaskDTO>>
    {
        public int Id { get; set; }

        public TaskStatusEnum Status { get; set; }
    }
}