using system;
using recipeapp.domain.entities;

namespace recipeapp.infrastructure.repositories
{

  public class IngredientRepository : IIngredientRepository
    {
        private readonly RecipeAppDbContext _dbContext;

        public IngredientRepository(RecipeAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

 public async Task<Favorite?> GetByIdAsync(Guid FavoriteId)
    {
        return await _dbContext.Favorites.FindAsync(FavoriteId);
    }

    public async Task DeleteAsync(Guid FavoriteId)
    {
    
        await _dbContext.Favorites.Remove(favorite);
        await _dbContext.SaveChangesAsync();

    }

    public async Task AddAsync(Favorite favorite)
    {
        await _dbContext.Favorites.AddAsync(favorite);
        await _dbContext.SaveChangesAsync();
    }
}
}