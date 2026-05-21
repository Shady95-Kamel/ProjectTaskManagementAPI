using Application_Layer.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Context;

namespace Persistence_Layer.Repositories
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly ProjectTaskDbContext _context;

        public RefreshTokenRepository(ProjectTaskDbContext context)
        {
            _context = context;
        }

        public async Task<RefreshToken?> GetByTokenAsync(string token)
        {
            return await _context.RefreshTokens
                .FirstOrDefaultAsync(x => x.Token == token);
        }

        public async Task AddAsync(RefreshToken token)
        {
            await _context.RefreshTokens.AddAsync(token);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}