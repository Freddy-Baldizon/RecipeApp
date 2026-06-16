using RecipeApp.DomainService;
using RecipeApp.DomainService.Interfaces;
using RecipeApp.Dto;
using RecipeApp.Exceptions;
using RecipeApp.Facade.Interfaces;
using RecipeApp.Facade.Mappers;

namespace RecipeApp.Facade;

public class RecipeFacade : IRecipeFacade
{
    private readonly IRecipeService recipeService;

    public RecipeFacade(IRecipeService recipeService)
    {
        this.recipeService = recipeService;
    }

    public async Task<RecipeDto> AddAsync(CreateRecipeDto recipeDto)
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
        var recipe = await recipeService.GetAllAsync();
        return RecipeMapper.ToDto(recipe);
    }

    public async Task<RecipeDto> GetByIdAsync(int id)
    {
        var recipe = await recipeService.GetByIdAsync(id);
        if (recipe == null) throw new ResourceNotFoundException();
        return RecipeMapper.ToDto(recipe);     
    }

    public async Task<RecipeDto?> GetByRecipenameAsync(string recipeName)
    {
        var recipe = await recipeService.GetByRecipeNameAsync(recipeName);
        if (recipe == null) throw new ResourceNotFoundException();
        return RecipeMapper.ToDto(recipe);    
    }

    public async Task UpdateAsync(int id, UpdateRecipeDto recipeDto)
    {
        await recipeService.UpdateAsync(id, recipeDto);
    }
}