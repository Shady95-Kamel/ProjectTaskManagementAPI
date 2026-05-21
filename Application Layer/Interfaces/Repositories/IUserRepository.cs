using Domain.Entities;

namespace Application_Layer.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<bool> IsEmailExistsAsync(string email);

        Task<bool> RegisterAsync(User user, string password);

        Task<User?> GetByEmailAsync(string email);

        Task<bool> CheckPasswordAsync(User user, string password);

        Task AddRefreshTokenAsync(RefreshToken refreshToken);

        Task<RefreshToken?> GetRefreshTokenAsync(string refreshToken);

        Task<User?> GetByIdAsync(string userId);

        Task SaveChangesAsync();
    }
}