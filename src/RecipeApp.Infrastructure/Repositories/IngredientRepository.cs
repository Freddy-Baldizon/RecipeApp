using System;
using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;
 
namespace RecipeApp.Infrastructure.Repositories
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly RecipeAppDbContext _dbContext;

        public IngredientRepository(RecipeAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Ingredient> GetByNameAsync(string name)
        {
            return await _dbContext.Ingredients.FirstOrDefaultAsync(i => i.Name == name);
        }

        public async Task<IEnumerable<Ingredient>> GetAllAsync()
        {
            return await _dbContext.Ingredients.ToListAsync();
        }

        public async Task AddAsync(Ingredient ingredient)
        {
            await _dbContext.Ingredients.AddAsync(ingredient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ingredient ingredient)
        {
            _dbContext.Ingredients.Update(ingredient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {

                _dbContext.Ingredients.Remove(ingredient);
                await _dbContext.SaveChangesAsync();
            
        }
    }
}