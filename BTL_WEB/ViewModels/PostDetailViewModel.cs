using BTL_WEB.Models;
using Microsoft.EntityFrameworkCore;

namespace BTL_WEB.ViewModels
{
	public class PostDetailViewModel
	{
        SocialMediaContext db = new SocialMediaContext();
        public Post post {  get; set; }

		public User userPost { get; set; }

		public List<Medium> listmedia { get; set; }

		public int liked { get; set; }

		public int mountlike { get; set; }

		public List<Comment> listcmt { get; set; }

        public User GetCommentUser(Comment comment)
        {
            return db.Users.Single(x => x.Id == comment.UserId);
        }
    }
}
