using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Repositories
{
    public interface IRecipeRepository
    {
        Task<List<Recipe>> GetAllAsync();
        Task<Recipe> AddAsync(Recipe recipe);
        
        Task<Recipe?> GetByRecipename(string recipeName);

        Task DeleteAsync(Recipe recipe);
    }
}