using System;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Repositories
{
    public interface IIngredientRepository
    {
        Task<Ingredient> GetByNameAsync(string name);
        Task<IEnumerable<Ingredient>> GetAllAsync();
        Task AddAsync(Ingredient ingredient);
        Task UpdateAsync(Ingredient ingredient);
        Task DeleteAsync(Guid id, Ingredient ingredient);
    }
}