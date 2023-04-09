using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BTL_WEB.Models;

public partial class ChatGroup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsPrivate { get; set; }

    [JsonIgnore]
    public virtual ICollection<ChatMember> ChatMembers { get; } = new List<ChatMember>();

    [JsonIgnore]
    public virtual ICollection<Message> Messages { get; } = new List<Message>();
}
