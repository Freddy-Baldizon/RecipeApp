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

    public Task<Favorite> AddAsync(FavoriteDto favoriteDto)
    {
        var favorite = new Favorite
        {
            RecipeId = favoriteDto.RecipeId,
            UserId = favoriteDto.UserId,
            CreatedAt = favoriteDto.CreatedAt
        };
        return _favoriteRepository.AddAsync(favorite);
    }

    public async Task DeleteAsync(int recipeId)
    {
        var favorite = await _favoriteRepository.GetFavoriteByIdAsync(recipeId);
        if (favorite == null)
        {
            throw new ResourceNotFoundException($"Comment with ID {recipeId} not found.");
        }
        await _favoriteRepository.DeleteAsync(favorite);
    }

    public Task<List<Favorite>> GetAllByRecipeIdAsync(int recipeId)
    {
        return _favoriteRepository.GetByUserAsync(recipeId);
    }

    public Task<Favorite?> GetByRecipeIdAsync(int recipeId)
    {
        var favorite = _favoriteRepository.GetFavoriteByIdAsync(recipeId);
        if (favorite == null)
        {
            throw new ResourceNotFoundException($"Comment with ID {recipeId} not found.");
        }
        return favorite;
    }
}   