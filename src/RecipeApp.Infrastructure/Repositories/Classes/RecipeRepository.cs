using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly AppDbContext _dbContext;

    public RecipeRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task<List<Recipe>> GetAllAsync()
    {
        return await _dbContext.Recipe.ToListAsync();
    }

    public async Task<Recipe?> GetByIdAsync(int id)
    {
        return await _dbContext.Recipe.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Recipe?> GetByRecipename(string recipeName)
    {
        return await _dbContext.Recipe.FirstOrDefaultAsync(r => r.Name == recipeName);
    }

    public async Task<Recipe> AddAsync(Recipe recipe)
    {
        await _dbContext.Recipe.AddAsync(recipe);
        return recipe;
    }

    public async Task<Recipe> UpdateAsync(Recipe recipe)
    {
        _dbContext.Recipe.Update(recipe);
        await _dbContext.SaveChangesAsync();
        return recipe;
    }

    public async Task DeleteAsync(Recipe recipe)
    {
        _dbContext.Recipe.Remove(recipe);
        await _dbContext.SaveChangesAsync();
    }
}