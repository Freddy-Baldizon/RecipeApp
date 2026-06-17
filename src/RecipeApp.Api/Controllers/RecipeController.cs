using Microsoft.AspNetCore.Mvc;
using RecipeApp.Api.Mappers;
using RecipeApp.Api.Models.Requests;
using RecipeApp.Facade.Interfaces;

namespace RecipeApp.Api.Controllers;

[ApiController]
[Route("/api/recipe")]
public class RecipeController(IRecipeFacade recipeFacade) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRecipeAsync([FromBody] CreateRecipeRequestModel createRecipe)
    {
        var dto = RecipeMapper.ToDto(createRecipe);
        var recipeDto = await recipeFacade.AddAsync(dto);
        var recipeModel = RecipeMapper.ToModel(recipeDto);
        return Created("", recipeModel);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        var allRecipes = await recipeFacade.GetAllAsync();
        var allRecipesModel = RecipeMapper.ToModel(allRecipes);
        return Ok(allRecipesModel);
    }
    [HttpGet("{recipeName}")]
    public async Task<IActionResult> GetByName(string recipeName)
    {
        var recipe = await recipeFacade.GetByRecipeNameAsync(recipeName);
        if (recipe == null)
        {
            return NotFound("Recipe not found");
        }
        var recipeModel = RecipeMapper.ToModel(recipe);
        return Ok(recipeModel);
    }


    [HttpGet("{recipeId}")]
    public async Task<IActionResult> GetById(string recipeId)
    {
        var recipe = await recipeFacade.GetByIdAsync(int.Parse(recipeId));
        if (recipe == null)
        {
            return NotFound("Recipe not found");
        }
        var recipeModel = RecipeMapper.ToModel(recipe);
        return Ok(recipeModel);
    }

    [HttpPut("{recipeId}")]
    public async Task<IActionResult> UpdateRecipe(string recipeId, [FromBody] UpdateRecipeRequestModel model)
    {
        var requestDto = RecipeMapper.ToDto(model);
        var updatedRecipe = await recipeFacade.UpdateAsync(int.Parse(recipeId), requestDto);
        var responseModel = RecipeMapper.ToModel(updatedRecipe);
        return Ok(responseModel);
    }

    [HttpDelete("{recipeId}")]
    public async Task<IActionResult> DeleteRecipe(string recipeId)
    {
        await recipeFacade.DeleteAsync(int.Parse(recipeId));
        return Ok();
    }
}