using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly AppDbContext _context;

    public RecipeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Recipe>> GetAllAsync()
    {
        return await _context.Recipe
            .Include(r => r.User)
            .Include(r => r.Country)
            .ToListAsync();
    }

    public async Task<Recipe?> GetByIdAsync(int id)
     {
            //Devolver solo el id de la receta
         return await _context.Recipe
    //         .Include(r => r.User)
    //         .Include(r => r.Country)
    //         .Include(r => r.Comments)
    //         .Include(r => r.Ratings)
    //         .Include(r => r.Steps)
    //         .Include(r => r.RecipeIngredients)
    //         .Include(r => r.RecipeFavorites)
             .FirstOrDefaultAsync(r => r.Id == id);
     }

    public async Task<Recipe?> GetByRecipename(string recipeName)
    {
        //Devolver solo el id del usuario o dejarlo como esta(DTO)
         return await _context.Recipe
        //     .Include(r => r.User)
        //     .Include(r => r.Country)
            .FirstOrDefaultAsync(r => r.Name == recipeName);
    }

    public async Task<Recipe> AddAsync(Recipe recipe)
    {
        await _context.Recipe.AddAsync(recipe);
        return recipe;
    }

    public async Task DeleteAsync(Recipe recipe)
    {
        _context.Recipe.Remove(recipe);
        await Task.CompletedTask;
    }
    
}



