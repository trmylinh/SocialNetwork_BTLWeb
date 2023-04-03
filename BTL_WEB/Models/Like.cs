namespace BTL_WEB.Models;

public partial class Like
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int TargetId { get; set; }

    public byte Type { get; set; }

    public bool IsPostLike { get; set; }

    public virtual User User { get; set; } = null!;
}
