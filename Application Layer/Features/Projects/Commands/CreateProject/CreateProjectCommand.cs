using Application_Layer.Common;
using Application_Layer.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Layer.Features.Projects.Commands.CreateProject
{
   public class CreateProjectCommand : IRequest<ApiResponse<ProjectDTO>>
   {
       public string Name { get; set; }

       public string Description { get; set; }

       public string UserId { get; set; }
   }
}
