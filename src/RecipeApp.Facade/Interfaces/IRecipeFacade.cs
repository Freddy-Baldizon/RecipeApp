using RecipeApp.Dto;

namespace RecipeApp.Facade.Interfaces
{
    public interface IRecipeFacade
    {
        Task<List<RecipeDto>> GetAllAsync();
        Task<RecipeDto> AddAsync(RecipeDto recipeDto);
        Task<RecipeDto> GetByIdAsync(int id);
        Task<RecipeDto?> GetByRecipeNameAsync(string recipeName);
        Task DeleteAsync(int id);
        Task<RecipeDto> UpdateAsync(int id, UpdateRecipeDto recipeDto);
    }
}