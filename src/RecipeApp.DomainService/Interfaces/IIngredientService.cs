using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.DomainService.Interfaces
{
    public interface IIngredientService
    {
        Task<Ingredient> AddAsync(CreateIngredientDto ingredientDto);
        Task<List<Ingredient>> GetAllAsync();
        Task<Ingredient> GetByNameAsync(string name);
        Task<Ingredient> GetByIdAsync(int id);
        Task UpdateAsync(int id, IngredientDto ingredientDto);
        Task DeleteAsync(int id);
    }
}