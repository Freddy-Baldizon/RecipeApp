using RecipeApp.Dto;

namespace RecipeApp.Facade.Interfaces
{
    public interface IFavoriteFacade
    {
        Task<FavoriteDto> AddAsync(FavoriteDto favoriteDto);
        Task<List<FavoriteDto>> GetAllByUserIdAsync(int userId);
        Task DeleteAsync(int userId, int recipeId);
    }
}