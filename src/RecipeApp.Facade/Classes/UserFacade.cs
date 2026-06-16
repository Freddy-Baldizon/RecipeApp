using RecipeApp.DomainService.Interfaces;
using RecipeApp.Dto;
using RecipeApp.Exceptions;
using RecipeApp.Facade.Interfaces;
using RecipeApp.Facade.Mappers;
namespace RecipeApp.Facade;

public class UserFacade : IUserFacade
{
    private readonly IUserService userService;

        public UserFacade(IUserService userService)
        {
            this.userService = userService;
        }
    public async Task<UserDto> AddAsync(UserDto userDto)
    {
        var user = await userService.AddAsync(userDto);
        return UserMapper.ToDto(user);   
    }

    public async Task DeleteAsync(int userId)
    {
        await userService.DeleteAsync(userId);
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var user = await userService.GetAllAsync();
        return UserMapper.ToDto(user);   
    }

    public async Task<UserDto?> GetByEmailAsync(string email)
    {
        var user = await userService.GetByEmailAsync(email);
        return UserMapper.ToDto(user);  
    }

    public async Task<UserDto?> GetByIdAsync(int id)
    {
        var user = await userService.GetByIdAsync(id);
        return UserMapper.ToDto(user);    }

    public async Task<UserDto?> GetByUsername(string username)
    {
        var user = await userService.GetByUsername(username);
        return UserMapper.ToDto(user);  
    }

    public async Task<UserDto> UpdateAsync(int id, UpdateUserDto userDto)
    {
        var user = await userService.UpdateAsync(id, userDto);
        return UserMapper.ToDto(user);
    }
}