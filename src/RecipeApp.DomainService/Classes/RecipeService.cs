using RecipeApp.Domain.Entities;
using RecipeApp.DomainService.Interfaces;
using RecipeApp.Dto;
using RecipeApp.Exceptions;
using RecipeApp.Infrastructure.Repositories.Interfaces;

namespace RecipeApp.DomainService.Classes;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;

    public RecipeService(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    public Task<List<Recipe>> GetAllAsync()
        => _recipeRepository.GetAllAsync();

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

    public async Task DeleteAsync(string recipeName)
    {
        var recipe = await _recipeRepository.GetByRecipename(recipeName);
        if (recipe == null)
        {
            throw new ResourceNotFoundException($"Recipe with name '{recipeName}' not found.");
        }

        await _recipeRepository.DeleteAsync(recipe);
    }
}