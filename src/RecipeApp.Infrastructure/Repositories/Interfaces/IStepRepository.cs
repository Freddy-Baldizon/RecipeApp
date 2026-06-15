using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Repositories.Interfaces
{
    public interface IStepRepository
    {
        Task<List<Step>> GetAllAsync();
        Task<Step> AddAsync(Step step);
        Task<Step> UpdateAsync(Step step);
        Task DeleteAsync(Step step);
    }
}