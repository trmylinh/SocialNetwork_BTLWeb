namespace BTL_WEB.Models
{
	public class Profile
	{
        public int Id { get; set; }

        public string Username { get; set; } = null!;

        public string DisplayName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public byte Gender { get; set; }

        public DateTime Birthday { get; set; }
    }
}
