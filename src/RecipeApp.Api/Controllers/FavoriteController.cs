using Microsoft.AspNetCore.Mvc;
using RecipeApp.Api.Mappers;
using RecipeApp.Api.Models.Requests;
using RecipeApp.Facade.Interfaces;

namespace RecipeApp.Api.Controllers;

[ApiController]
[Route("/api/favorite")]
public class FavoriteController : ControllerBase
{
    private readonly IFavoriteFacade favoriteFacade;

    public FavoriteController(IFavoriteFacade favoriteFacade)
    {
        this.favoriteFacade = favoriteFacade;
    }

    // POST /api/favorite  — body: { userId, recipeId }
    [HttpPost]
    public async Task<IActionResult> CreateFavoriteAsync([FromBody] CreateFavoriteRequestModel request)
    {
        var dto = FavoriteMapper.ToDto(request);
        var createdFavorite = await favoriteFacade.AddAsync(dto);
        return Created(string.Empty, createdFavorite);
    }

    // GET /api/favorite/user/{userId}
    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetAllByUserId(int userId)
    {
        var favorites = await favoriteFacade.GetAllByUserIdAsync(userId);
        var favoritesModel = FavoriteMapper.ToModel(favorites);
        return Ok(favoritesModel);
    }

    // DELETE /api/favorite/{userId}/{recipeId}
    [HttpDelete("{userId}/{recipeId}")]
    public async Task<IActionResult> DeleteFavorite(int userId, int recipeId)
    {
        await favoriteFacade.DeleteAsync(userId, recipeId);
        return NoContent();
    }
}