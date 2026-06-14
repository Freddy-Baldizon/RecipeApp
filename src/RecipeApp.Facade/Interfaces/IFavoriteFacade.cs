using RecipeApp.Dto;

namespace RecipeApp.Facade.Interfaces
{
    public interface IFavoriteFacade
    {
        Task<FavoriteDto> AddAsync(FavoriteDto favoriteDto);
        Task<FavoriteDto?> GetByRecipeIdAsync(int id);
        Task<List<FavoriteDto>> GetAllByRecipeIdAsync(int recipeId);
        Task DeleteAsync(int id);
    }
}