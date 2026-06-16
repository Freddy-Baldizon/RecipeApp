using RecipeApp.DomainService.Interfaces;
using RecipeApp.Dto;
using RecipeApp.Facade.Interfaces;
using RecipeApp.Facade.Mappers;

namespace RecipeApp.Facade.Classes;

public class FavoriteFacade : IFavoriteFacade
{
    private readonly IFavoriteService favoriteService;

    public FavoriteFacade(IFavoriteService favoriteService)
    {
        this.favoriteService = favoriteService;
    }

    public async Task<FavoriteDto> AddAsync(FavoriteDto favoriteDto)
    {
        var favorite = await favoriteService.AddAsync(favoriteDto);
        return FavoriteMapper.ToDto(favorite);
    }

    public async Task DeleteAsync(int favoriteId)
    {
        await favoriteService.DeleteAsync(favoriteId);
    }

    public async Task<List<FavoriteDto>> GetAllByRecipeIdAsync(int recipeId)
    {
        var favorites = await favoriteService.GetAllByRecipeIdAsync(recipeId);
        return FavoriteMapper.ToDto(favorites);
    }
}