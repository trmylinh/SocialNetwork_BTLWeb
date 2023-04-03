using Microsoft.EntityFrameworkCore;

namespace BTL_WEB.Models;

public partial class SocialMediaContext : DbContext
{
    public SocialMediaContext()
    {
    }

    public SocialMediaContext(DbContextOptions<SocialMediaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChatGroup> ChatGroups { get; set; }

    public virtual DbSet<ChatMember> ChatMembers { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<FriendRequest> FriendRequests { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatGroup>(entity =>
        {
            entity.ToTable("chat_groups");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsPrivate).HasColumnName("isPrivate");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        modelBuilder.Entity<ChatMember>(entity =>
        {
            entity.ToTable("chat_members");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.JoinedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("joined_datetime");
            entity.Property(e => e.LeftDatetime)
                .HasColumnType("datetime")
                .HasColumnName("left_datetime");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Group).WithMany(p => p.ChatMembers)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_chat_members_chat_groups");

            entity.HasOne(d => d.User).WithMany(p => p.ChatMembers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_chat_members_users");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.ToTable("comments");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("created_datetime");
            entity.Property(e => e.ParentId).HasColumnName("parent_id");
            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.TextContent).HasColumnName("text_content");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Post).WithMany(p => p.Comments)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_comments_posts");

            entity.HasOne(d => d.User).WithMany(p => p.Comments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_comments_users");
        });

        modelBuilder.Entity<FriendRequest>(entity =>
        {
            entity.ToTable("friend_requests");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.FriendId).HasColumnName("friend_id");
            entity.Property(e => e.SentTime)
                .HasColumnType("date")
                .HasColumnName("sent_time");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Friend).WithMany(p => p.FriendRequestFriends)
                .HasForeignKey(d => d.FriendId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_friend_requests_target_users");

            entity.HasOne(d => d.User).WithMany(p => p.FriendRequestUsers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_friend_requests_users");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.ToTable("likes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsPostLike).HasColumnName("isPostLike");
            entity.Property(e => e.TargetId).HasColumnName("target_id");
            entity.Property(e => e.Type).HasColumnName("type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Likes)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_likes_users");
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.ToTable("media");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.MediaFile)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("media_file");
            entity.Property(e => e.MediaType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("media_type");
            entity.Property(e => e.PostId).HasColumnName("post_id");

            entity.HasOne(d => d.Post).WithMany(p => p.Media)
                .HasForeignKey(d => d.PostId)
                .HasConstraintName("FK_media_posts");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.ToTable("messages");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.Message1).HasColumnName("message");
            entity.Property(e => e.SenderId).HasColumnName("sender_id");
            entity.Property(e => e.SentDatetime)
                .HasColumnType("datetime")
                .HasColumnName("sent_datetime");

            entity.HasOne(d => d.Group).WithMany(p => p.Messages)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_messages_chat_groups");

            entity.HasOne(d => d.Sender).WithMany(p => p.Messages)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_messages_users");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.ToTable("posts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDatetime)
                .HasColumnType("datetime")
                .HasColumnName("created_datetime");
            entity.Property(e => e.IsPublic).HasColumnName("isPublic");
            entity.Property(e => e.TextContent).HasColumnName("text_content");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Posts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_posts_users");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("(user_name())")
                .HasColumnName("name");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "UQ_users_email").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AvatarImg).HasColumnName("avatar_img");
            entity.Property(e => e.BackgroundImg).HasColumnName("background_img");
            entity.Property(e => e.Birthday)
                .HasColumnType("date")
                .HasColumnName("birthday");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(70)
                .HasColumnName("display_name");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.IsLocked).HasColumnName("isLocked");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsFixedLength()
                .HasColumnName("password");
            entity.Property(e => e.RoleId)
                .HasDefaultValueSql("((2))")
                .HasColumnName("role_id");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("username");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_users_roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
