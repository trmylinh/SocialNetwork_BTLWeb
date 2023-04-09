using System;
using System.Collections.Generic;

namespace BTL_WEB.Models;

public partial class Post
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public DateTime CreatedDatetime { get; set; }

    public string? TextContent { get; set; }

    public bool IsPublic { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<Medium> Media { get; } = new List<Medium>();

    public virtual User User { get; set; } = null!;
}
