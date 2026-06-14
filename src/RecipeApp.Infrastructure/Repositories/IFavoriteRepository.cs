using RecipeApp.Domain.Entities;
namespace RecipeApp.Infrastructure.Repositories
{
    public interface IFavoriteRepository
    {
        Task<List<Favorite>> GetByUserAsync(int userId);
        Task<Favorite?> GetFavoriteByIdAsync(int userId);
        Task<Favorite> AddAsync(Favorite favorite);
        Task DeleteAsync(Favorite favorite);
    }
}