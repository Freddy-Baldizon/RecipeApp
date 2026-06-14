using RecipeApp.Domain.Entities;
using RecipeApp.Infrastructure.Repositories;
using RecipeApp.Exceptions;
using RecipeApp.Dto;

namespace RecipeApp.DomainService;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

  public Task<Comment> AddAsync(CommentDto commentDto)
    {
        var comment = new Comment
        {
            UserId = commentDto.UserId,
            RecipeId = commentDto.RecipeId,
            Title = commentDto.Title,
            Description = commentDto.Description
        };

        return _commentRepository.AddAsync(comment);
    }

    public async Task<Comment> GetByIdAsync(int commentId)
    {
        var comment = await _commentRepository.GetByIdAsync(commentId);
        if (comment == null)
        {
            throw new ResourceNotFoundException($"Comment with ID {commentId} not found.");
        }
        return comment;
    }

    public async Task<List<Comment>> GetAllByRecipeIdAsync(int recipeId)
    {
        return await _commentRepository.GetAllByRecipeIdAsync(recipeId);
    }

    public async Task DeleteAsync(int commentId)
    {
        var comment = await _commentRepository.GetByIdAsync(commentId);
        if (comment == null)
        {
            throw new ResourceNotFoundException($"Comment with ID {commentId} not found.");
        }
        await _commentRepository.DeleteAsync(comment);
    }
}