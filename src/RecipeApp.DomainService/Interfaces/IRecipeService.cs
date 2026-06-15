using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.DomainService;

public interface IRecipeService
{
    Task<List<Recipe>> GetAllAsync();
    Task<Recipe?> GetByIdAsync(int recipeId);
    Task<Recipe?> GetByRecipeNameAsync(string recipeName);
    Task<Recipe> AddAsync(CreateRecipeDto recipeDto);
    Task DeleteAsync(int id);
    Task<Recipe> UpdateAsync(int id, UpdateRecipeDto recipeDto);
}