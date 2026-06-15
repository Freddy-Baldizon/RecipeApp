using RecipeApp.DomainService.Interfaces;
using RecipeApp.Dto;
using RecipeApp.Exceptions;
using RecipeApp.Facade.Interfaces;
using RecipeApp.Facade.Mappers;
using RecipeApp.Infrastructure;

namespace StoreBackend.Facade;

public class CommentFacade : ICommentFacade
{
    private readonly ICommentService commentService;

    private readonly AppDbContext context;  

    public CommentFacade(ICommentService commentService)
    {
        this.commentService = commentService;
    }

    public async Task<CommentDto> AddAsync(CommentDto commentDto)
    {
        var comment = await commentService.AddAsync(commentDto);
        await context.SaveChangesAsync();
        return CommentMapper.ToDto(comment);
    }

    public async Task DeleteAsync(int commentId)
    {
        await commentService.DeleteAsync(commentId);
        await context.SaveChangesAsync();
    }

    public async Task<List<CommentDto>> GetAllAsync()
    {
        var comments = await commentService.GetAllAsync();
        return CommentMapper.ToDto(comments);
    }

    public async Task<CommentDto> GetByIdAsync(int commentId)
    {
        var comment = await commentService.GetByIdAsync(commentId);
        if (comment == null) throw new ResourceNotFoundException();
        return CommentMapper.ToDto(comment);
    }

    public Task UpdateAsync(int id, CommentDto commentDto)
    {
        
    }
}

