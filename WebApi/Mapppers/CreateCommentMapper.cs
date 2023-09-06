using WebWizards.Services.ServiceObjects.Comments;
using WebWizards.WebApi.Models;

namespace WebWizards.WebApi.Mapppers
{
    public static class CreateCommentMapper
    {
        public static CreateCommentDto ToDto ( this  CreateCommentModel model)
        {
            if(model == null)
            {
                return null;
            }
            return new CreateCommentDto
            {
                Text = model.Text,
            };
        }
    }
}
