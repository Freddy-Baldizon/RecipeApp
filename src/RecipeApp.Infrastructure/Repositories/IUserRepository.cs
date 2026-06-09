using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();

    Task<User> AddAsync(User user);

    Task<User?> GetByIdAsync(int id);

    Task<bool> FindUserByUsernameAsync(string username);

    Task<bool> FindUserByEmailAsync(string email);

    Task<User?> GetByUsername(string username);

    Task DeleteAsync(User user);
}