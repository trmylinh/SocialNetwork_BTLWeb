using System;
using System.Collections.Generic;

namespace BTL_WEB.Models;

public partial class Medium
{
    public int Id { get; set; }

    public string MediaFile { get; set; } = null!;

    public string MediaType { get; set; } = null!;

    public int PostId { get; set; }

    public virtual Post Post { get; set; } = null!;
}
