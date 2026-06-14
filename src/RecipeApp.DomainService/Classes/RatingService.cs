using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Repositories.Interfaces;
using RecipeApp.Exceptions;
using RecipeApp.Dto;
using RecipeApp.DomainService.Interfaces;

namespace RecipeApp.DomainService.Classes;

public class RatingService : IRatingService
{
    private readonly IRatingRepository _ratingRepository;

    public RatingService(IRatingRepository ratingRepository)
    {
        _ratingRepository = ratingRepository;
    }

    public async Task<Rating> AddAsync(RatingDto rating)
    {
        var ratingEntity = new Rating
        {
            UserId = rating.UserId,
            RecipeId = rating.RecipeId,
            Value = rating.Value
        };
        return await _ratingRepository.AddAsync(ratingEntity);
    }

    public async Task DeleteAsync(RatingDto rating)
    {
        var ratingEntity = await _ratingRepository.GetByIdAsync(rating.Id);
        if (ratingEntity == null)
        {
            throw new ResourceNotFoundException($"Rating with ID {rating.Id} not found.");
        }

        await _ratingRepository.DeleteAsync(ratingEntity);
    }

    public async Task<Rating> GetByIdAsync(int id)
    {
        var rating = await _ratingRepository.GetByIdAsync(id);
        if (rating == null)
        {
            throw new ResourceNotFoundException($"Rating with ID {id} not found.");
        }
        return rating;
    }

    public Task<List<Rating>> GetRatingByRecipeId(int recipeId)
    {
        return _ratingRepository.GetRatingByRecipeId(recipeId);
    }

    public async Task<Rating> UpdateAsync(RatingDto rating)
    {
        var existing = await _ratingRepository.GetByIdAsync(rating.Id);
        if (existing == null)
            throw new ResourceNotFoundException($"Rating with ID {rating.Id} not found.");

        existing.Value = rating.Value;
        existing.UserId = rating.UserId;
        existing.RecipeId = rating.RecipeId;

        return await _ratingRepository.UpdateAsync(existing);
    }

    public Task<List<Rating>> GetRatingByUserId(int userId)
    {
        return _ratingRepository.GetRatingByUserId(userId);
    }
}