using RecipeApp.Dto;

namespace RecipeApp.Facade.Interfaces
{
    public interface IIngredientFacade
    {
        Task<List<IngredientDto>> GetAllAsync();
        Task<IngredientDto> AddAsync(IngredientDto ingredientDto);
        Task<IngredientDto> GetByNameAsync(string name);
        Task<IngredientDto> GetByIdAsync(int id);
        Task<List<IngredientDto>> GetAllByRecipeIdAsync(int recipeId);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, IngredientDto ingredientDto);
    }
}