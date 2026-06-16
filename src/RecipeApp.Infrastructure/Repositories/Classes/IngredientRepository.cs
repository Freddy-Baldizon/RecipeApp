using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Repositories.Interfaces;

namespace RecipeApp.Infrastructure.Repositories.Classes
{
    public class IngredientRepository : IIngredientRepository
    {
        private readonly AppDbContext _dbContext;

        public IngredientRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Ingredient> GetByNameAsync(string name)
        {
            return await _dbContext.Ingredient.FirstOrDefaultAsync(i => i.Name == name);
        }

        public async Task<List<Ingredient>> GetAllAsync()
        {
            return await _dbContext.Ingredient.ToListAsync();
        }

        public async Task<Ingredient> AddAsync(Ingredient ingredient)
        {
            await _dbContext.Ingredient.AddAsync(ingredient);
            await _dbContext.SaveChangesAsync();
            return ingredient;
        }

        public async Task UpdateAsync(Ingredient ingredient)
        {
            _dbContext.Ingredient.Update(ingredient);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Ingredient ingredient)
        {

                _dbContext.Ingredient.Remove(ingredient);
                await _dbContext.SaveChangesAsync();
            
        }

        public async Task<Ingredient> GetByIdAsync(int id)
        {
            return await _dbContext.Ingredient.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}