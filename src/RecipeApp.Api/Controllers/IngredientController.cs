using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Api.Mappers;
using RecipeApp.Api.Models.Requests;
using RecipeApp.Dto;
using RecipeApp.Facade.Interfaces;

namespace RecipeApp.Api.Controllers;

[ApiController]
[Route("/api/ingredient")] 
public class IngredientController : ControllerBase
{
    private readonly IIngredientFacade ingredientFacade;

    public IngredientController(IIngredientFacade ingredientFacade)
    {
        this.ingredientFacade = ingredientFacade;
    }

    [HttpPost]
    public async Task<IActionResult> CreateIngredientAsync([FromBody] CreateIngredientRequestModel request)
    {
        var dto = IngredientMapper.ToDto(request); 
        var createdIngredient = await ingredientFacade.AddAsync(dto);
        return Created(string.Empty, IngredientMapper.ToModel(createdIngredient));
    }

    [HttpGet("{ingredientId}")]
    public async Task<IActionResult> GetByIdAsync(string ingredientId)
    {
        var ingredientDto = await ingredientFacade.GetByIdAsync(int.Parse(ingredientId));
        if (ingredientDto == null)
        {
            return NotFound("Ingredient not found");
        }

        return Ok(IngredientMapper.ToModel(ingredientDto));
    }

    [HttpGet("recipe/{recipeId}")]
    public async Task<IActionResult> GetAllByRecipeId(string recipeId)
    {
        var ingredientsDto = await ingredientFacade.GetAllByRecipeIdAsync(int.Parse(recipeId));
        if (ingredientsDto == null || !ingredientsDto.Any())
        {
            return NotFound("Recipe not found or no ingredients available");
        }

        return Ok(IngredientMapper.ToModel(ingredientsDto));
    }

    [HttpDelete("{ingredientId}")]
    public async Task<IActionResult> DeleteIngredient(string ingredientId)
    {
        await ingredientFacade.DeleteAsync(int.Parse(ingredientId));
        return NoContent();
    }

    [HttpPut("{ingredientId}")]
    public async Task<IActionResult> UpdateIngredient(string ingredientId, [FromBody] CreateIngredientRequestModel request)
    {
        var dto = IngredientMapper.ToDto(request);
        await ingredientFacade.UpdateAsync(int.Parse(ingredientId), dto);
        return NoContent();
    }
}
