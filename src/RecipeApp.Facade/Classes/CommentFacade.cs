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
        var NewComment = await commentService.AddAsync(commentDto);
        await context.SaveChangesAsync();
        return CommentMapper.ToDto(NewComment);
    }

    public Task DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<CommentDto>> GetAllByRecipeIdAsync(int recipeId)
    {
        throw new NotImplementedException();
    }

    public Task<CommentDto> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(int id, CommentDto commentDto)
    {
        throw new NotImplementedException();
    }
}

