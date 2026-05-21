using Application_Layer.Common;
using MediatR;

namespace Application_Layer.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskCommand
        : IRequest<ApiResponse<string>>
    {
        public int Id { get; set; }
    }
}