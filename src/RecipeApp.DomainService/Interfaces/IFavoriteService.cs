using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.DomainService.Interfaces
{
    public interface IFavoriteService
    {
        Task<Favorite> AddAsync(FavoriteDto favoriteDto);
        Task<Favorite?> GetByRecipeIdAsync(int id);
        Task<List<Favorite>> GetAllByRecipeIdAsync(int recipeId);
        Task DeleteAsync(int id);
    }
}