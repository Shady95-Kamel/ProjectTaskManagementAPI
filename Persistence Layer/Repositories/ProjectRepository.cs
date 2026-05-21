using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Context;
using Persistence_Layer.Repository.ProjectRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence_Layer.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ProjectTaskDbContext _context;

        public ProjectRepository(ProjectTaskDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Project>> GetAllAsync(string userId)
        {
            return await _context.Projects
                .Where(x => x.UserId == userId)
                .ToListAsync();
        }

        public async Task<Project?> GetByIdAsync(int id)
        {
            return await _context.Projects
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
        }

        public void Update(Project project)
        {
            _context.Projects.Update(project);
        }

        public void Delete(Project project)
        {
            _context.Projects.Remove(project);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
