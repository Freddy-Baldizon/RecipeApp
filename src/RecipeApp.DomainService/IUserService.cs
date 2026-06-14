using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.DomainService;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User> AddAsync(CreateUserDto userDto);
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByEmailAsync(String email);
    Task<User?> GetByUsername(String username);
    Task DeleteAsync(int userId);
}