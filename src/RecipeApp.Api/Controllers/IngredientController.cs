using Microsoft.AspNetCore.Mvc;
using RecipeApp.Api.Mappers;
using RecipeApp.Facade.Interfaces;

namespace RecipeApp.Api.Controllers;

[ApiController]
[Route("/api/ingredient")]
public class ingredientController(IIngredientFacade ingredientFacade) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> createIngredientAsync([FromBody] CreateIngredientRequest request)
    {
        throw new NotImplementedException();
    }

    [HttpGet("/{ingredientId}")]
    public async Task<IActionResult> GetByIdAsync(string ingredientId)
    {
        var ingredientDto = await ingredientFacade.GetByIdAsync(int.Parse(ingredientId));
        if(ingredientDto == null)
        {
            return NotFound("Ingredient not found");
        }
        var ingredientModel = IngredientMapper.ToModel(ingredientDto);
        return Ok(ingredientModel);
    }

    [HttpGet("/recipe/{recipeId}")]
    public async Task<IActionResult> GetAllByRecipeId(string recipeId)
    {
        var ingredientsDto = await ingredientFacade.GetAllByRecipeIdAsync(int.Parse(recipeId));
        if(ingredientsDto == null)
        {
            return NotFound("Recipe not found");
        }
        var ingredientsModel = IngredientMapper.ToModel(ingredientsDto);

        return Ok(ingredientsModel);
    }

    [HttpDelete("/{ingredientId}")]
    public async Task<IActionResult> DeleteIngredient(string ingredientId)
    {
        await ingredientFacade.DeleteAsync(int.Parse(ingredientId));
        return Ok();
    }

    [HttpPut("/{ingredientId}")]
    public async Task<IActionResult> UpdateIngredient(string ingredientId)
    {
        // var requestDto = IngredientMapper
        throw new NotImplementedException();
    }
}