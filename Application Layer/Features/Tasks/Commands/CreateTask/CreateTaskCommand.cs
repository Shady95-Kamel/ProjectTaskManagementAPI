using Application_Layer.Common;
using Application_Layer.DTOs;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application_Layer.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskCommand
        : IRequest<ApiResponse<TaskDTO>>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public TaskPriority Priority { get; set; }

        public int ProjectId { get; set; }
    }
}