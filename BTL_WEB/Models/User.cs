﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTL_WEB.Models;

public partial class User
{
    public int Id { get; set; }

	[RegularExpression("[a-zA-Z ]+", ErrorMessage = "Định dạng Username không hợp lệ!")]
	public string? Username { get; set; }

	[RegularExpression("[a-zA-Z0-9 ]+", ErrorMessage = "Định dạng Displayname không hợp lệ!")]
	public string DisplayName { get; set; } = null!;

	//[RegularExpression(@"^([\w-]+(\?\:\.[\w-]+)*)@((\?\:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(\?\:\.[a-z]{2})?)$", ErrorMessage = "Invalid email format")]
	[RegularExpression(@"^([\w-]+(\?\:\.[\w-]+)*)@((\?\:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(\?\:\.[a-z]{2})?)\s*$", ErrorMessage = "Định dạng Email không hợp lệ!")]
	public string Email { get; set; } = null!;

	[RegularExpression("^[a-zA-Z0-9!@#$%^&*()_+\\-=[\\]{}|;':\",./<>? ]+$", ErrorMessage = "Định dạng Password không hợp lệ!")]
	public string Password { get; set; } = null!;

    public byte? Gender { get; set; }

    public DateTime? Birthday { get; set; }

    public string? AvatarImg { get; set; }

    public string? BackgroundImg { get; set; }

    public bool IsLocked { get; set; }

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
