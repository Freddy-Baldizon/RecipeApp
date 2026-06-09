using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RecipeApp.Domain.Entities;

namespace RecipeApp.Infrastructure.Repositories
{
    public interface IStepRepository
    {
        Task<List<Step>> GetAllAsync();
        Task<Step> AddAsync(Step step);

        Task DeleteAsync(Step step);
    }
}