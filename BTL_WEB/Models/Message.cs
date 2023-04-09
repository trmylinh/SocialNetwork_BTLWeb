using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BTL_WEB.Models;

public partial class Message
{
    public int Id { get; set; }

    public string Message1 { get; set; } = null!;

    public DateTime SentDatetime { get; set; }

    public int GroupId { get; set; }

    public int SenderId { get; set; }

    [JsonIgnore]
    public virtual ChatGroup? Group { get; set; } = null!;

    [JsonIgnore]
    public virtual User? Sender { get; set; } = null!;
}
