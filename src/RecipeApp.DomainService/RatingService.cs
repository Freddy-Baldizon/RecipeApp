using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Repositories;
using RecipeApp.Exceptions;
using RecipeApp.Dto;

namespace RecipeApp.DomainService;

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
        throw new NotImplementedException();
    }

    public Task<List<Rating>> GetRatingByUserId(int userId)
    {
        throw new NotImplementedException();
    }
}