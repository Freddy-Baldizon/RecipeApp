using RecipeApp.Api.Models.Requests;
using RecipeApp.Api.Models.Responses;
using RecipeApp.Dto;

namespace RecipeApp.Api.Mappers
{
    public class CommentMapper
    {
        public static CommentDto ToDto(CreateCommentRequestModel commentRequest)
        {
            return new CommentDto
            {
                UserId = commentRequest.UserId,
                RecipeId = commentRequest.RecipeId,
                Title = commentRequest.Title,
                Description = commentRequest.Description,
                
            };
        }

        public static List<CommentResponseModel> ToModel(List<CommentDto> commentDto)
        {
            return commentDto.Select(c => ToModel(c)).ToList();
        }

        public static CommentResponseModel ToModel(CommentDto commentDto)
        {
            return new CommentResponseModel
            {

                Id = commentDto.Id,
                UserId = commentDto.UserId,
                Username = commentDto.Username,
                RecipeId = commentDto.RecipeId,
                Title = commentDto.Title,
                Description = commentDto.Description,
            };
        }
    }
}