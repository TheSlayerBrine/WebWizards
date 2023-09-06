using WebWizards.Services.ServiceObjects.Auth;
using WebWizards.Services.ServiceObjects.Comments;
using WebWizards.WebApi.Models;
using WebWizards.WebApi.Models.Auth;

namespace WebWizards.WebApi.Mapppers
{
    public static class CommentMapper
    {
        public static CommentModel ToApiModel(this CommentDto dto)
        {
            if (dto is null)
            {
                return null;
            }

            return new CommentModel
            {
                Id = dto.Id,
                Text = dto.Text,
                CreatedAt = dto.CreatedAt,
              UserId = dto.UserId,
              PostId = dto.PostId,
                Likes = dto.Likes.Select(l => l.ToApiModel()).ToList(),
            };
        }
        public static CommentDto ToDto(this CommentModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new CommentDto
            {
                Id = model.Id,
                Text = model.Text,
                CreatedAt = model.CreatedAt,
                PostId = model.PostId,
                UserId = model.UserId,
                Likes = model.Likes.Select(l => l.ToDto()).ToList()
            };
        }
    }
}
