namespace BTL_WEB.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int PostId { get; set; }

    public DateTime CreatedDatetime { get; set; }

    public string TextContent { get; set; } = null!;

    public int? ParentId { get; set; }

    public virtual Post Post { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
