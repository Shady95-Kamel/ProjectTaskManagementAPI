using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence_Layer.Repository.ProjectTaskRepo
{
    public interface IProjectTaskRepository
    {
        Task<IEnumerable<ProjectTask>> GetTasksByProjectIdAsync(int projectId);

        Task<ProjectTask?> GetByIdAsync(int id);

        Task AddAsync(ProjectTask task);

        void Update(ProjectTask task);

        void Delete(ProjectTask task);

        Task SaveChangesAsync();
    }
}
