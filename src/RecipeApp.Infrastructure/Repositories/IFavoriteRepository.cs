using RecipeApp.Domain.Entities;
namespace RecipeApp.Infrastructure.Repositories
{
    public interface IFavoriteRepository
    {
        Task<RecipeFavorite> GetByIdAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task AddAsync(RecipeFavorite favorite);
    }
}