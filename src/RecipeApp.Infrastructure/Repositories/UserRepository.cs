using Microsoft.EntityFrameworkCore;
using ProyectoSW4.Domain.Entities;

namespace RecipeApp.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.User.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        //DTO
        //Revisar si ocupamos los include del id del usuario si retorna esos atributos
        return await _context.User
            // .Include(u => u.Recipes)
            // .Include(u => u.Comments)
            // .Include(u => u.Ratings)
            // .Include(u => u.RecipeFavorites)
             .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User> AddAsync(User user)
    {
        await _context.User.AddAsync(user);
        return user;
    }

    public async Task DeleteAsync(User user)
    {
        _context.User.Remove(user);
        await Task.CompletedTask;
    }

    public async Task<bool> FindUserByUsernameAsync(string username)
    {
        return await _context.User
            .AnyAsync(u => u.Username == username);
    }

    public async Task<bool> FindUserByEmailAsync(string email)
    {
        return await _context.User
            .AnyAsync(u => u.Email == email);
    }

    public async Task<User?> GetByUsername(string username)
    {
        return await _context.User
            .Include(u => u.Recipes)
            .FirstOrDefaultAsync(u => u.Username == username);
    }
}