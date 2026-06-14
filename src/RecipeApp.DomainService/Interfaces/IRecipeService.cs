using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.DomainService.Interfaces;

public interface IRecipeService
{
    Task<List<Recipe>> GetAllAsync();
    Task<Recipe> AddAsync(CreateRecipeDto recipeDto);
    Task<Recipe?> GetByRecipenameAsync(string recipeName);
    Task DeleteAsync(string recipeName);
}