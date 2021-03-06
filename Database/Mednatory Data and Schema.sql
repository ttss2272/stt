/****** Object:  Table [dbo].[UserType]    Script Date: 12/16/2015 10:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserType](
	[UserTypeID] [int] IDENTITY(1,1) NOT NULL,
	[UserTypeName] [nvarchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [UserTypeID] PRIMARY KEY CLUSTERED 
(
	[UserTypeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[UserType] ON
INSERT [dbo].[UserType] ([UserTypeID], [UserTypeName], [IsActive], [IsDeleted]) VALUES (1, N'Admin', 1, 0)
INSERT [dbo].[UserType] ([UserTypeID], [UserTypeName], [IsActive], [IsDeleted]) VALUES (2, N'User', 1, 0)
SET IDENTITY_INSERT [dbo].[UserType] OFF
/****** Object:  Table [dbo].[Messages]    Script Date: 12/16/2015 10:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Messages](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
 CONSTRAINT [PK_Messages] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Messages] ON
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (1, N'Save Sucessfully...!!!')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (2, N'Error To Save.')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (3, N'This Subject Name Already Exists,Please Enter Another Subject Name')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (4, N'This Short Name Already Exists,Please Enter Another Short Name')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (5, N'Updated Sucessfully...!!!')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (7, N'Branch Name Already Exisits!!!')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (8, N'This logo already E')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (9, N'Branch Deleted Sucessfully!!!')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (10, N'Error to Delete Branch')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (11, N'This Class Name Already Exists,Please Enter Another Class Name')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (12, N'Deleted Sucessfully...!!')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (13, N'Error to Delete Record..!!')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (14, N'This Batch Name Already Exists, Please Enter Another Batch Name')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (15, N'This Batch Code Already Exists, Please Enter Another Batch Code')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (16, N'Name Already Exsist')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (17, N'This Room Name Already Exists,Please Enter Another Room Name')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (19, N'This Time Slot Already Exists, Please Enter Another')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (20, N'This BranchDistance Exists Already, Please Enter Another')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (21, N'This Class Room Time Is Already Allocated.')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (22, N'Selected Teacher Time Is Already Allocated.')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (23, N'Selected Batch This Time Is Already Allocated.')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (24, N'OK')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (25, N'This Board Name Already Exists')
INSERT [dbo].[Messages] ([MessageID], [Message]) VALUES (26, N'This Login ID Is Already Exists')
SET IDENTITY_INSERT [dbo].[Messages] OFF
/****** Object:  Table [dbo].[Login]    Script Date: 12/16/2015 10:12:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[LoginuserId] [int] NOT NULL,
	[LoginUserName] [nvarchar](50) NULL,
	[Password] [nvarchar](50) NULL,
	[LoginType] [nvarchar](50) NULL,
	[ExpiryDate] [date] NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[LoginuserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Login] ([LoginuserId], [LoginUserName], [Password], [LoginType], [ExpiryDate]) VALUES (1, N'Admin', N'123', N'Admin', CAST(0x2D3C0B00 AS Date))
