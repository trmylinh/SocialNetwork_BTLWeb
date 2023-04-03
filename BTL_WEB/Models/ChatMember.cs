namespace BTL_WEB.Models;

public partial class ChatMember
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int GroupId { get; set; }

    public DateTime JoinedDatetime { get; set; }

    public DateTime? LeftDatetime { get; set; }

    public virtual ChatGroup Group { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
