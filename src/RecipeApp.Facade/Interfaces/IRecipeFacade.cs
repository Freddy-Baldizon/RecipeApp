using RecipeApp.Dto;

namespace RecipeApp.Facade.Interfaces
{
    public interface IRecipeFacade
    {
        Task<List<RecipeDto>> GetAllAsync();
        Task<RecipeDto> AddAsync(CreateRecipeDto recipeDto);
        Task<RecipeDto?> GetByRecipenameAsync(string recipeName);
        Task DeleteAsync(string recipeName);
    }
}