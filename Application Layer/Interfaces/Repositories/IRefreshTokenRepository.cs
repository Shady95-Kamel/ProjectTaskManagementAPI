using Domain.Entities;

namespace Application_Layer.Interfaces.Repositories
{
    public interface IRefreshTokenRepository
    {
        Task<RefreshToken?> GetByTokenAsync(string token);

        Task AddAsync(RefreshToken token);

        Task SaveChangesAsync();
    }
}