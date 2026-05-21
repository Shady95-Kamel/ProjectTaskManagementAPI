using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Context;
using Persistence_Layer.Repository.ProjectTaskRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence_Layer.Repository
{

    public class ProjectTaskRepository : IProjectTaskRepository
    {
        private readonly ProjectTaskDbContext _context;

        public ProjectTaskRepository(ProjectTaskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProjectTask>> GetTasksByProjectIdAsync(int projectId)
        {
            return await _context.Tasks
                .Where(x => x.ProjectId == projectId)
                .ToListAsync();
        }

        public async Task<ProjectTask?> GetByIdAsync(int id)
        {
            return await _context.Tasks
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(ProjectTask task)
        {
            await _context.Tasks.AddAsync(task);
        }

        public void Update(ProjectTask task)
        {
            _context.Tasks.Update(task);
        }

        public void Delete(ProjectTask task)
        {
            _context.Tasks.Remove(task);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
