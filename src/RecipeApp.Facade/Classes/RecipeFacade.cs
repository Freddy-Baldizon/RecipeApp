using RecipeApp.DomainService;
using RecipeApp.DomainService.Interfaces;
using RecipeApp.Dto;
using RecipeApp.Exceptions;
using RecipeApp.Facade.Interfaces;
using RecipeApp.Facade.Mappers;
using RecipeApp.Infrastructure;

namespace RecipeApp.Facade.Classes;

public class RecipeFacade : IRecipeFacade
{
    private readonly IRecipeService recipeService;
    
    public RecipeFacade(IRecipeService recipeService)
    {
        this.recipeService = recipeService;
    }
    public async Task<RecipeDto> AddAsync(RecipeDto recipeDto)
    {
        var recipe = await recipeService.AddAsync(recipeDto);
        return RecipeMapper.ToDto(recipe);
    }

    public async Task DeleteAsync(int recipeid)
    {
        await recipeService.DeleteAsync(recipeid);
    }

    public async Task<List<RecipeDto>> GetAllAsync()
    {
        var recipes = await recipeService.GetAllAsync();
        return RecipeMapper.ToDto(recipes);
    }

    public async Task<List<RecipeDto>> GetAllByRecipeIdAsync(int recipeId)
    {
        var recipe = await recipeService.GetAllAsync();
        return RecipeMapper.ToDto(recipe);
    }

    public async Task<RecipeDto> GetByIdAsync(int id)
    {
        var recipe = await recipeService.GetByIdAsync(id);
        if (recipe == null) throw new ResourceNotFoundException();
        return RecipeMapper.ToDto(recipe);     
    }

    public async Task<RecipeDto?> GetByRecipeNameAsync(string recipeName)
    {
        var recipe = await recipeService.GetByRecipeNameAsync(recipeName);
        if (recipe == null) throw new ResourceNotFoundException();
        return RecipeMapper.ToDto(recipe);    
    }

    public async Task<RecipeDto> UpdateAsync(int id, UpdateRecipeDto recipeDto)
    {
        var upDateRecipe = await recipeService.UpdateAsync(id, recipeDto);
        return RecipeMapper.ToDto(upDateRecipe);
    }
}