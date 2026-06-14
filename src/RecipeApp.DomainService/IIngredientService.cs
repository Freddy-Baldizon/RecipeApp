using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.DomainService
{
    public interface IIngredientService
    {
        Task<Ingredient> AddAsync(IngredientDto ingredientDto);
        Task<List<Ingredient>> GetAllAsync();
        Task<Ingredient> GetByNameAsync(string name);
        Task UpdateAsync(int id, IngredientDto ingredientDto);
        Task DeleteAsync(string name);
    }
}