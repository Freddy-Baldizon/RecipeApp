using RecipeApp.Domain.Entities;
namespace RecipeApp.Infrastructure.Repositories
{
    public interface IFavoriteRepository
    {
        Task<List<RecipeFavorite>> GetByUserAsync(int userId);
        
        Task<RecipeFavorite> AddAsync(RecipeFavorite favorite);
        Task DeleteAsync(RecipeFavorite favorite);
    }
}