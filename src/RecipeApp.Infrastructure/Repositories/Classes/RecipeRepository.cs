using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.Infrastructure.Repositories.Classes;

public class RecipeRepository : IRecipeRepository
{
    private readonly AppDbContext _dbContext;

    public RecipeRepository(AppDbContext context)
    {
        _dbContext = context;
    }

    public async Task<List<Recipe>> GetAllAsync()
    {
        return await _dbContext.Recipe
            .Include(r => r.User)
            .Include(r => r.Country)
            .Include(r=> r.RecipeIngredients)
            .ThenInclude(ri => ri.Ingredient)
            .ToListAsync();
    }

    public async Task<Recipe?> GetByIdAsync(int id)
    {
        return await _dbContext.Recipe
            .Include(r => r.User)
            .Include(r => r.Country)
            .Include(r=> r.RecipeIngredients)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Recipe?> GetByRecipename(string recipeName)
    {
        return await _dbContext.Recipe.FirstOrDefaultAsync(r => r.Name == recipeName);
    }

    public async Task<Recipe> AddAsync(Recipe recipe,List<RecipeIngredientDto> ingredientsDto)
    {
        await _dbContext.Recipe.AddAsync(recipe);
        await _dbContext.SaveChangesAsync();
        foreach (var ingredient in ingredientsDto)
        {
            var newIngredient = new RecipeIngredient
            {
                RecipeId = recipe.Id,
                IngredientId = ingredient.IngredientId,
                Amount = ingredient.Amount
            };
            await _dbContext.RecipeIngredient.AddAsync(newIngredient);
        }
        await _dbContext.SaveChangesAsync();
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