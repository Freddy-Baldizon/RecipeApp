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

        public async Task<List<RecipeFavorite>> GetByUserAsync(int userId)
    {
        // return await _dbContext.RecipeFavorite
        //     // .Include(f => f.Recipe)
        //     //     .ThenInclude(r => r.Country)
        //     // .Include(f => f.Recipe)
        //     //     .ThenInclude(r => r.User)
        //     //.Where(f => f.UserId == userId)
        //     .ToListAsync<RecipeFavorite>();
    }

    public async Task DeleteAsync(RecipeFavorite RecipeFavorite)
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