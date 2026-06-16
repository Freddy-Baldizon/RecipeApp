using RecipeApp.DomainService.Interfaces;
using RecipeApp.Dto;
using RecipeApp.Exceptions;
using RecipeApp.Facade.Interfaces;
using RecipeApp.Facade.Mappers;
namespace RecipeApp.Facade;

public class CommentFacade : ICommentFacade
{
    private readonly ICommentService commentService;
    
    public CommentFacade(ICommentService commentService)
    {
        this.commentService = commentService;
    }
    public async Task<CommentDto> AddAsync(CommentDto commentDto)
    {
        var comment = await commentService.AddAsync(commentDto);
        return CommentMapper.ToDto(comment);
    }

    public async Task DeleteAsync(int commentId)
    {
        await commentService.DeleteAsync(commentId);
    }

    public async Task<List<CommentDto>> GetAllByRecipeIdAsync(int recipeId)
    {
        var comments = await commentService.GetAllByRecipeIdAsync(recipeId);
        return CommentMapper.ToDto(comments);
    }

    public async Task<CommentDto> GetByIdAsync(int commentId)
    {
        var comment = await commentService.GetByIdAsync(commentId);
        return CommentMapper.ToDto(comment);
    }
    public async Task<CommentDto> UpdateAsync(CommentDto commentDto)
    {
        var updatedComment = await commentService.UpdateAsync(commentDto);
        return CommentMapper.ToDto(updatedComment);
    }

    
}