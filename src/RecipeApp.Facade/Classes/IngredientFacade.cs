using RecipeApp.DomainService.Interfaces;
using RecipeApp.Dto;
using RecipeApp.Exceptions;
using RecipeApp.Facade.Interfaces;
using RecipeApp.Facade.Mappers;

namespace RecipeApp.Facade;

public class IngredientFacade : IIngredientFacade
{
    private readonly IIngredientService ingredientService;

    public IngredientFacade(IIngredientService ingredientService)
    {
        this.ingredientService = ingredientService;
    }

    public async Task<IngredientDto> AddAsync(IngredientDto ingredientDto)
    {
        var ingredient = await ingredientService.AddAsync(ingredientDto);
        return IngredientMapper.ToDto(ingredient);
    }

      public async Task DeleteAsync(int id)
    {
        await ingredientService.DeleteAsync(id);
    }

    public async Task UpdateAsync(int id, IngredientDto ingredientDto)
    {
        await ingredientService.UpdateAsync(id, ingredientDto);
    }

    public async Task<IngredientDto> GetByNameAsync(string name)
    {
     var ingredient = await ingredientService.GetByNameAsync(name);
        if (ingredient == null) throw new ResourceNotFoundException();
        return IngredientMapper.ToDto(ingredient); 
    }

    public async Task<List<IngredientDto>> GetAllByRecipeIdAsync(int recipeId)
    {
        var ingredients = await ingredientService.GetAllAsync();
        return IngredientMapper.ToDto(ingredients);   
    }

    public async Task<IngredientDto> GetByIdAsync(int id)
    {
        var ingredient = await ingredientService.GetByIdAsync(id);
        if (ingredient == null) throw new ResourceNotFoundException();
        return IngredientMapper.ToDto(ingredient);    
    }
}
