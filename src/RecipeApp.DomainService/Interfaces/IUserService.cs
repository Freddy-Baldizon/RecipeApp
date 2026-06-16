using RecipeApp.Domain.Entities;
using RecipeApp.Dto;

namespace RecipeApp.DomainService.Interfaces;

public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User> AddAsync(UserDto userDto);
    Task<User?> GetByIdAsync(int id);
    Task<User?> GetByEmailAsync(String email);
    Task<User?> GetByUsername(String username);
     Task<User> UpdateAsync(int id, UpdateUserDto updateDto);
    Task DeleteAsync(int userId);
}