using Microsoft.AspNetCore.Mvc;
using RecipeApp.Api.Mappers;
using RecipeApp.Api.Models.Requests;
using RecipeApp.Dto;
using RecipeApp.Facade.Interfaces;

namespace RecipeApp.Api.Controllers;

[ApiController]
[Route("/api/comment")]
public class CommentController : ControllerBase
{
    private readonly ICommentFacade commentFacade;

    public CommentController(ICommentFacade commentFacade)
    {
        this.commentFacade = commentFacade;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCommentAsync([FromBody] CreateCommentRequestModel request)
    {
        var requestDto = CommentMapper.ToDto(request);
        var commentDto = await commentFacade.AddAsync(requestDto);
        return Created(string.Empty, CommentMapper.ToModel(commentDto));
    }

    [HttpGet("/{commentId}")]
    public async Task<IActionResult> GetByIdAsync(string commentId)
    {
        var commentDto = await commentFacade.GetByIdAsync(int.Parse(commentId));
        if (commentDto == null)
        {
            return NotFound("Comment not found");
        }

        return Ok(CommentMapper.ToModel(commentDto));
    }

    [HttpGet("/recipe/{recipeId}")]
    public async Task<IActionResult> GetAllByRecipeId(string recipeId)
    {
        var comments = await commentFacade.GetAllByRecipeIdAsync(int.Parse(recipeId));
        return Ok(CommentMapper.ToModel(comments));
    }

    [HttpPut("/{commentId}")]
    public async Task<IActionResult> UpdateComment(string commentId, [FromBody] CreateCommentRequestModel request)
    {
        var requestDto = CommentMapper.ToDto(request);
        requestDto.Id = int.Parse(commentId);
        var updatedComment = await commentFacade.UpdateAsync(requestDto);
        return Ok(CommentMapper.ToModel(updatedComment));
    }

    [HttpDelete("/{commentId}")]
    public async Task<IActionResult> DeleteComment(string commentId)
    {
        await commentFacade.DeleteAsync(int.Parse(commentId));
        return NoContent();
    }
}
