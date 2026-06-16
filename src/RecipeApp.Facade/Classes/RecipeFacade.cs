using RecipeApp.DomainService;
using RecipeApp.DomainService.Interfaces;
using RecipeApp.Dto;
using RecipeApp.Exceptions;
using RecipeApp.Facade.Interfaces;
using RecipeApp.Facade.Mappers;
using RecipeApp.Infrastructure;

namespace RecipeApp.Facade.Classes;

public class RecipeFacade : IRecipeFacade
{
    private readonly IRecipeService recipeService;
    
    public RecipeFacade(IRecipeService recipeService)
    {
        this.recipeService = recipeService;
    }
    public async Task<RecipeDto> AddAsync(CreateRecipeDto recipeDto)
    {
        var recipe = await recipeService.AddAsync(recipeDto);
        return RecipeMapper.ToDto(recipe);
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
        if (comment == null) throw new ResourceNotFoundException();
        return CommentMapper.ToDto(comment);
    }
    public async Task<CommentDto> UpdateAsync(CommentDto commentDto)
    {
        var updatedComment = await commentService.UpdateAsync(commentDto);
        return CommentMapper.ToDto(updatedComment);
    }

    
}