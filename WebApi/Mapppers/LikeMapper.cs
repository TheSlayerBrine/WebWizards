using WebWizards.Services.ServiceObjects.Likes;
using WebWizards.WebApi.Models;

namespace WebWizards.WebApi.Mapppers
{
    public static class LikeMapper
    {
        public static LikeDto ToDto(this LikeModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new LikeDto
            {
                Id = model.Id,
                UserId = model.UserId,
                CommentId = model.CommentId,
                PostId = model.PostId,
            };
        }
        public static LikeModel ToApiModel(this LikeDto dto)
        {
            if (dto == null)
            {
                return null;
            }
            return new LikeModel
            {
                Id = dto.Id,
                UserId = dto.UserId,
                CommentId = dto.CommentId,
                PostId = dto.PostId,    
            };
        }
    }
}
