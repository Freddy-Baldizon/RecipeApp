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

    public async Task<FavoriteDto> AddAsync(FavoriteDto requestDto)
    {
        var favorite = await favoriteService.AddAsync(requestDto);
        return FavoriteMapper.ToDto(favorite);
    }

    public async Task DeleteAsync(int favoriteId)
    {
        await favoriteService.DeleteAsync(favoriteId);
    }

    public async Task<List<FavoriteDto>> GetAllByUserIdAsync(int userId)
    {
        var favorites = await favoriteService.GetAllByUserIdAsync(userId);
        return FavoriteMapper.ToDto(favorites);
    }
}