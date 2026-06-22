using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Repositories.Interfaces
{
    public interface IFavoriteRepository
    {
        Task<List<Favorite>> GetByUserAsync(int userId);
        Task<Favorite?> GetFavoriteAsync(int userId, int recipeId);
        Task<Favorite> AddAsync(Favorite favorite);
        Task DeleteAsync(Favorite favorite);
    }
}