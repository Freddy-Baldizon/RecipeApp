using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.DomainService.Interfaces
{
    public interface IFavoriteService
    {
        Task<Favorite> AddAsync(FavoriteDto favoriteDto);
        Task<List<Favorite>> GetAllByUserIdAsync(int userId);
        Task DeleteAsync(int userId, int recipeId);
    }
}