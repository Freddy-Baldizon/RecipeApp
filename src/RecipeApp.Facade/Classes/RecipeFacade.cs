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

    public async Task DeleteAsync(int id)
    {
        await recipeService.DeleteAsync(id);
    }

    public async Task<List<RecipeDto>> GetAllAsync()
    {
        var recipes = await recipeService.GetAllAsync();
        return RecipeMapper.ToDto(recipes);
    }

    public async Task<RecipeDto?> GetByRecipenameAsync(int id)
    {
        var recipe = await recipeService.GetByIdAsync(id);
        if (recipe == null) throw new ResourceNotFoundException();
        return RecipeMapper.ToDto(recipe);
    }

    public Task UpdateAsync(int id, RecipeDto recipeDto)
    {
        throw new NotImplementedException();
    }
}