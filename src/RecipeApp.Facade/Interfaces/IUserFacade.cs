using RecipeApp.Dto;

namespace RecipeApp.Facade.Interfaces
{
    public interface IUserFacade
    {
        Task<List<UserDto>> GetAllAsync();
        Task<UserDto> AddAsync(CreateUserDto userDto);
        Task<UserDto?> GetByIdAsync(int id);
        Task<UserDto?> GetByEmailAsync(String email);
        Task<UserDto?> GetByUsername(String username);
        Task DeleteAsync(int userId);

        Task<UserDto> UpdateAsync(int id, UpdateUserDto userDto);
    }
}