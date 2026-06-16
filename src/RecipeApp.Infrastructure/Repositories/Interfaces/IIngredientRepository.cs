using System;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Repositories.Interfaces
{
    public interface IIngredientRepository
    {
        Task<Ingredient> GetByNameAsync(string name);
        Task<Ingredient> GetByIdAsync(int id);
        Task<List<Ingredient>> GetAllAsync();
        Task<Ingredient> AddAsync(Ingredient ingredient);
        Task UpdateAsync(Ingredient ingredient);
        Task DeleteAsync(Ingredient ingredient);
    }
}