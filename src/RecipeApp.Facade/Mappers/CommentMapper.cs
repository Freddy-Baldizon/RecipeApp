using RecipeApp.Domain.Entities;
using RecipeApp.Dto;
namespace RecipeApp.Facade.Mappers
{
    public class CommentMapper
    {
        public static List<CommentDto> ToDto(List<Comment> comments)
        {
            return comments.Select(p => ToDto(p)).ToList();
        }
        public static CommentDto ToDto(Comment comment)
        {
            return new CommentDto
            {
                Id          = comment.Id,
                UserId      = comment.UserId,
                Username    = comment.Username,
                RecipeId    = comment.RecipeId,
                Title       = comment.Title,
                Description = comment.Description
            };
        }
    }
}