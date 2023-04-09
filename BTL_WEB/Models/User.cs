using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BTL_WEB.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string DisplayName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte? Gender { get; set; }

    public DateTime? Birthday { get; set; }

    public string? AvatarImg { get; set; }

    public string? BackgroundImg { get; set; }
    [JsonIgnore]
    public bool? IsLocked { get; set; }
    [JsonIgnore]
    public int RoleId { get; set; }

    [JsonIgnore]
    public virtual ICollection<ChatMember> ChatMembers { get; } = new List<ChatMember>();
    [JsonIgnore]
    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();
    [JsonIgnore]
    public virtual ICollection<FriendRequest> FriendRequestFriends { get; } = new List<FriendRequest>();
    [JsonIgnore]
    public virtual ICollection<FriendRequest> FriendRequestUsers { get; } = new List<FriendRequest>();
    [JsonIgnore]
    public virtual ICollection<Like> Likes { get; } = new List<Like>();
    [JsonIgnore]
    public virtual ICollection<Message> Messages { get; } = new List<Message>();
    [JsonIgnore]
    public virtual ICollection<Post> Posts { get; } = new List<Post>();
    [JsonIgnore]
    public virtual Role Role { get; set; } = null!;
}
