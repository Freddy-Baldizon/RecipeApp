using RecipeApp.Domain.Entities;
using RecipeApp.DomainService.Interfaces;
using RecipeApp.Dto;
using RecipeApp.Exceptions;
using RecipeApp.Infrastructure.Repositories.Interfaces;

namespace RecipeApp.DomainService.Classes;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<User> AddAsync(UserDto userDto)
    {
        var newUser = new User
        {
            Email = userDto.Email!,
            Username = userDto.Username!,
            Password = userDto.Password,
            Avatar = userDto.Avatar,
        };
        return _userRepository.AddAsync(newUser);
    }

    public Task<List<User>> GetAllAsync()
    {
        return _userRepository.GetAllAsync();
    }

    public Task<User?> GetByEmailAsync(string email)
    {
        return _userRepository.FindUserByEmailAsync(email);
    }

    public Task<User?> GetByUsername(string username)
    {
        return _userRepository.GetByUsername(username);
    }

    public Task<User?> GetByIdAsync(int id)
    {
        return _userRepository.GetByIdAsync(id);
    }

    public async Task<User> UpdateAsync(int id, UpdateUserDto updateDto)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null)
            throw new ResourceNotFoundException($"User with ID {id} not found.");

        if (!string.IsNullOrEmpty(updateDto.Username)) user.Username = updateDto.Username;
        if (!string.IsNullOrEmpty(updateDto.Avatar)) user.Avatar = updateDto.Avatar;
        if (!string.IsNullOrEmpty(updateDto.Password)) user.Password = updateDto.Password;

        return await _userRepository.UpdateAsync(user);
    }
    public async Task DeleteAsync(int userId)
    {
        User? user = await _userRepository.GetByIdAsync(userId);
        if (user == null)
        {
            throw new ResourceNotFoundException("User not found by the id: " + userId);
        }
        await _userRepository.DeleteAsync(user);
    }
}