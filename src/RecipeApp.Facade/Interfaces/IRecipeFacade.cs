using RecipeApp.Dto;

namespace RecipeApp.Facade.Interfaces
{
    public interface IRecipeFacade
    {
        Task<List<RecipeDto>> GetAllAsync();
        Task<RecipeDto> AddAsync(CreateRecipeDto recipeDto);
        Task<RecipeDto> GetByIdAsync(int id);
        Task<RecipeDto?> GetByRecipenameAsync(string recipeName);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, UpdateRecipeDto recipeDto);
    }
}