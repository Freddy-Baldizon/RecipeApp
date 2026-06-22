using RecipeApp.Domain.Entities;
using RecipeApp.Exceptions;
using RecipeApp.Dto;
using RecipeApp.Infrastructure.Repositories.Interfaces;
using RecipeApp.DomainService.Interfaces;

namespace RecipeApp.DomainService.Classes;

public class FavoriteService : IFavoriteService
{
    private readonly IFavoriteRepository _favoriteRepository;

    public FavoriteService(IFavoriteRepository favoriteRepository)
    {
        _favoriteRepository = favoriteRepository;
    }

    public async Task<Favorite> AddAsync(FavoriteDto favoriteDto)
    {
        var existing = await _favoriteRepository.GetFavoriteAsync(favoriteDto.UserId, favoriteDto.RecipeId);
        if (existing != null)
        {
            throw new DuplicateResourceException($"Recipe {favoriteDto.RecipeId} is already in favorites for user {favoriteDto.UserId}.");
        }

        var favorite = new Favorite
        {
            RecipeId = favoriteDto.RecipeId,
            UserId = favoriteDto.UserId
        };
        return await _favoriteRepository.AddAsync(favorite);
    }

    public async Task<List<Favorite>> GetAllByUserIdAsync(int userId)
    {
        return await _favoriteRepository.GetByUserAsync(userId);
    }

    public async Task DeleteAsync(int userId, int recipeId)
    {
        var favorite = await _favoriteRepository.GetFavoriteAsync(userId, recipeId);
        if (favorite == null)
        {
            throw new ResourceNotFoundException($"Favorite for user {userId} and recipe {recipeId} not found.");
        }
        await _favoriteRepository.DeleteAsync(favorite);
    }
}