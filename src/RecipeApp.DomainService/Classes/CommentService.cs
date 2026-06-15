using RecipeApp.Domain.Entities;
using RecipeApp.Exceptions;
using RecipeApp.Dto;
using RecipeApp.Infrastructure.Repositories.Interfaces;
using RecipeApp.DomainService.Interfaces;

namespace RecipeApp.DomainService.Classes;

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
            Username = commentDto.Username,
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

    public async Task DeleteAsync(int commentId)
    {
        var comment = await _commentRepository.GetByIdAsync(commentId);
        if (comment == null)
        {
            throw new ResourceNotFoundException($"Comment with ID {commentId} not found.");
        }
        await _commentRepository.DeleteAsync(comment);
    }

    public async Task<Comment> UpdateAsync(CommentDto commentDto)
    {
        var comment = await _commentRepository.GetByIdAsync(commentDto.Id);
        if (comment == null)
            throw new ResourceNotFoundException($"Comment with ID {commentDto.Id} not found.");

        comment.Title = commentDto.Title;
        comment.Description = commentDto.Description;

        return await _commentRepository.UpdateAsync(comment);
    }

    public Task<List<Comment>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}