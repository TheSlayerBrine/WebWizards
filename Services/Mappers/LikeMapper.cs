using WebWizards.Data.Entities;
using WebWizards.Services.ServiceObjects.Likes;

namespace WebWizards.Services.Mappers
{
    public static class LikeMapper
    {
        public static LikeDto ToDto(this Like entity)
        {
            if (entity is null)
            {
                return null;
            }
            return new LikeDto
            {
                Id = entity.Id,
                CommentId = entity.CommentId,
                PostId = entity.PostId,
                UserId = entity.UserId,
            };
        }
        public  static Like ToEntity(this LikeDto dto)
        {
            if(dto is null)
            {
                return null;
            }
            return new Like
            {
                Id = dto.Id,
                CommentId = dto.CommentId,
                PostId = dto.PostId,
                UserId = dto.UserId,
            };
        }
    }
}
