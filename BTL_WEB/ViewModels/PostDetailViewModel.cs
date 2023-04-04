using BTL_WEB.Models;

namespace BTL_WEB.ViewModels
{
	public class PostDetailViewModel
	{
		public Post post {  get; set; }
		public List<Medium> listmedia { get; set; }

		public int liked { get; set; }

		public int mountlike { get; set; }
	}
}
