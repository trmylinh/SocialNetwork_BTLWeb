USE [master]
GO
/****** Object:  Database [SocialMedia]    Script Date: 2/27/2023 4:35:19 PM ******/
CREATE DATABASE [SocialMedia]
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [SocialMedia] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SocialMedia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SocialMedia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SocialMedia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SocialMedia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SocialMedia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SocialMedia] SET ARITHABORT OFF 
GO
ALTER DATABASE [SocialMedia] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SocialMedia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SocialMedia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SocialMedia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SocialMedia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SocialMedia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SocialMedia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SocialMedia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SocialMedia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SocialMedia] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SocialMedia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SocialMedia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SocialMedia] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SocialMedia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SocialMedia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SocialMedia] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SocialMedia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SocialMedia] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SocialMedia] SET  MULTI_USER 
GO
ALTER DATABASE [SocialMedia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SocialMedia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SocialMedia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SocialMedia] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SocialMedia] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SocialMedia] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SocialMedia] SET QUERY_STORE = OFF
GO
USE [SocialMedia]
GO
/****** Object:  Table [dbo].[chat_groups]    Script Date: 2/27/2023 4:35:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chat_groups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[isPrivate] [bit] NOT NULL,
 CONSTRAINT [PK_chat_groups] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chat_members]    Script Date: 2/27/2023 4:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chat_members](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[group_id] [int] NOT NULL,
	[joined_datetime] [datetime] NOT NULL,
	[left_datetime] [datetime] NULL,
 CONSTRAINT [PK_chat_members] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[comments]    Script Date: 2/27/2023 4:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[post_id] [int] NOT NULL,
	[created_datetime] [datetime] NOT NULL,
	[text_content] [nvarchar](max) NOT NULL,
	[parent_id] [int] NULL,
 CONSTRAINT [PK_comments] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[friend_requests]    Script Date: 2/27/2023 4:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[friend_requests](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[friend_id] [int] NOT NULL,
	[user_id] [int] NOT NULL,
	[status] [tinyint] NOT NULL,
	[sent_time] [date] NOT NULL,
 CONSTRAINT [PK_friend_requests] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[likes]    Script Date: 2/27/2023 4:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[likes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[target_id] [int] NOT NULL,
	[type] [tinyint] NOT NULL,
	[isPostLike] [bit] NOT NULL,
 CONSTRAINT [PK_likes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[media]    Script Date: 2/27/2023 4:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[media](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[media_file] [varchar](100) NOT NULL,
	[media_type] [varchar](10) NOT NULL,
	[post_id] [int] NOT NULL,
 CONSTRAINT [PK_media] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[messages]    Script Date: 2/27/2023 4:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[messages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[message] [nvarchar](max) NOT NULL,
	[sent_datetime] [datetime] NOT NULL,
	[group_id] [int] NOT NULL,
	[sender_id] [int] NOT NULL,
 CONSTRAINT [PK_messages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[posts]    Script Date: 2/27/2023 4:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[posts](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[created_datetime] [datetime] NOT NULL,
	[text_content] [nvarchar](max) NULL,
	[isPublic] [bit] NOT NULL,
 CONSTRAINT [PK_posts] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[roles]    Script Date: 2/27/2023 4:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[users]    Script Date: 2/27/2023 4:35:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [nchar](50) NULL,
	[display_name] [nvarchar](70) NOT NULL,
	[email] [nchar](50) NOT NULL,
	[password] [nchar](200) NOT NULL,
	[gender] [tinyint] NULL,
	[birthday] [date] NULL,
	[avatar_img] [varbinary](max) NULL,
	[background_img] [varbinary](max) NULL,
	[isLocked] [bit] NOT NULL,
	[role_id] [int] NOT NULL default(2),
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_users_email]    Script Date: 2/27/2023 4:35:20 PM ******/
ALTER TABLE [dbo].[users] ADD  CONSTRAINT [UQ_users_email] UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ_users_username]    Script Date: 2/27/2023 4:35:20 PM ******/


ALTER TABLE [dbo].[chat_groups] ADD  CONSTRAINT [DF_chat_groups_isPrivate]  DEFAULT ((0)) FOR [isPrivate]
GO
ALTER TABLE [dbo].[likes] ADD  CONSTRAINT [DF_likes_type]  DEFAULT ((0)) FOR [type]
GO
ALTER TABLE [dbo].[likes] ADD  CONSTRAINT [DF_likes_isPostLike]  DEFAULT ((0)) FOR [isPostLike]
GO
ALTER TABLE [dbo].[posts] ADD  CONSTRAINT [DF_posts_isPublic]  DEFAULT ((0)) FOR [isPublic]
GO
ALTER TABLE [dbo].[roles] ADD  CONSTRAINT [DF_roles_name]  DEFAULT (user_name()) FOR [name]
GO
ALTER TABLE [dbo].[users] ADD  DEFAULT ((0)) FOR [isLocked]
GO
ALTER TABLE [dbo].[chat_members]  WITH CHECK ADD  CONSTRAINT [FK_chat_members_chat_groups] FOREIGN KEY([group_id])
REFERENCES [dbo].[chat_groups] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[chat_members] CHECK CONSTRAINT [FK_chat_members_chat_groups]
GO
ALTER TABLE [dbo].[chat_members]  WITH CHECK ADD  CONSTRAINT [FK_chat_members_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[chat_members] CHECK CONSTRAINT [FK_chat_members_users]
GO
ALTER TABLE [dbo].[comments]  WITH CHECK ADD  CONSTRAINT [FK_comments_posts] FOREIGN KEY([post_id])
REFERENCES [dbo].[posts] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[comments] CHECK CONSTRAINT [FK_comments_posts]
GO
ALTER TABLE [dbo].[comments]  WITH CHECK ADD  CONSTRAINT [FK_comments_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[comments] CHECK CONSTRAINT [FK_comments_users]
GO
ALTER TABLE [dbo].[friend_requests]  WITH CHECK ADD  CONSTRAINT [FK_friend_requests_target_users] FOREIGN KEY([friend_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[friend_requests] CHECK CONSTRAINT [FK_friend_requests_target_users]
GO
ALTER TABLE [dbo].[friend_requests]  WITH CHECK ADD  CONSTRAINT [FK_friend_requests_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[friend_requests] CHECK CONSTRAINT [FK_friend_requests_users]
GO
ALTER TABLE [dbo].[likes]  WITH CHECK ADD  CONSTRAINT [FK_likes_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[likes] CHECK CONSTRAINT [FK_likes_users]
GO
ALTER TABLE [dbo].[media]  WITH CHECK ADD  CONSTRAINT [FK_media_posts] FOREIGN KEY([post_id])
REFERENCES [dbo].[posts] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[media] CHECK CONSTRAINT [FK_media_posts]
GO
ALTER TABLE [dbo].[messages]  WITH CHECK ADD  CONSTRAINT [FK_messages_chat_groups] FOREIGN KEY([group_id])
REFERENCES [dbo].[chat_groups] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[messages] CHECK CONSTRAINT [FK_messages_chat_groups]
GO
ALTER TABLE [dbo].[messages]  WITH CHECK ADD  CONSTRAINT [FK_messages_users] FOREIGN KEY([sender_id])
REFERENCES [dbo].[users] ([id])
GO
ALTER TABLE [dbo].[messages] CHECK CONSTRAINT [FK_messages_users]
GO
ALTER TABLE [dbo].[posts]  WITH CHECK ADD  CONSTRAINT [FK_posts_users] FOREIGN KEY([user_id])
REFERENCES [dbo].[users] ([id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[posts] CHECK CONSTRAINT [FK_posts_users]
GO
ALTER TABLE [dbo].[users]  WITH CHECK ADD  CONSTRAINT [FK_users_roles] FOREIGN KEY([role_id])
REFERENCES [dbo].[roles] ([id])
GO
ALTER TABLE [dbo].[users] CHECK CONSTRAINT [FK_users_roles]
GO
USE [master]
GO
ALTER DATABASE [SocialMedia] SET  READ_WRITE 
GO
