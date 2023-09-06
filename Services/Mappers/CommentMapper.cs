using Humanizer;
using WebWizards.Data.Entities;
using WebWizards.Services.ServiceObjects.Comments;

namespace WebWizards.Services.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToDto(this Comment entity)
        {
            if (entity is null)
            {
                return null;
            }
            if(entity.Likes is null)
            {
                entity.Likes = new List<Like>();
            }
            return new CommentDto
            {
                Id = entity.Id,
                Text = entity.Text,
                PostId = entity.PostId,
                UserId = entity.UserId,
                CreatedAt = entity.CreatedAt,
                Likes = entity.Likes.Select(l => l.ToDto()).ToList()
            };
        }
        public static Comment ToEntity(this CommentDto dto)
        {

            if (dto is null)
            {
                return null;
            }

            return new Comment
            {
                Id = dto.Id,
                Text = dto.Text,
                PostId = dto.PostId,
                UserId = dto.UserId,
                CreatedAt = dto.CreatedAt,
                Likes = dto.Likes.Select(l => l.ToEntity()).ToList()
            };
        }
    }
}
