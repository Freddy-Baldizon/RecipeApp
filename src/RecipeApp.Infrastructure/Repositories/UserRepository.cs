using Microsoft.EntityFrameworkCore;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _dbContext;

    public UserRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _dbContext.User.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _dbContext.User.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> AddAsync(User user)
    {
        await _dbContext.User.AddAsync(user);
        return user;
    }

    public async Task DeleteAsync(User user)
    {
        _dbContext.User.Remove(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<User?> FindUserByUsernameAsync(string username)
    {
        return await _dbContext.User
            .FirstAsync(u => u.Username == username);
    }

    public async Task<User?> FindUserByEmailAsync(string email)
    {
        return await _dbContext.User
            .FirstAsync(u => u.Email == email);
    }

    public async Task<User?> GetByUsername(string username)
    {
        return await _dbContext.User
            .Include(u => u.Recipes)
            .FirstOrDefaultAsync(u => u.Username == username);
    }
}