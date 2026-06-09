using RecipeApp.Domain.Entities;
namespace RecipeApp.Infrastructure.Repositories
{
    public interface IFavoriteRepository
    {
        Task<RecipeFavorite> GetByIdAsync(int id);
        Task DeleteAsync(int id, RecipeFavorite favorite);
        Task<RecipeFavorite> AddAsync(RecipeFavorite favorite);
    }
}