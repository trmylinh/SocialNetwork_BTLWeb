using System;
using System.Collections.Generic;

namespace BTL_WEB.Models;

public partial class ChatGroup
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsPrivate { get; set; }

    public virtual ICollection<ChatMember> ChatMembers { get; } = new List<ChatMember>();

    public virtual ICollection<Message> Messages { get; } = new List<Message>();
}
