using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Repositories.Interfaces;
using RecipeApp.Exceptions;
using RecipeApp.Dto;
using RecipeApp.DomainService.Interfaces;

namespace RecipeApp.DomainService.Classes;

public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;

    public IngredientService(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    public async Task<Ingredient> AddAsync(IngredientDto ingredientDto)
    {
        var existingIngredient = await _ingredientRepository.GetByNameAsync(ingredientDto.Name!);
        if (existingIngredient != null)
        {
            throw new DuplicateResourceException($"An ingredient with the name '{ingredientDto.Name}' already exists.");
        }

        var ingredient = new Ingredient
        {
            Name = ingredientDto.Name!
        };

        return await _ingredientRepository.AddAsync(ingredient);
    }

    public async Task<List<Ingredient>> GetAllAsync()
    {
        return await _ingredientRepository.GetAllAsync();
    }

    public async Task<Ingredient> GetByNameAsync(string name)
    {
        var ingredient = await _ingredientRepository.GetByNameAsync(name);
        if (ingredient == null)
        {
            throw new ResourceNotFoundException($"Ingredient with name '{name}' not found.");
        }
        return ingredient;
    }

    public async Task UpdateAsync(int id, IngredientDto ingredientDto)
    {
        var existingIngredient = await _ingredientRepository.GetByNameAsync(ingredientDto.Name!);
        if (existingIngredient == null )
        {
            throw new ResourceNotFoundException($"An ingredient with the name '{ingredientDto.Name}'. not found.");
        }

        var ingredientToUpdate = new Ingredient
        {
            Id = id,
            Name = ingredientDto.Name!
        };

        await _ingredientRepository.UpdateAsync(ingredientToUpdate);
    }

    public async Task DeleteAsync(string name)
    {
        var ingredient = await _ingredientRepository.GetByNameAsync(name);
        if (ingredient == null)
        {
            throw new ResourceNotFoundException($"Ingredient with name '{name}' not found.");
        }
        await _ingredientRepository.DeleteAsync(ingredient);
    }
}