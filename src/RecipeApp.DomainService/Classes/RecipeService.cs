using RecipeApp.Domain.Entities;
using RecipeApp.Dto;
using RecipeApp.Exceptions;
using RecipeApp.Infrastructure.Repositories;

namespace RecipeApp.DomainService;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;

    public RecipeService(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    public Task<List<Recipe>> GetAllAsync()
        => _recipeRepository.GetAllAsync();

    public Task<Recipe?> GetByIdAsync(int id)
        => _recipeRepository.GetByIdAsync(id);

    public async Task<Recipe> AddAsync(CreateRecipeDto recipeDto)
    {
        var recipe = new Recipe
        {
            Name = recipeDto.Name,
            Description = recipeDto.Description,
            CountryId = recipeDto.CountryId,
            UserId = recipeDto.UserId,
            PhotoUrl = recipeDto.PhotoUrl
        };

        return await _recipeRepository.AddAsync(recipe);
    }

    public Task<Recipe?> GetByRecipenameAsync(string recipeName)
        => _recipeRepository.GetByRecipename(recipeName);

    public async Task DeleteAsync(int id)
    {
        var recipe = await _recipeRepository.GetByIdAsync(id);
        if (recipe == null)
        {
            throw new ResourceNotFoundException($"Recipe with ID {id} not found.");
        }

        await _recipeRepository.DeleteAsync(recipe);
    }

    public async Task<Recipe> UpdateAsync(int id, UpdateRecipeDto recipeDto)
    {
        var recipe = await _recipeRepository.GetByIdAsync(id);
        if (recipe == null)
        {
            throw new ResourceNotFoundException($"Recipe with ID {id} not found.");
        }

        recipe.Name = recipeDto.Name ?? recipe.Name;
        recipe.Description = recipeDto.Description ?? recipe.Description;
        recipe.CountryId = recipeDto.CountryId.HasValue ? recipeDto.CountryId.Value : recipe.CountryId;
        recipe.PhotoUrl = recipeDto.PhotoUrl ?? recipe.PhotoUrl;

        return await _recipeRepository.UpdateAsync(recipe);
    }
}

