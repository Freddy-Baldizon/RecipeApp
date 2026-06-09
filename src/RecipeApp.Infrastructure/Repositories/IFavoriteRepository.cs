using RecipeApp.Domain.Entities;
namespace RecipeApp.Infrastructure.Repositories
{
    public interface IFavoriteRepository
    {
        Task<RecipeFavorite> GetByIdAsync(int id);
        Task DeleteAsync(int id, RecipeFavorite favorite);
        Task AddAsync(RecipeFavorite favorite);
    }
}