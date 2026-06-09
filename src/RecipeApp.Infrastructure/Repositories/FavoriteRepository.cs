using RecipeApp.Domain.Entities;
namespace RecipeApp.Infrastructure.Repositories
{

  public class FavoriteRepository :  IFavoriteRepository
    {
        private readonly AppDbContext _dbContext;

        public FavoriteRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

 public async Task<RecipeFavorite> GetByIdAsync(int FavoriteId)
    {
        return await _dbContext.RecipeFavorite.FindAsync(FavoriteId);
    }

    public async Task DeleteAsync(int FavoriteId, RecipeFavorite RecipeFavorite)
    {
    
        _dbContext.RecipeFavorite.Remove(RecipeFavorite);
        await _dbContext.SaveChangesAsync(); 

    }

    public async Task<RecipeFavorite> AddAsync(RecipeFavorite favorite)
    {
        await _dbContext.RecipeFavorite.AddAsync(favorite);
        await _dbContext.SaveChangesAsync();
        return favorite;
    }

    }
}