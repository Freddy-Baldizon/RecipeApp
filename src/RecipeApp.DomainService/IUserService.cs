using RecipeApp.Domain.Entities;

namespace RecipeApp.DomainService;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User> AddAsync(User user);
    Task<User?> GetByIdAsync(int id);
    Task<User?> FindUserByEmailAsync(String email);
    Task<User?> GetByUsername(String username);
    Task DeleteAsync(User user);
}