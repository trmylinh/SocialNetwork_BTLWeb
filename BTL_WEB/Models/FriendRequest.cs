namespace BTL_WEB.Models;

public partial class FriendRequest
{
    public int Id { get; set; }

    public int FriendId { get; set; }

    public int UserId { get; set; }

    public byte Status { get; set; }

    public DateTime SentTime { get; set; }

    public virtual User Friend { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
