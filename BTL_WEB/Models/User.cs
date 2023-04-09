using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTL_WEB.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string DisplayName { get; set; } = null!;

	[RegularExpression(@"^([\w-]+(\?\:\.[\w-]+)*)@((\?\:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(\?\:\.[a-z]{2})?)$", ErrorMessage = "Invalid email format")]
	public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public byte? Gender { get; set; }

    public DateTime? Birthday { get; set; }

    public string? AvatarImg { get; set; }

    public string? BackgroundImg { get; set; }

    public bool IsLocked { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<ChatMember> ChatMembers { get; } = new List<ChatMember>();

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<FriendRequest> FriendRequestFriends { get; } = new List<FriendRequest>();

    public virtual ICollection<FriendRequest> FriendRequestUsers { get; } = new List<FriendRequest>();

    public virtual ICollection<Like> Likes { get; } = new List<Like>();

    public virtual ICollection<Message> Messages { get; } = new List<Message>();

    public virtual ICollection<Post> Posts { get; } = new List<Post>();

    public virtual Role Role { get; set; } = null!;
}
