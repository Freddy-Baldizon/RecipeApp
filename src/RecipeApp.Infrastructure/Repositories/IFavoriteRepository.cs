using system;
using recipeapp.domain.entities;

namespace recipeapp.infrastructure.repositories
{
    public interface IFavoriteRepository
    {
        Task<Favorite> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task AddAsync(Favorite favorite);
    }
}