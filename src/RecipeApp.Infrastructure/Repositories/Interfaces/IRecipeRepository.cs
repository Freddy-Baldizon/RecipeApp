using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.Infrastructure.Repositories
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetAllAsync();
        Task<Recipe?> GetByIdAsync(int id);
        Task<Recipe?> GetByRecipename(string recipeName);
        Task<Recipe> AddAsync(Recipe recipe,List<RecipeIngredientDto> ingredientsDto);
        Task DeleteAsync(Recipe recipe);
        Task<Recipe> UpdateAsync(Recipe recipe);
    }
}