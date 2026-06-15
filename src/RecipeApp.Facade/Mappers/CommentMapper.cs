using RecipeApp.Dto;
namespace RecipeApp.Facade.Mappers
{
    public class CommentMapper
    {
        public static List<CommentDto> ToDto(List<CommentDto> comments)
        {
            return comments.Select(p => ToDto(p)).ToList();
        }
        public static CommentDto ToDto(CommentDto comment)
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