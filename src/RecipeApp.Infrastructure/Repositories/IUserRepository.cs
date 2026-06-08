using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoSW4.Domain.Entities;


namespace RecipeApp.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
        Task<User> AddAsync(User user);
        Task<User?> GetByIdAsync(Guid ExternalId);

        Task<bool> HasUserByUsernameAsync(string UserName);

        Task<bool> HasUserByEmailAsync(string Email);
        Task<User?> GetByUsername(string username);

        Task DeleteAsync(User user);
    }
}