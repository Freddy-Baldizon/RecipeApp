using System;
using Microsoft.AspNetCore.Mvc;
using RecipeApp.Api.Mappers;
using RecipeApp.Api.Models.Requests;
using RecipeApp.Dto;
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

    [HttpPost]
    public async Task<IActionResult> CreateFavoriteAsync([FromBody] CreateFavoriteRequestModel request)
    {
        var dto = FavoriteMapper.ToDto(request);


        var createdFavorite = await favoriteFacade.AddAsync(dto);
        return Created(string.Empty, createdFavorite);
    }

    [HttpGet("recipe/{userId}")]
    public async Task<IActionResult> GetAllByUserId(string userId)
    {
        var favorites = await favoriteFacade.GetAllByUserIdAsync(int.Parse(userId));
        return Ok(favorites);
    }

    [HttpDelete("{favoriteId}")]
    public async Task<IActionResult> DeleteFavorite(string favoriteId)
    {
        await favoriteFacade.DeleteAsync(int.Parse(favoriteId));
        return NoContent();
    }
}
