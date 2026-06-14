using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;
 
namespace RecipeApp.Infrastructure.Repositories
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
    }
}