using Application_Layer.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistence_Layer.Context;

namespace Persistence_Layer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        private readonly ProjectTaskDbContext _context;

        public UserRepository(
            UserManager<User> userManager,
            ProjectTaskDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<bool> IsEmailExistsAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return user != null;
        }

        public async Task<bool> RegisterAsync(
            User user,
            string password)
        {
            var result = await _userManager
                .CreateAsync(user, password);

            return result.Succeeded;
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> CheckPasswordAsync(
            User user,
            string password)
        {
            return await _userManager
                .CheckPasswordAsync(user, password);
        }

        public async Task AddRefreshTokenAsync(
            RefreshToken refreshToken)
        {
            await _context.RefreshTokens
                .AddAsync(refreshToken);
        }

        public async Task<RefreshToken?> GetRefreshTokenAsync(
            string refreshToken)
        {
            return await _context.RefreshTokens
                .FirstOrDefaultAsync(x =>
                    x.Token == refreshToken);
        }

        public async Task<User?> GetByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}