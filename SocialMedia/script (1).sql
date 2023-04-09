use SocialMedia
GO
SET IDENTITY_INSERT [dbo].[chat_groups] ON 

INSERT [dbo].[chat_groups] ([id], [name], [isPrivate]) VALUES (1, N'Nhom 1', 1)
INSERT [dbo].[chat_groups] ([id], [name], [isPrivate]) VALUES (2, N'Nhom 2', 0)
SET IDENTITY_INSERT [dbo].[chat_groups] OFF
GO
SET IDENTITY_INSERT [dbo].[roles] ON 

INSERT [dbo].[roles] ([id], [name]) VALUES (1, N'Admin')
INSERT [dbo].[roles] ([id], [name]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[roles] OFF
GO
SET IDENTITY_INSERT [dbo].[users] ON 

INSERT [dbo].[users] ([id], [username], [display_name], [email], [password], [gender], [birthday], [avatar_img], [background_img], [isLocked], [role_id]) VALUES (1, N'luong                                             ', N'pluong', N'luong123@gmail.com                                          ', N'123                                                                                                                                                                                                     ', 1, CAST(N'2002-02-09' AS Date), NULL, NULL, 0, 2)
INSERT [dbo].[users] ([id], [username], [display_name], [email], [password], [gender], [birthday], [avatar_img], [background_img], [isLocked], [role_id]) VALUES (2, N'hoang                                             ', N'vhoang', N'hoang123@gmail.com                                         ', N'123                                                                                                                                                                                                     ', 1, CAST(N'2002-06-10' AS Date), NULL, NULL, 0, 2)
INSERT [dbo].[users] ([id], [username], [display_name], [email], [password], [gender], [birthday], [avatar_img], [background_img], [isLocked], [role_id]) VALUES (4, N'linh                                              ', N'mlinh', N'linh123@gmail.com                                              ', N'1234                                                                                                                                                                                                    ', 0, CAST(N'2002-08-04' AS Date), NULL, NULL, 0, 1)
INSERT [dbo].[users] ([id], [username], [display_name], [email], [password], [gender], [birthday], [avatar_img], [background_img], [isLocked], [role_id]) VALUES (5, N'vinh                                              ', N'nvinh', N'vinh123@gmail.com                                              ', N'1345                                                                                                                                                                                                    ', 1, CAST(N'2002-07-12' AS Date), NULL, NULL, 0, 2)
INSERT [dbo].[users] ([id], [username], [display_name], [email], [password], [gender], [birthday], [avatar_img], [background_img], [isLocked], [role_id]) VALUES (6, N'quân                                              ', N'nquan', N'quan123@gmail.com                                              ', N'1967                                                                                                                                                                                                    ', 1, CAST(N'2002-03-20' AS Date), NULL, NULL, 0, 2)
SET IDENTITY_INSERT [dbo].[users] OFF
GO
SET IDENTITY_INSERT [dbo].[chat_members] ON 

INSERT [dbo].[chat_members] ([id], [user_id], [group_id], [joined_datetime], [left_datetime]) VALUES (1, 4, 1, CAST(N'2023-02-15T10:42:07.000' AS DateTime), NULL)
INSERT [dbo].[chat_members] ([id], [user_id], [group_id], [joined_datetime], [left_datetime]) VALUES (2, 4, 2, CAST(N'2023-02-15T10:42:07.000' AS DateTime), NULL)
INSERT [dbo].[chat_members] ([id], [user_id], [group_id], [joined_datetime], [left_datetime]) VALUES (3, 1, 2, CAST(N'2023-02-15T10:42:07.000' AS DateTime), NULL)
INSERT [dbo].[chat_members] ([id], [user_id], [group_id], [joined_datetime], [left_datetime]) VALUES (4, 2, 1, CAST(N'2023-02-15T10:42:07.000' AS DateTime), NULL)
INSERT [dbo].[chat_members] ([id], [user_id], [group_id], [joined_datetime], [left_datetime]) VALUES (5, 2, 2, CAST(N'2023-02-15T10:42:09.000' AS DateTime), NULL)
INSERT [dbo].[chat_members] ([id], [user_id], [group_id], [joined_datetime], [left_datetime]) VALUES (6, 5, 2, CAST(N'2023-02-15T10:42:07.000' AS DateTime), NULL)
INSERT [dbo].[chat_members] ([id], [user_id], [group_id], [joined_datetime], [left_datetime]) VALUES (7, 6, 2, CAST(N'2023-02-15T10:42:07.000' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[chat_members] OFF
GO
SET IDENTITY_INSERT [dbo].[messages] ON 

INSERT [dbo].[messages] ([id], [message], [sent_datetime], [group_id], [sender_id]) VALUES (1, N'123abc', CAST(N'2023-02-15T10:50:07.000' AS DateTime), 2, 1)
INSERT [dbo].[messages] ([id], [message], [sent_datetime], [group_id], [sender_id]) VALUES (2, N'123xyz', CAST(N'2023-02-15T10:50:07.000' AS DateTime), 2, 2)
INSERT [dbo].[messages] ([id], [message], [sent_datetime], [group_id], [sender_id]) VALUES (3, N'hello', CAST(N'2023-02-15T10:44:07.000' AS DateTime), 1, 4)
SET IDENTITY_INSERT [dbo].[messages] OFF
GO
SET IDENTITY_INSERT [dbo].[posts] ON 

INSERT [dbo].[posts] ([id], [user_id], [created_datetime], [text_content], [isPublic]) VALUES (2, 1, CAST(N'2023-03-15T15:42:07.000' AS DateTime), NULL, 1)
INSERT [dbo].[posts] ([id], [user_id], [created_datetime], [text_content], [isPublic]) VALUES (6, 2, CAST(N'2023-02-15T10:42:07.000' AS DateTime), NULL, 1)
INSERT [dbo].[posts] ([id], [user_id], [created_datetime], [text_content], [isPublic]) VALUES (14, 2, CAST(N'2023-01-16T12:42:07.000' AS DateTime), NULL, 1)
INSERT [dbo].[posts] ([id], [user_id], [created_datetime], [text_content], [isPublic]) VALUES (22, 4, CAST(N'2023-03-11T15:42:07.000' AS DateTime), NULL, 1)
INSERT [dbo].[posts] ([id], [user_id], [created_datetime], [text_content], [isPublic]) VALUES (23, 6, CAST(N'2023-03-15T10:42:07.000' AS DateTime), NULL, 0)
INSERT [dbo].[posts] ([id], [user_id], [created_datetime], [text_content], [isPublic]) VALUES (24, 1, CAST(N'2023-03-15T20:42:07.000' AS DateTime), NULL, 1)
SET IDENTITY_INSERT [dbo].[posts] OFF
GO
SET IDENTITY_INSERT [dbo].[comments] ON 

INSERT [dbo].[comments] ([id], [user_id], [post_id], [created_datetime], [text_content], [parent_id]) VALUES (1, 1, 14, CAST(N'2023-01-16T13:00:07.000' AS DateTime), N'abc', NULL)
INSERT [dbo].[comments] ([id], [user_id], [post_id], [created_datetime], [text_content], [parent_id]) VALUES (2, 2, 14, CAST(N'2023-01-16T13:10:07.000' AS DateTime), N'xyz', NULL)
INSERT [dbo].[comments] ([id], [user_id], [post_id], [created_datetime], [text_content], [parent_id]) VALUES (3, 4, 6, CAST(N'2023-02-15T20:42:07.000' AS DateTime), N'JQK', NULL)
SET IDENTITY_INSERT [dbo].[comments] OFF
GO
SET IDENTITY_INSERT [dbo].[media] ON 

INSERT [dbo].[media] ([id], [media_file], [media_type], [post_id]) VALUES (1, N'0', N'0', 6)
INSERT [dbo].[media] ([id], [media_file], [media_type], [post_id]) VALUES (2, N'0', N'0', 14)
INSERT [dbo].[media] ([id], [media_file], [media_type], [post_id]) VALUES (3, N'0', N'0', 2)
INSERT [dbo].[media] ([id], [media_file], [media_type], [post_id]) VALUES (4, N'0', N'0', 23)
INSERT [dbo].[media] ([id], [media_file], [media_type], [post_id]) VALUES (5, N'0', N'0', 22)
INSERT [dbo].[media] ([id], [media_file], [media_type], [post_id]) VALUES (6, N'0', N'0', 24)
SET IDENTITY_INSERT [dbo].[media] OFF
GO
SET IDENTITY_INSERT [dbo].[friend_requests] ON 

INSERT [dbo].[friend_requests] ([id], [friend_id], [user_id], [status], [sent_time]) VALUES (1, 1, 2, 0, CAST(N'2023-03-15' AS Date))
INSERT [dbo].[friend_requests] ([id], [friend_id], [user_id], [status], [sent_time]) VALUES (17, 5, 2, 0, CAST(N'2023-04-15' AS Date))
INSERT [dbo].[friend_requests] ([id], [friend_id], [user_id], [status], [sent_time]) VALUES (19, 2, 4, 0, CAST(N'2023-03-16' AS Date))
INSERT [dbo].[friend_requests] ([id], [friend_id], [user_id], [status], [sent_time]) VALUES (20, 1, 5, 0, CAST(N'2023-03-16' AS Date))
INSERT [dbo].[friend_requests] ([id], [friend_id], [user_id], [status], [sent_time]) VALUES (21, 6, 5, 0, CAST(N'2023-03-16' AS Date))
INSERT [dbo].[friend_requests] ([id], [friend_id], [user_id], [status], [sent_time]) VALUES (22, 4, 5, 0, CAST(N'2023-03-17' AS Date))
SET IDENTITY_INSERT [dbo].[friend_requests] OFF
GO
SET IDENTITY_INSERT [dbo].[likes] ON 

INSERT [dbo].[likes] ([id], [user_id], [target_id], [type], [isPostLike]) VALUES (1, 2, 2, 1, 1)
INSERT [dbo].[likes] ([id], [user_id], [target_id], [type], [isPostLike]) VALUES (2, 4, 4, 1, 1)
INSERT [dbo].[likes] ([id], [user_id], [target_id], [type], [isPostLike]) VALUES (3, 2, 2, 0, 0)
SET IDENTITY_INSERT [dbo].[likes] OFF
GO
