USE [NewTimeTableDB]
GO
/****** Object:  Table [dbo].[UserType]    Script Date: 12/16/2015 19:51:27 ******/
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
/****** Object:  Table [dbo].[Color]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Color](
	[ColorID] [int] IDENTITY(1,1) NOT NULL,
	[ColorName] [nvarchar](40) NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[UpdatedByUserID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [ColorID] PRIMARY KEY CLUSTERED 
(
	[ColorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BatchAvailableDetails]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BatchAvailableDetails](
	[BatchAvailableDetailsID] [int] IDENTITY(1,1) NOT NULL,
	[BatchAvailableID] [int] NULL,
	[LectStartTime] [time](7) NULL,
	[LectEndTime] [time](7) NULL,
 CONSTRAINT [PK_BatchAvailableDetails] PRIMARY KEY CLUSTERED 
(
	[BatchAvailableDetailsID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Branch]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Branch](
	[BranchID] [int] IDENTITY(1,1) NOT NULL,
	[BranchName] [nvarchar](max) NULL,
	[BranchCode] [nvarchar](max) NULL,
	[CreatedByUserID] [int] NULL,
	[UpdatedByUserID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[InstituteName] [nvarchar](max) NULL,
	[IsActive] [int] NULL,
	[Logo] [nvarchar](max) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [BranchID] PRIMARY KEY CLUSTERED 
(
	[BranchID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Board]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Board](
	[BoardID] [int] IDENTITY(1,1) NOT NULL,
	[BoardName] [nvarchar](50) NULL,
	[CreatedByUserID] [int] NULL,
	[UpdatedByUserID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Board] PRIMARY KEY CLUSTERED 
(
	[BoardID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherID] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [nvarchar](max) NOT NULL,
	[TeacherSurname] [nvarchar](max) NOT NULL,
	[TeacherShortName] [nvarchar](10) NOT NULL,
	[Color] [nvarchar](50) NULL,
	[CreatedByUserID] [int] NOT NULL,
	[UpadatedByUserID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[NoOfBranches] [int] NULL,
	[NoOfDaysAvailable] [int] NULL,
	[NoOfMovesInBranch] [int] NULL,
	[MaxNoLecturesDay] [int] NULL,
	[MaxNoLectureWeek] [int] NULL,
	[IsAllowMoreThanOneLectInBatch] [bit] NULL,
	[MaxNoOfLectureInRow] [int] NULL,
	[IsFirstLect] [bit] NULL,
	[IsLastLect] [bit] NULL,
	[FreeTimeStart] [time](7) NULL,
	[FreeTimeEnd] [time](7) NULL,
	[IsDeleted] [bit] NULL,
	[IsVaryBranch] [bit] NULL,
 CONSTRAINT [TeacherID] PRIMARY KEY CLUSTERED 
(
	[TeacherID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Subject]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Subject](
	[SubjectID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectName] [nvarchar](max) NULL,
	[SubjectShortName] [nvarchar](10) NULL,
	[CreatedByUserID] [int] NULL,
	[UpdatedByUserID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_Subject] PRIMARY KEY CLUSTERED 
(
	[SubjectID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Messages]    Script Date: 12/16/2015 19:51:27 ******/
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
/****** Object:  Table [dbo].[Login]    Script Date: 12/16/2015 19:51:27 ******/
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
/****** Object:  Table [dbo].[Log]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Log](
	[LogID] [int] IDENTITY(1,1) NOT NULL,
	[LogDescription] [nvarchar](max) NULL,
	[Timing] [datetime] NULL,
	[TableName] [nvarchar](max) NULL,
	[TableRowID] [int] NULL,
 CONSTRAINT [PK_Log] PRIMARY KEY CLUSTERED 
(
	[LogID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorLog]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLog](
	[ErrorLogID] [int] NOT NULL,
	[ErrorDesc] [nvarchar](max) NULL,
	[FormPath] [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[GetBranch_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sameer Shinde
-- Create date: 5 Nov 2015
-- Description:	Get Branch to gridview
-- =============================================
CREATE PROCEDURE [dbo].[GetBranch_SP]-- 0,'',''
	(
	@BranchID int,
	@BranchName nvarchar(50),
	@BranchCode nvarchar(50)
	)
AS
BEGIN
	SELECT BranchID,BranchName,BranchCode,InstituteName,Logo,IsActive,IsDeleted,
	case when IsActive =1 then 'Active' 
	when IsActive =0 then 'InActive' end as [Status]   from Branch
	WHERE BranchID LIKE CASE WHEN @BranchID<>0 THEN @BranchID ELSE CONVERT (NVARCHAR(50),BranchID)END
	AND BranchName LIKE CASE WHEN @BranchName<>'' THEN @BranchName ELSE CONVERT(nvarchar(50),BranchName)END
	AND BranchCode LIKE CASE WHEN @BranchCode<>'' THEN @BranchCode ELSE CONVERT(nvarchar(50),BranchCode)END
	AND IsDeleted<>'True'
END
GO
/****** Object:  StoredProcedure [dbo].[GetBoard_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 10 Dec 2015
-- Description:	Get Board Name to Bind Dorpdown
-- =============================================
CREATE PROCEDURE [dbo].[GetBoard_SP] 
	
AS
BEGIN
	Select 0 AS BoardID,'SELECT' AS BoardName
	UNION
	SELECT BoardID,BoardName FROM Board
	WHERE IsActive='True' AND IsDeleted<>'True'
	ORDER BY BoardName
END
GO
/****** Object:  StoredProcedure [dbo].[GetTeacher_Sp]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 07 Nov 2015
-- Description:	Get Details of Teacher
-- =============================================
CREATE PROCEDURE [dbo].[GetTeacher_Sp] --1
(
	@TeacherID int
)
AS
BEGIN


	SELECT TeacherID,TeacherName,TeacherSurname,TeacherShortName,NoOfMovesInBranch,MaxNoLecturesDay,MaxNoLectureWeek,MaxNoOfLectureInRow,
	CASE IsFirstLect WHEN 'True' THEN 'Yes' ELSE 'No' END AS IsFirstLect,
	CASE ISLastLect  WHEN 'True' THEN 'Yes' ELSE 'No' END As IsLastLect,
	FreeTimeStart,FreeTimeEnd,Convert(NVARCHAR(7),FreeTimeStart)+' To '+ CONVERT(NVARCHAR(7),FreeTimeEnd) AS 'FreeTime',
	CASE IsActive  WHEN 'True' Then 'Active'  ELSE 'InActive' END AS IsActive,--IsAllowMoreThanOneLectInBatch,
	--IsActive, 
	CASE IsAllowMoreThanOneLectInBatch WHEN 'True' THEN 'Yes' ELSE 'No' END AS IsAllowMoreThanOneLectInBatch
	 FROM Teacher
	 WHERE IsDeleted='False' AND
	 TeacherID LIKE CASE WHEN @TeacherID<>0 THEN @TeacherID ELSE CONVERT(NVARCHAR(50),TeacherID) END

END
GO
/****** Object:  StoredProcedure [dbo].[GetSubjectDetail_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D.Sortee
-- Create date: 5 Nov 2015
-- Description:	get all details of subject
-- =============================================
CREATE PROCEDURE [dbo].[GetSubjectDetail_SP] 
(
	@SubjectName NVARCHAR(50),
	@ShortName NVARCHAR(50)	
	
)
AS
BEGIN
SELECT SubjectID,SubjectName,SubjectShortName,IsActive,IsDeleted FROM [Subject]
WHERE SubjectName = @SubjectName AND SubjectShortName=@ShortName
END
GO
/****** Object:  StoredProcedure [dbo].[GetSubject_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 4 Nov 2015
-- Description:	Get  Subject To bind DropDown
-- =============================================
CREATE PROCEDURE [dbo].[GetSubject_SP] 
	(
	@SubjectID int
	)
AS
BEGIN
	SELECT SubjectID,SubjectName,SubjectShortName  from [Subject]
	WHERE SubjectID LIKE CASE WHEN @SubjectID<>0 THEN @SubjectID ELSE CONVERT (NVARCHAR(50),SubjectID) END
	AND IsActive = 'True'
	ORDER BY SubjectName
END
GO
/****** Object:  StoredProcedure [dbo].[LoadBranchName_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		pravin
-- Create date: 19-11-2015
-- Description:	bind branch name for batch form
-- =============================================
CREATE PROCEDURE [dbo].[LoadBranchName_SP]
	
AS
BEGIN
	select 0 as BranchID,'Select' as BranchName
	union
	SELECT BranchID,BranchName  from [Branch]
	WHERE IsDeleted<>'True' And IsActive=1
	
    
END
GO
/****** Object:  StoredProcedure [dbo].[GetUserType_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kalpesh Katyare
-- Create date: 9 Nov 2015
-- Description:	Get UserType
-- =============================================
CREATE PROCEDURE [dbo].[GetUserType_SP] --0, ''
	@UserTypeID int
AS
BEGIN
SELECT 0 AS 'UserTypeID','Select' AS UserTypeName
UNION
	SELECT [UserTypeID], [UserTypeName] FROM [UserType]
	WHERE [UserTypeID] LIKE CASE WHEN @UserTypeID<>0 THEN @UserTypeID ELSE CONVERT (NVARCHAR(50),UserTypeID) END
	AND IsActive = 'True'
END
GO
/****** Object:  StoredProcedure [dbo].[GetMaxTeacherID_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sameer Shinde
-- Create date: 12 Dec 2015
-- Description:	Get Max Teacher ID
-- =============================================
CREATE PROCEDURE [dbo].[GetMaxTeacherID_SP]
	
AS
BEGIN
   
	SELECT MAX(TeacherID) from Teacher
END
GO
/****** Object:  StoredProcedure [dbo].[GetLoginDetails_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetLoginDetails_SP]
@UserName NVARCHAR(MAX),
@Pass NVARCHAR(MAX),
@CurrentDate NVARCHAR(MAX)
AS
DECLARE @msg NVARCHAR(MAX)
DECLARE @ExpDate NVARCHAR(MAX)
BEGIN

IF (EXISTS (SELECT LoginuserId FROM [Login] WHERE (BINARY_CHECKSUM(LoginUserName)=BINARY_CHECKSUM(@UserName)) AND (BINARY_CHECKSUM([Password])=BINARY_CHECKSUM(@Pass))))	
	BEGIN
		IF(EXISTS (SELECT LoginuserId FROM[Login] WHERE (BINARY_CHECKSUM(LoginUserName)=BINARY_CHECKSUM(@UserName)) AND (BINARY_CHECKSUM([Password])=BINARY_CHECKSUM(@Pass)) AND ExpiryDate>=CONVERT (date,@CurrentDate)))
			BEGIN
				SET @ExpDate= (SELECT CONVERT (date,ExpiryDate) FROM [Login] WHERE (BINARY_CHECKSUM(LoginUserName)=BINARY_CHECKSUM(@UserName)) AND (BINARY_CHECKSUM([Password])=BINARY_CHECKSUM(@Pass)) AND ExpiryDate>=CONVERT (date,@CurrentDate))
				SELECT 'Welcome' AS msg,DATEDIFF(dd,@CurrentDate,@ExpDate)
			END
		ELSE
			BEGIN
				SET @msg= 'Your Application Validity Is Expired'
				SELECT @msg
			END
		
	END
ELSE
	BEGIN
		SET @msg= 'Login Name Or Password Is Invalid'
		SELECT @msg
	END
    

	
END
GO
/****** Object:  StoredProcedure [dbo].[GetBranchCount_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sameer A. Shinde
-- Create date: 07/11/2015
-- Description:	Get Count Of branch
-- =============================================
CREATE PROCEDURE [dbo].[GetBranchCount_SP]
	
AS
BEGIN
	
	SELECT COUNT(*) from Branch
END
GO
/****** Object:  StoredProcedure [dbo].[SaveLog_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 11 Nov 2015
-- Description:	Save Log Table Detials
-- =============================================
CREATE PROCEDURE [dbo].[SaveLog_SP] 
	(
	@LogDescription nvarchar(50),
	@Timing nvarchar(50),
	@TableName nvarchar(50),
	@TableRowID nvarchar(50)
	)
AS
BEGIN
INSERT INTO [Log]
    (LogDescription,Timing,TableName,TableRowID)
    VALUES (@LogDescription,CONVERT(datetime,@Timing),@TableName,@TableRowID)
END
GO
/****** Object:  StoredProcedure [dbo].[SearchSubject_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 5 Nov 2015
-- Description:	search subject
-- =============================================
CREATE PROCEDURE [dbo].[SearchSubject_SP] --h
	-- Add the parameters for the stored procedure here
	@SubjectName NVARCHAR(50)
AS
BEGIN
	SELECT SubjectName,SubjectShortName,
	case when IsActive ='True'  then 'Active' 
	when IsActive ='False' then 'InActive' end as [Status] FROM [Subject]
	WHERE IsDeleted='False' 
	AND (SubjectName Like '%'+@SubjectName+'%' OR SubjectShortName LIKE '%'+@SubjectName+'%' )
END
GO
/****** Object:  StoredProcedure [dbo].[BindToBranchName_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Pranjali S Vidhate
-- Create date: 25/11/2015
-- Description:	To Bind Branch Name Foe Distance
-- =============================================
CREATE PROCEDURE [dbo].[BindToBranchName_SP]
	@FromBranchID int
AS
BEGIN
	
	select 0 as BranchID, 'Select' as BranchName
	union

    
	select BranchID, BranchName from [Branch]
	where IsDeleted <> 'True' and IsActive = 1
	and BranchID <> @FromBranchID
	ORDER BY BranchName
	
END
GO
/****** Object:  StoredProcedure [dbo].[BindBoard_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 10 DEC 2015
-- Description:	Bind Grid For Board
-- =============================================
CREATE PROCEDURE [dbo].[BindBoard_SP] 
	(
	@BoardID int,
	@BoardName nvarchar(MAX)
	)
AS
BEGIN
	SELECT BoardID,BoardName,IsActive,IsDeleted, CASE WHEN IsActive='True' AND IsDeleted='False' THEN 'Active'
	WHEN IsActive='False' AND IsDeleted='False' THEN 'InActive' END  as [Status] FROM Board 
	WHERE IsDeleted<>'True'
	AND BoardID Like CASE WHEN @BoardID<> 0 THEN @BoardID ELSE CONVERT(NVARCHAR(50),BoardID) END
	AND BoardName LIKE CASE WHEN @BoardName<>'' THEN '%'+@BoardName+'%' ELSE '%' END
END
GO
/****** Object:  Table [dbo].[BranchLecture]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchLecture](
	[BranchLectureID] [int] IDENTITY(1,1) NOT NULL,
	[BranchID] [int] NOT NULL,
	[DayName] [nvarchar](15) NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedByUserID] [int] NULL,
	[UpdatedByUserID] [int] NULL,
 CONSTRAINT [PK_BranchLecture] PRIMARY KEY CLUSTERED 
(
	[BranchLectureID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BranchesRooms]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchesRooms](
	[RoomID] [int] IDENTITY(1,1) NOT NULL,
	[RoomName] [nvarchar](max) NOT NULL,
	[RoomShortName] [nvarchar](10) NOT NULL,
	[RoomColor] [nvarchar](20) NOT NULL,
	[Capacity] [int] NOT NULL,
	[BranchID] [int] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[UpdatedByUserID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[MaxNoLecturesDay] [int] NULL,
	[MaxNoLecturesWeek] [int] NULL,
	[IsAllowMoreThanOneLectInBatch] [bit] NULL,
	[MaxNoOfLectureInRow] [int] NULL,
	[FreeTimeStart] [time](7) NULL,
	[FreeTimeEnd] [time](7) NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [RoomID] PRIMARY KEY CLUSTERED 
(
	[RoomID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BranchDistance]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchDistance](
	[BranchDistanceID] [int] IDENTITY(1,1) NOT NULL,
	[From_BranchID] [int] NOT NULL,
	[To_BranchID] [int] NOT NULL,
	[DistanceTime] [int] NOT NULL,
	[CreatedByUserID] [int] NULL,
	[UpdatedByUserID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [BranchDistaceID] PRIMARY KEY CLUSTERED 
(
	[BranchDistanceID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BranchAcadamicYear]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchAcadamicYear](
	[AcadmicYearID] [int] IDENTITY(1,1) NOT NULL,
	[BranchID] [int] NOT NULL,
	[AcadmicYearStartDate] [date] NOT NULL,
	[AcadmicYearEndDate] [date] NOT NULL,
 CONSTRAINT [AcadmicYearID] PRIMARY KEY CLUSTERED 
(
	[AcadmicYearID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[BindSubjectName_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 09-11-2015
-- Description:	Bind Subject Name
-- =============================================
CREATE PROCEDURE [dbo].[BindSubjectName_SP]
	
AS
BEGIN
	SELECT 0 AS SubjectID,'Select' AS SubjectName
	UNION
	SELECT SubjectID,SubjectName  from [Subject]
	WHERE IsDeleted<>'True' AND IsActive='True'
	Order By 'SubjectName'
	
    
END
GO
/****** Object:  StoredProcedure [dbo].[BindSubject_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 04 Nov 2015
-- Description:	Get Details To bind Drop Down
-- =============================================
CREATE PROCEDURE [dbo].[BindSubject_SP] --11
	(
		@SubjectID int
	)
AS
BEGIN
	SELECT SubjectID,SubjectName,SubjectShortName,
	 CASE IsActive When 'True' Then 'Active'
	 WHEN 'False' Then 'InActive' END
	 AS [Status]
	 FROM [Subject]
	WHERE SubjectID LIKE CASE WHEN @SubjectID<>0 THEN @SubjectID ELSE CONVERT (NVARCHAR(50),SubjectID) END
	AND IsDeleted=0
END
GO
/****** Object:  StoredProcedure [dbo].[BindBranchName_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:Pranjali
-- Create date: 05/11/2015
-- Description:	To Bind BranchName
-- =============================================
CREATE PROCEDURE [dbo].[BindBranchName_SP]
	
AS
BEGIN
   
	Select 0 AS BranchID ,'Select' AS BranchName
	Union
	SELECT BranchID,BranchName  from [Branch]
	WHERE IsDeleted<>'True' AND IsActive=1
	ORDER BY BranchName
	
    
END
GO
/****** Object:  Table [dbo].[Class]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class](
	[ClassID] [int] IDENTITY(1,1) NOT NULL,
	[ClassName] [nvarchar](max) NOT NULL,
	[ClassShortName] [nvarchar](10) NOT NULL,
	[Board] [nvarchar](20) NOT NULL,
	[Color] [nvarchar](20) NULL,
	[CreatedByUserID] [int] NOT NULL,
	[UpdatedByUserID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[BranchID] [int] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [ClassID] PRIMARY KEY CLUSTERED 
(
	[ClassID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[BindTeacher_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 07 Nov 2015
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[BindTeacher_SP] --32
	
	@TeacherID int = 0
	
AS
BEGIN
--Select 0 AS'TeacherID','Select'AS TeacherName,'' AS TeacherSurname,'' AS TeacherShortName,'' AS FreeTimeStart,'' AS FreeTimeEnd,'' AS NoOfMovesInBranch,'' AS MaxNoLecturesDay,'' AS MaxNoLectureWeek,'' AS IsAllowMoreThanOneLectInBatch,'' AS MaxNoOfLectureInRow,
	 --'' AS IsFirstLect,'' AS  IsLastLect, '' AS IsActive 
--Union 
	SELECT TeacherID,TeacherName,TeacherSurname,TeacherShortName,FreeTimeStart,FreeTimeEnd,NoOfMovesInBranch,MaxNoLecturesDay,MaxNoLectureWeek,IsAllowMoreThanOneLectInBatch,MaxNoOfLectureInRow,
	 IsFirstLect,IsLastLect,IsActive,case when IsActive ='True'  then 'Active' 
	when IsActive ='False' then 'InActive' end as [Status] FROM Teacher where IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[BindTeacherName_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 09-11-2015
-- Description:	to bind Teacher name on dropdown
-- =============================================
CREATE PROCEDURE [dbo].[BindTeacherName_SP]
	(
	@TeacherID int
 	)
AS
BEGIN
	
	SELECT 0 AS TeacherID,'Select' AS TeacherName 
UNION
 SELECT TeacherID,TeacherName+' '+TeacherSurname+'['+TeacherShortName+']' FROM [Teacher] WHERE 
 TeacherID LIKE CASE WHEN @TeacherID<>0 Then @TeacherID ELSE CONVERT(NVARCHAR(50),TeacherID) END
AND IsActive='True' AND IsDeleted='False'
ORDER BY TeacherName	
    
END
GO
/****** Object:  StoredProcedure [dbo].[BindInstituteName_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sameer Shinde
-- Create date: 6 Nov 2015
-- Description:	search Branch
-- Updated BY : Pritesh D. sortee
-- Updated Date: 16 Dec 2015
-- Pupose : select Institute Name remove Branch ID
-- =============================================
CREATE PROCEDURE [dbo].[BindInstituteName_SP] 
AS
BEGIN
Select 'Select' As InstituteName
Union 
	SELECT Distinct(InstituteName) FROM Branch where IsActive=1
END
GO
/****** Object:  StoredProcedure [dbo].[SearchBranch_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sameer Shinde
-- Create date: 6 Nov 2015
-- Description:	search Branch
-- =============================================
CREATE PROCEDURE [dbo].[SearchBranch_SP] --'j'
	-- Add the parameters for the stored procedure here
	@BranchName NVARCHAR(50)
AS
BEGIN
	SELECT BranchName,InstituteName, BranchCode,case when IsActive =1  then 'Active' 
	when IsActive = 0 then 'InActive' end as [Status] FROM Branch
	WHERE IsDeleted<>'True'
	AND (BranchName Like '%'+@BranchName+'%' OR InstituteName LIKE '%'+@BranchName+'%' )
	
END
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NOT NULL,
	[ContactNo] [nvarchar](10) NOT NULL,
	[Address] [nvarchar](max) NOT NULL,
	[EmailID] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[UserTypeID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [UserID] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherBranch]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherBranch](
	[TeacherBranchID] [int] IDENTITY(1,1) NOT NULL,
	[TeacherID] [int] NOT NULL,
	[BranchID] [int] NOT NULL,
	[NoOfSubject] [int] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[UpdatedByUserID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [TeacherBranchID] PRIMARY KEY CLUSTERED 
(
	[TeacherBranchID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeacherAvailable]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherAvailable](
	[TeacherAvailableID] [int] IDENTITY(1,1) NOT NULL,
	[Day] [nvarchar](15) NOT NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[TeacherID] [int] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[UpdatedByUserID] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [TeacherAvailableID] PRIMARY KEY CLUSTERED 
(
	[TeacherAvailableID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoomAvailable]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoomAvailable](
	[RoomAvailableID] [int] IDENTITY(1,1) NOT NULL,
	[Day] [nvarchar](15) NOT NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[RoomID] [int] NOT NULL,
	[CreatedByUserID] [int] NULL,
	[UpdatedByUserID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_RoomAvailable] PRIMARY KEY CLUSTERED 
(
	[RoomAvailableID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SaveRoom_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Pranjali
-- Create date: 05/11/2015
-- Description:	To save Room Details 
-- =============================================
CREATE PROCEDURE [dbo].[SaveRoom_SP]
(
	 @RoomID int,
	 @RoomName nvarchar(50),
	 @RoomShortName nvarchar(50),
	 @Color nvarchar(50),
	 @Capacity int,
	 @BranchID int,
	 @UpdatedByUserID int,
	 @UpdatedDate nvarchar(50),
	 @IsActive int,
	 @IsDeleted int,
	 @MaxLectDay int,
	 @MaxLectWeek int,
	 @MaxLectRow int,
	 @STime nvarchar(50),
	 @ETime nvarchar(50),
	 @IsAllow int
 )
AS
DECLARE @msg NVARCHAR(50),@Output int =0
BEGIN

if(@RoomID=0)--Check for Edit Or Update 0 for new entry and onther no update
	begin
		if not exists(select RoomName from BranchesRooms where RoomName=@RoomName AND BranchID=@BranchID)
		  BEGIN
			 IF NOT EXISTS (select RoomID FROM [BranchesRooms]  Where RoomShortName =@RoomShortName AND BranchID=@BranchID)
			   BEGIN-- insert data
				  insert into BranchesRooms(RoomName,RoomShortName,RoomColor,Capacity,BranchID,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive,MaxNoLecturesDay,MaxNoLecturesWeek,IsAllowMoreThanOneLectInBatch,MaxNoOfLectureInRow,FreeTimeStart,FreeTimeEnd,IsDeleted)
				  values(@RoomName,@RoomShortName,@Color,@Capacity,@BranchID,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@UpdatedDate,@IsActive,@MaxLectDay,@MaxLectWeek,@IsAllow,@MaxLectRow,@STime,@ETime,@IsDeleted)
				   set @Output = (select (MAX(RoomID)) from BranchesRooms)
				  IF(@@ROWCOUNT=1)-- check row effected or not
					 BEGIN
					    exec SaveLog_SP 'Room Inserted Successfully',@UpdatedDate,'Room',@RoomID
					    IF (@@ROWCOUNT=1)--Check Row Effected or Not
					      begin
						     set @msg= (SELECT [Message] FROM [Messages] where MessageID=1)
						  end
				     END
				  ELSE
				     BEGIN
						exec SaveLog_SP 'Error To Save Details.',@UpdatedDate,'Room',@RoomID --Enter in Log Table
						IF (@@ROWCOUNT=1)--Check Row Effected Or Not
					       BEGIN
						       SET @msg = (SELECT [Message] FROM [Messages] where MessageID=2)
					       END
			         END
			    END     
		    ELSE --error for Duplicate Short Name
		        BEGIN
				EXEC SaveLog_SP 'Room Short Name Duplication',@UpdatedDate,'Room',@RoomID--Enter in Log Table
					IF (@@ROWCOUNT=1)
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=4)--Set Message To Return
						END
				   END
		  END
	ELSE--Error for Duplicate Room Name
				BEGIN
					EXEC SaveLog_SP 'Room Name Duplication',@UpdatedDate,'Room',@RoomID--Enter in Log Table
					IF (@@ROWCOUNT=1)
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=17)--Set Message To Return
						END
				END
	END
else
	Begin
	if not exists(select RoomName from BranchesRooms where  RoomName=@RoomName  AND RoomID <> @RoomID and BranchID= @BranchID)
	   BEGIN
		  IF NOT EXISTS (SELECT RoomID FROM [BranchesRooms]  Where RoomShortName=@RoomShortName AND RoomID <> @RoomID and BranchID= @BranchID )--Check Room Short Name Available for other Than that RoomID	
		     BEGIN --Update SP
		         update BranchesRooms set RoomName = @RoomName,RoomShortName = @RoomShortName,RoomColor=@Color,Capacity=@Capacity,BranchID=@BranchID,UpdatedByUserID=@UpdatedByUserID,UpdatedDate= @UpdatedDate,IsActive=@IsActive,IsDeleted =@IsDeleted,MaxNoLecturesDay=@MaxLectDay,MaxNoLecturesWeek=@MaxLectWeek,IsAllowMoreThanOneLectInBatch=@IsAllow,MaxNoOfLectureInRow=@MaxLectRow,FreeTimeStart=@STime,FreeTimeEnd=@ETime 
		         where RoomID = @RoomID
		         set @Output = @RoomID
			     IF(@@ROWCOUNT=1)-- Check Row Effected or Not
			         BEGIN
						EXEC SaveLog_SP 'Room Updated Sucessfully',@UpdatedDate,'Room',@RoomID --Entry in Log Table
						IF (@@ROWCOUNT=1)--Check Row Effected Or Not
					          BEGIN
						          set @msg= (SELECT [Message] FROM [Messages] where MessageID=5)
					          END
					 END  
			  END       
	     ELSE--Short Name Duplicateion
			BEGIN
			    EXEC SaveLog_SP 'Room Short Name Duplication',@UpdatedDate,'Room',@RoomID --Entry in Log Table
				IF (@@ROWCOUNT=1)
					 BEGIN
						SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=4)--Set Message
					 END		
			END
		END
	ELSE
		BEGIN
			EXEC SaveLog_SP 'Room Name Duplication',@UpdatedDate,'Room',@RoomID --Entery In Log Table
			IF (@@ROWCOUNT=1)--Check row Effected
				BEGIN
					SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=17)--set Message
				END
		END
			
			
  END
		
SELECT @Output
	
END
GO
/****** Object:  StoredProcedure [dbo].[LoadClassName_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 05-11-2015
-- Description:	To Bind ClassName
-- =============================================
CREATE PROCEDURE [dbo].[LoadClassName_SP] 
	
AS
BEGIN
	select 0 as ClassID,'Select' as ClassName
	union
	SELECT ClassID,ClassName  from [Class] WHERE IsDeleted<>'True' And IsActive=1	
END
GO
/****** Object:  StoredProcedure [dbo].[SaveTeacherAvailable_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 07 Nov 2015
-- Description:	Save Teacher Availibility Details
-- =============================================
CREATE PROCEDURE [dbo].[SaveTeacherAvailable_SP]-- 5,Mon,'9:00:00','16:00:00',1,'2015-11-17',1,0
	(
	
	@TeacherID int,
	@Day NVARCHAR(50),
	@StartTime NVARCHAR(50),
	@EndTime NVARCHAR(50),
	@UpdatedByUserID int,
	@UpdatedDate NVARCHAR(50),
	@IsActive int,
	@IsDeleted int
	)
AS
DECLARE @msg NVARCHAR(50)
DECLARE @MaxID int
BEGIN
	IF NOT EXISTS (SELECT TeacherAvailableID FROM TeacherAvailable WHERE TeacherID=@TeacherID AND [Day]=@Day)
		BEGIN
			INSERT INTO TeacherAvailable(TeacherID,[Day],StartTime,EndTime,CreatedByUserID,UpdatedByUserID,UpdatedDate,IsActive,IsDeleted)
			VALUES (@TeacherID,@Day,@StartTime,@EndTime,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@IsActive,@IsDeleted)
			IF(@@ROWCOUNT=1)
				BEGIN
					SELECT @MaxID=(SELECT MAX(TeacherAvailableID) FROM TeacherAvailable)
					EXEC SaveLog_SP 'Save Teacher Availibility.',@UpdatedDate,'TeacherAvailable',@MaxID 
					set @msg=(SELECT [Message] FROM [Messages] WHERE MessageID=1)
				END
			ELSE
				BEGIN
					SELECT @MaxID=(SELECT MAX(TeacherAvailableID) FROM TeacherAvailable)
					EXEC SaveLog_SP ' Error To Save Teacher Availibility.',@UpdatedDate,'TeacherAvailable',@MaxID 
					set @msg=(SELECT [Message] FROM [Messages] WHERE MessageID=2)
				END
			
		END
	ELSE
		BEGIN
			UPDATE TeacherAvailable SET StartTime=@StartTime,EndTime=@EndTime,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate,IsActive=@IsActive,IsDeleted=@IsDeleted
			WHERE [Day]=@Day AND TeacherID=@TeacherID
			IF(@@ROWCOUNT=1)
				BEGIN
					SELECT @MaxID=(SELECT TeacherAvailableID  FROM TeacherAvailable WHERE TeacherID=@TeacherID AND [DAY]=@Day)
					EXEC SaveLog_SP 'Update Teacher Availibility.',@UpdatedDate,'TeacherAvailable',@MaxID 
					set @msg=(SELECT [Message] FROM [Messages] WHERE MessageID=5)
				END
			ELSE
				BEGIN
					SELECT @MaxID=(SELECT TeacherAvailableID  FROM TeacherAvailable WHERE TeacherID=@TeacherID AND [DAY]=@Day)
					EXEC SaveLog_SP 'Error To Update Teacher Availibility.',@UpdatedDate,'TeacherAvailable',@MaxID 
					set @msg=(SELECT [Message] FROM [Messages] WHERE MessageID=2)
				END
			
		
		END
		SELECT @msg
		
END
GO
/****** Object:  StoredProcedure [dbo].[SaveTeacher_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 07 Nov 2015
-- Description:	Save And Update teacher Main Data
-- =============================================
									  --0,'PriTesh','Sortee','PDS',2,4,5,1,5,1,0,'5:50','6:50',1,'2015-11-05',1,0
CREATE PROCEDURE [dbo].[SaveTeacher_SP] --0,'Pranjali','Vidhate','PV',2,1,10,3,1,1,'00:00:00','00:00:00',1,'2015-07-12',1,0
	(
			@TeacherID int ,
            @TeacherName NVARCHAR(MAX),
            @TeacherSurname NVARCHAR(MAX),
            @TeacherShortName NVARCHAR(MAX),
            @MaxNoOfMovesInBranch int,
            @MaxLecturePerDay int,
            @MaxLectPerWeek int,
            @IsMoreThanOneLecture int,
            @MaxNoOfLectInRow int ,
            @IsFirstLecture int,
            @IsLastLecture int,
            @FreeTimeStart NVARCHAR(50),
            @FreeTimeEnd NVARCHAR(50),
            @UpdatedByUserID int,
            @UpdatedDate NVARCHAR(50),
            @Active int,
            @IsDeleted int
	)
	
	
AS
DECLARE @msg NVARCHAR(MAX)
DECLARE @MAXTeacherID int=0
BEGIN
	IF (@TeacherID =0)
		BEGIN
			IF NOT EXISTS(SELECT TeacherID From Teacher Where TeacherShortName=@TeacherShortName)--Teacher Short Name Exists Or NOt
				BEGIN
					INSERT INTO Teacher (TeacherName,TeacherSurname,TeacherShortName,NoOfMovesInBranch,MaxNoLecturesDay,MaxNoLectureWeek,IsAllowMoreThanOneLectInBatch,MaxNoOfLectureInRow,IsFirstLect,IsLastLect,FreeTimeStart,FreeTimeEnd,IsActive,IsDeleted,CreatedByUserID,UpadatedByUserID,CreatedDate,UpdatedDate)
					VALUES (@TeacherName,@TeacherSurname,@TeacherShortName,@MaxNoOfMovesInBranch,@MaxLecturePerDay,@MaxLectPerWeek,@IsMoreThanOneLecture,@MaxNoOfLectInRow,@IsFirstLecture,@IsLastLecture,@FreeTimeStart,@FreeTimeEnd,@Active,@IsDeleted,@UpdatedByUserID,@UpdatedByUserID,Convert(datetime,@UpdatedDate),CONVERT(datetime,@UpdatedDate))
					SET @MAXTeacherID=(Select MAX(TeacherID) From Teacher)
					IF(@@ROWCOUNT=1)--Chaeck whether Value Inserted SucessfullyOrNot in Table
						BEGIN							
							EXEC SaveLog_SP 'Teacher Inserted SucessFully',@UpdatedDate,'Teacher',@TeacherID
							IF(@@ROWCOUNT=1)--Chaeck whether Value Inserted SucessfullyOrNot in Table
								BEGIN
									SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=1 )
								END		
						END
					ELSE--Not Inserted values
						BEGIN							
							EXEC SaveLog_SP 'Error To Insert Teacher',@UpdatedDate,'Teacher',@TeacherID
							IF(@@ROWCOUNT=1)--Chaeck whether Value Inserted SucessfullyOrNot in Table
								BEGIN
									SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=2 )
								END		
						END
					
					
				END
			ELSE--Short Name Duplicate
				BEGIN
					EXEC SaveLog_SP 'Teacher Short Name Duplication',@UpdatedDate,'Teacher',@TeacherID
					IF(@@ROWCOUNT=1)
						BEGIN
							SET @msg='Teacher Short Name Already Exists.'
						END
				END
		END
	ELSE
		BEGIN
			IF NOT EXISTS(SELECT TeacherID FROM Teacher WHERE TeacherShortName=@TeacherShortName AND TeacherID<>@TeacherID)		
				BEGIN
					UPDATE Teacher SET TeacherName=@TeacherName,TeacherSurname=@TeacherSurname,TeacherShortName=@TeacherShortName,NoOfBranches=@MaxNoOfMovesInBranch,MaxNoLecturesDay=@MaxLecturePerDay,MaxNoLectureWeek=@MaxLectPerWeek,IsAllowMoreThanOneLectInBatch=@IsMoreThanOneLecture,MaxNoOfLectureInRow=@MaxNoOfLectInRow,IsFirstLect=@IsFirstLecture,IsLastLect=@IsLastLecture,FreeTimeStart=@FreeTimeStart,FreeTimeEnd=@FreeTimeEnd,IsActive=@Active,IsDeleted=@IsDeleted,UpadatedByUserID=@UpdatedByUserID,UpdatedDate=Convert(datetime,@UpdatedDate)
					WHERE TeacherID=@TeacherID
					SET @MAXTeacherID=@TeacherID
					IF(@@ROWCOUNT=1)
						BEGIN							
							EXEC SaveLog_SP 'Teacher Updated SucessFully',@UpdatedDate,'Teacher',@TeacherID
							IF(@@ROWCOUNT=1)
								BEGIN
									SET @msg=(SELECT [Message] FROM [Messages] Where MessageID=5)--Set message
								END
							END
							ELSE
								BEGIN									
									EXEC SaveLog_SP 'Error To Update',@UpdatedDate,'Teacher',@TeacherID
									IF(@@ROWCOUNT=1)
										BEGIN
											SET @msg=(SELECT [Message] FROM [Messages] Where MessageID=4)--Set message
										END
								END									
						
					
			END
			ELSE--Short Name Duplication
				BEGIN					
					EXEC SaveLog_SP 'Teacher Short Name Duplication',@UpdatedDate,'Teacher',@TeacherID
					IF(@@ROWCOUNT=1)
						BEGIN
							SET @msg='Teacher Short Name Already Exists.'
						END
				END
			
		END
		SELECT @MAXTeacherID
END
GO
/****** Object:  StoredProcedure [dbo].[SaveSubject_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 11 Nov 2015
-- Description:	Save AND Update Subject
-- =============================================
CREATE PROCEDURE [dbo].[SaveSubject_SP] --21,'History','Hsty',1,'2015-12-03',1,0
	(
	@SubjectID int,
	@SubjectName nvarchar(50),
	@SubjectShortName nvarchar(50),
	@UpdatedByUserID int,
	@UpdatedDate nvarchar(50),
	@IsActive int,
	@IsDeleted int
	)
AS
DECLARE @msg nvarchar(MAX)
BEGIN
	IF(@SubjectID=0)--Check for Edit Or Update 0 for new entry and onther no update
		BEGIN
			IF NOT EXISTS (SELECT SubjectID FROM [Subject] Where SubjectName=@SubjectName and IsDeleted = 0)--Check Whether given name Already exist or not
				BEGIN
					IF NOT EXISTS (SELECT SubjectID FROM [Subject] Where SubjectShortName=@SubjectShortName and IsDeleted=0) --Check Whether Short Neame already Exists Or Not
						BEGIN-- Insert into Data into Subject Table
							INSERT INTO [Subject] (SubjectName,SubjectShortName,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive,IsDeleted)
							VALUES (@SubjectName,@SubjectShortName,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@UpdatedDate,@IsActive,@IsDeleted)
							IF (@@ROWCOUNT=1)--Check Row effected Or not
								BEGIN
									EXEC SaveLog_SP 'Subject Inserted Sucessfully.',@UpdatedDate,'Subject',@SubjectID --Enter in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected or Not
										BEGIN
											SET @msg=(SELECT [Message]	FROM [Messages] WHERE MessageID=1)--Set Message to return
										END
								END
							ELSE
								BEGIN
									EXEC SaveLog_SP 'Error To Save Details.',@UpdatedDate,'Subject',@SubjectID --Enter in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected Or Not
										BEGIN
											SET @msg=(SELECT [Message]	FROM [Messages] WHERE MessageID=2)--Set Message To Return
										END
								END
						END
					ELSE--error for Duplicate Short Name
						BEGIN
						EXEC SaveLog_SP 'Subject Short Name Duplication',@UpdatedDate,'Subject',@SubjectID--Enter in Log Table
							IF (@@ROWCOUNT=1)
								BEGIN
									SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=4)--Set Message To Return
								END
						END
				END
			ELSE--Error for Duplicate Subject Name
				BEGIN
					EXEC SaveLog_SP 'Subject Name Duplication',@UpdatedDate,'Subject',@SubjectID--Enter in Log Table
					IF (@@ROWCOUNT=1)
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=3)--Set Message To Return
						END
				END
		END
	ELSE
		BEGIN
			IF NOT EXISTS (SELECT SubjectID FROM [Subject] Where SubjectName=@SubjectName AND SubjectID <> @SubjectID and IsActive = 0 and IsDeleted=1)--Check Whether Subject Name Exist other Than SubjectID
				BEGIN
					IF NOT EXISTS (SELECT SubjectID FROM [Subject] Where SubjectShortName=@SubjectShortName AND SubjectID <> @SubjectID and IsActive='False'  and IsDeleted='True' )--Check Subject Short Name Available for other Than that subject ID
						BEGIN--UPDATE SP
							UPDATE [Subject] SET SubjectName=@SubjectName,SubjectShortName=@SubjectShortName,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate,IsActive=@IsActive,IsDeleted=@IsDeleted
							WHERE SubjectID=@SubjectID
							IF(@@ROWCOUNT=1)--Check Row Effected or Not
								BEGIN
									EXEC SaveLog_SP 'Subject Updated Sucessfully',@UpdatedDate,'Subject',@SubjectID--Entry in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected Or Not
										BEGIN
											SET @msg =(SELECT [Message] FROM [Messages] Where MessageID=5)--Set message
										END
								END
					
						END
					ELSE--Short Name Duplicateion
						BEGIN
							EXEC SaveLog_SP 'Short Name Duplication',@UpdatedDate,'Subject',@SubjectID--Entry in Log Table
							IF (@@ROWCOUNT=1)
								BEGIN
									SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=4)--Set Message
								END		
						END
				END
			ELSE
				BEGIN
					EXEC SaveLog_SP 'Subject Name Duplication',@UpdatedDate,'Subject',@SubjectID--Entery In Log Table
					IF (@@ROWCOUNT=1)--Check row Effected
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=3)--set Message
						END
				END
			
			
		END
		
	SELECT @msg
	
END
GO
/****** Object:  StoredProcedure [dbo].[SaveUser_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kalpesh Katyare
-- Create date: 06 Nov 2015
-- Description:	Save AND Update User
-- =============================================
CREATE PROCEDURE [dbo].[SaveUser_SP] 
	( 
	@UserID int,
	@UserName nvarchar(50),
	@ContactNo nvarchar(50),
	@Address nvarchar(50),
	@MailId nvarchar(50),
	@LoginName nvarchar(50),
	@Password nvarchar(50),
	@UserTypeID int,
	@UpdatedDate nvarchar(50),
	@IsActive int,
	@IsDeleted int
	)
AS
DECLARE @msg nvarchar(MAX)
BEGIN
	IF(@UserID=0)--Check for Edit Or Update 0 for new entry and onther no update
		BEGIN
			IF NOT EXISTS (SELECT UserID FROM [User] Where FullName=@UserName and IsActive =1)--Check Whether given name Already exist or not
				BEGIN
					IF NOT EXISTS (SELECT UserID FROM [User] Where UserName=@LoginName and IsActive =1) --Check Whether Short Neame already Exists Or Not
						BEGIN-- Insert into Data into User Table
							INSERT INTO [User] (FullName,ContactNo,[Address],EmailID,UserName,[Password],CreatedDate,UpdatedDate,UserTypeID,IsActive,IsDeleted)
							VALUES (@UserName,@ContactNo,@Address,@MailId,@LoginName,@Password, @UpdatedDate,@UpdatedDate,@UserTypeID,@IsActive,@IsDeleted)
							IF (@@ROWCOUNT=1)--Check Row effected Or not
								BEGIN
									EXEC SaveLog_SP 'User Inserted Sucessfully.',@UpdatedDate,'User',@UserID --Enter in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected or Not
										BEGIN
											SET @msg=(SELECT [Message]	FROM [Messages] WHERE MessageID=1)--Set Message to return
										END
								END
							ELSE
								BEGIN
									EXEC SaveLog_SP 'Error To Save Details.',@UpdatedDate,'User',@UserID --Enter in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected Or Not
										BEGIN
											SET @msg=(SELECT [Message]	FROM [Messages] WHERE MessageID=16)--Set Message To Return
										END
								END
						END
					ELSE--error for Duplicate Short Name
						BEGIN
						EXEC SaveLog_SP 'User Login Name Duplication',@UpdatedDate,'User',@UserID--Enter in Log Table
							IF (@@ROWCOUNT=1)
								BEGIN
									SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=26)--Set Message To Return
								END
						END
				END
			ELSE--Error for Duplicate User Name
				BEGIN
					EXEC SaveLog_SP 'User Full Name Duplication',@UpdatedDate,'User',@UserID--Enter in Log Table
					IF (@@ROWCOUNT=1)
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=3)--Set Message To Return
						END
				END
		END
	ELSE
		BEGIN
			IF NOT EXISTS (SELECT UserID FROM [User] Where FullName=@UserName AND UserID <> @UserID)--Check Whether User Name Exist other Than UserID
				BEGIN
					IF NOT EXISTS (SELECT UserID FROM [User] Where UserName=@LoginName AND UserID <> @UserID )--Check User Short Name Available for other Than that User ID
						BEGIN--UPDATE SP
							UPDATE [User] SET FullName=@UserName,ContactNo=@ContactNo,[Address]=@Address,EmailID=@MailId,UserName=@LoginName,[Password]=@Password,UserTypeID=@UserTypeID,UpdatedDate=@UpdatedDate,IsActive=@IsActive,IsDeleted=@IsDeleted
							WHERE UserID=@UserID
							IF(@@ROWCOUNT=1)--Check Row Effected or Not
								BEGIN
									EXEC SaveLog_SP 'User Updated Sucessfully',@UpdatedDate,'User',@UserID--Entry in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected Or Not
										BEGIN
											SET @msg =(SELECT [Message] FROM [Messages] Where MessageID=5)--Set message
										END
								END
						END
					ELSE--Short Name Duplicateion
						BEGIN
							EXEC SaveLog_SP 'UserName Duplication',@UpdatedDate,'User',@UserID--Entry in Log Table
							IF (@@ROWCOUNT=1)
								BEGIN
									SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=26)--Set Message
								END		
						END
				END
			ELSE
				BEGIN
					EXEC SaveLog_SP 'FullName Duplication',@UpdatedDate,'User',@UserID--Entery In Log Table
					IF (@@ROWCOUNT=1)--Check row Effected
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=3)--set Message
						END
				END
		END
	SELECT @msg
END
GO
/****** Object:  StoredProcedure [dbo].[BindClass_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 05-11-2015
-- Description:	Get Details To bind Drop Down
-- =============================================
CREATE PROCEDURE [dbo].[BindClass_SP] --18
(
	@BranchID int
	--@ClassName nvarchar(50)
)
AS
BEGIN
Select b.BranchName,ClassName,ClassShortName,Board,Color,c.BranchID,c.IsActive,c.IsDeleted,
case when c.IsActive ='True'  then 'Active' 
	when c.IsActive ='False' then 'InActive' end as [Status] from [Class] c
inner join Branch b
on b.BranchID=c.BranchID
where c.BranchID like case when @BranchID <>0 then @BranchID else CONVERT (NVARCHAR(50),ClassID)END
--AND c.ClassName LIKE CASE WHEN @ClassName<>'' THEN '%'+@ClassName+'%' ELSE CONVERT(NVARCHAR(50),c.ClassName)END
AND c.IsDeleted = 0
order by ClassName
END
GO
/****** Object:  StoredProcedure [dbo].[BindDistance_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Pranjali S Vidhate
-- Create date: 25/11/2015
-- Description:	To Bind disatance In Branch 
-- =============================================
CREATE PROCEDURE [dbo].[BindDistance_SP] --15,21,18
(
  @BranchDistanceID int,
  @FromBranchID int,
  @ToBranchID int
)

AS
BEGIN
if Exists(SELECT BranchDistanceID FROM BranchDistance where From_BranchID=@FromBranchID AND To_BranchID=@ToBranchID AND IsDeleted=0)
BEGIN
	 select bd.BranchDistanceID ,br.BranchName as FromBranch,br2.BranchName as ToBranch,bd.DistanceTime,bd.From_BranchID,bd.To_BranchID,
	 case WHEN bd.IsActive ='True' AND bd.IsDeleted='False' Then 'Active' 
	 WHEN bd.IsActive='False' AND bd.IsDeleted='False' THEN 'InActive'
	  END AS 'Status',
	 bd.IsActive,bd.IsDeleted
	 
	  from BranchDistance bd
     inner join Branch br 
     on br.BranchID = bd.From_BranchID	
     inner join Branch br2
     on br2.BranchID =bd.To_BranchID	
	 where bd.BranchDistanceID LIKE CASE WHEN @BranchDistanceID <>0 THEN @BranchDistanceID ELSE CONVERT (NVARCHAR(50),bd.BranchDistanceID) END
     AND bd.From_BranchID LIKE CASE WHEN @FromBranchID <>0 THEN @FromBranchID ELSE CONVERT (NVARCHAR(50),bd.From_BranchID) END
     AND bd.To_BranchID LIKE CASE WHEN @ToBranchId <>0 THEN @ToBranchId ELSE CONVERT (NVARCHAR(50),bd.To_BranchID) END
     and bd.IsDeleted =0 AND br.IsActive=1 AND br2.IsActive=1
 END
 ELSE  IF EXISTS(SELECT BranchDistanceID FROM BranchDistance where From_BranchID= @ToBranchId AND To_BranchID= @FromBranchId AND IsDeleted=0)
	BEGIN
	select bd.BranchDistanceID ,br2.BranchName as FromBranch,br.BranchName as ToBranch,bd.DistanceTime,bd.From_BranchID,bd.To_BranchID,
	 case WHEN bd.IsActive ='True' AND bd.IsDeleted='False' Then 'Active' 
	 WHEN bd.IsActive='False' AND bd.IsDeleted='False' THEN 'InActive'
	  END AS 'Status',
	 bd.IsActive, bd.IsDeleted
	 
	  from BranchDistance bd
     inner join Branch br 
     on br.BranchID = bd.To_BranchID
     inner join Branch br2
     on br2.BranchID =	bd.From_BranchID	
	 where bd.BranchDistanceID LIKE CASE WHEN @BranchDistanceID <>0 THEN @BranchDistanceID ELSE CONVERT (NVARCHAR(50),bd.BranchDistanceID) END
	 AND bd.From_BranchID LIKE CASE WHEN @ToBranchID <>0 THEN @ToBranchID ELSE CONVERT (NVARCHAR(50),bd.From_BranchID) END
     AND bd.To_BranchID LIKE CASE WHEN @FromBranchID <>0 THEN @FromBranchID  ELSE CONVERT (NVARCHAR(50),bd.To_BranchID) END
     and bd.IsDeleted =0 AND br.IsActive=1 AND br2.IsActive=1	
	END
	
	
	ELSE
	BEGIN
	 select bd.BranchDistanceID ,br.BranchName as FromBranch,br2.BranchName as ToBranch,bd.DistanceTime,bd.From_BranchID,bd.To_BranchID,
	 case WHEN bd.IsActive ='True' AND bd.IsDeleted='False' Then 'Active' 
	 WHEN bd.IsActive='False' AND bd.IsDeleted='False' THEN 'InActive'
	  END AS 'Status',
	 bd.IsActive,bd.IsDeleted
	 
	  from BranchDistance bd
     inner join Branch br 
     on br.BranchID = bd.From_BranchID	
     inner join Branch br2
     on br2.BranchID =bd.To_BranchID	
	 where bd.BranchDistanceID LIKE CASE WHEN @BranchDistanceID <>0 THEN @BranchDistanceID ELSE CONVERT (NVARCHAR(50),bd.BranchDistanceID) END
     AND bd.From_BranchID LIKE CASE WHEN @FromBranchID <>0 THEN @FromBranchID ELSE CONVERT (NVARCHAR(50),bd.From_BranchID) END
     AND bd.To_BranchID LIKE CASE WHEN @ToBranchId <>0 THEN @ToBranchId ELSE CONVERT (NVARCHAR(50),bd.To_BranchID) END
     and bd.IsDeleted =0 AND br.IsActive=1 AND br2.IsActive=1
   END
   
END
GO
/****** Object:  Table [dbo].[BranchLectureDetail]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BranchLectureDetail](
	[BranchLectureDetailID] [int] IDENTITY(1,1) NOT NULL,
	[BranchLectureID] [int] NOT NULL,
	[LectureStartTime] [time](7) NULL,
	[LectureEndTime] [time](7) NULL,
	[IsActive] [bit] NULL,
	[IsDelete] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[CreatedByUserID] [int] NULL,
	[UpdatedByUserID] [int] NULL,
 CONSTRAINT [PK_BranchLectureDetail] PRIMARY KEY CLUSTERED 
(
	[BranchLectureDetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[BindBranchClass_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 19 nov 2015
-- Description:	Bind Class name on brach
-- =============================================
CREATE PROCEDURE [dbo].[BindBranchClass_SP] ---1
	(
	@BranchID int = 0
	)
	
AS
BEGIN
SELECT 0 AS ClassID,'Select' AS ClassName
UNION
	SELECT ClassID,ClassName FROM [Class]
	WHERE BranchID LIKE CASE WHEN @BranchID<>0 THEN @BranchID ELSE CONVERT (NVARCHAR(50),BranchID)END
	AND IsActive='True' AND IsDeleted='False'
	ORDER BY ClassName
END
GO
/****** Object:  StoredProcedure [dbo].[BindClassName_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 05-11-2015
-- Description:	To Bind ClassName
-- =============================================
CREATE PROCEDURE [dbo].[BindClassName_SP] 
	(
	@BranchID int	
 	)
AS
BEGIN
	SELECT 0 AS ClassID,'Select' AS ClassName
	Union
	SELECT c.ClassID,c.ClassName  from [Class] c
	inner join Branch br
	on br.BranchID = c.BranchID
	where
	br.BranchID like case when @BranchID <> 0 then @BranchID else CONVERT(nvarchar(50),@BranchID)end
	  and c.IsActive=1 AND c.IsDeleted='False'
	  ORDER BY ClassName

END
GO
/****** Object:  StoredProcedure [dbo].[BindRoomName_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pranjali
-- Create date: 20-11-2015
-- Description:	To bind room name on dropdown
-- =============================================
CREATE PROCEDURE [dbo].[BindRoomName_SP]	
	(
	@BranchID int	
 	)
AS
BEGIN
	
	SELECT 0 AS RoomID,'Select' AS RoomName 
UNION
 SELECT rm.RoomID,rm.RoomName FROM BranchesRooms rm
 INNER JOIN Branch br
 ON br.BranchID=rm.BranchID
 WHERE 
 br.BranchID LIKE CASE WHEN @BranchID<>0 THEN @BranchID ELSE CONVERT(NVARCHAR(50),@BranchID) END 
AND br.IsActive=1 AND br.IsDeleted='False'	
ORDER BY RoomName
    
END
GO
/****** Object:  Table [dbo].[Batches]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Batches](
	[BatchID] [int] IDENTITY(1,1) NOT NULL,
	[BatchName] [nvarchar](max) NOT NULL,
	[BatchCode] [nvarchar](10) NOT NULL,
	[ClassID] [int] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[UpdatedByUserID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LectureDuration] [int] NOT NULL,
	[IsLunchBreak] [bit] NOT NULL,
	[LunchBreakStartTime] [nvarchar](50) NULL,
	[LunchBreakEndTime] [nvarchar](50) NULL,
	[MaxNoLecturesDay] [int] NULL,
	[MaxNoLecturesWeek] [int] NULL,
	[IsAllowMoreThanOneLectInBatch] [bit] NULL,
	[MaxNoOfLecureInRow] [int] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [BatchID] PRIMARY KEY CLUSTERED 
(
	[BatchID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SearchClass_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 06-11-2015
-- Description:	for Search Class by class name
-- =============================================
CREATE PROCEDURE [dbo].[SearchClass_SP] --'cc' 	
	@ClassName NVARCHAR(50)
AS
BEGIN
	SELECT b.BranchName,c.ClassName,ClassShortName,Board,Color,c.BranchID,
	case when c.IsActive ='True'  then 'Active' 
	when c.IsActive ='False' then 'InActive' end as [Status] FROM [Class] c
	inner join Branch b
	on b.BranchID = c.BranchID
	where  c.IsDeleted<>'True'
	AND (c.ClassName Like '%'+@ClassName+'%' OR c.ClassShortName LIKE '%'+@ClassName+'%' )
END
GO
/****** Object:  StoredProcedure [dbo].[SaveClass_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 04-11-2015
-- Description:	Class form save and update code
-- =============================================
CREATE PROCEDURE [dbo].[SaveClass_SP]--0,'ddfddd','kjj','CBSC Board','red',4,1,'2015-11-17',1,0
(
@ClassID int,
@ClassName nvarchar(50),
@ClassShortName nvarchar(50),
@Board nvarchar(20),
@Color nvarchar(20),
@BranchID int,
@UpdatedByUserID int,
@UpdatedDate nvarchar(50),
@IsActive int,
@IsDeleted int

 )	
	AS
	DECLARE @msg nvarchar(MAX)
	BEGIN
	if(@ClassID=0)--Check for Edit Or Update 0 for new entry and onther no update
		BEGIN
			IF NOT EXISTS (select ClassID FROM [Class] Where ClassName=@ClassName and BranchID = @BranchID  and IsDeleted=0)--Check Whether given name Already exist or not
				BEGIN
					IF NOT EXISTS (select ClassID FROM [Class] Where ClassShortName=@ClassShortName and BranchID = @BranchID and IsDeleted=0) --Check Whether Short Neame already Exists Or Not
						BEGIN-- Insert into Data into Class Table
							INSERT INTO [Class](ClassName,ClassShortName,Board,Color,BranchID,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive,IsDeleted)
							Values (@ClassName,@ClassShortName,@Board,@Color,@BranchID,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@UpdatedDate,@IsActive,@IsDeleted)
							IF (@@ROWCOUNT=1)--Check Row effected Or not
								BEGIN
									exec SaveLog_SP 'Class Inserted Successfully',@UpdatedDate,'Class',@ClassID
									IF (@@ROWCOUNT=1)--Check Row Effected or Not
										BEGIN
											set @msg=(select[Message]from [Messages]WHERE MessageID=1)--Set Message To Return	
										END
								END
							ELSE
								BEGIN
									exec SaveLog_SP 'Error To Save Details.',@UpdatedDate,'Class',@ClassID --Enter in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected Or Not
										BEGIN
											SET @msg=(SELECT [Message]	FROM [Messages] WHERE MessageID=2)--Set Message To Return
										END
								END
						END
					ELSE--error for Duplicate Short Name
						BEGIN
						EXEC SaveLog_SP 'Class Short Name Duplication',@UpdatedDate,'Class',@ClassID--Enter in Log Table
							IF (@@ROWCOUNT=1)
								BEGIN
									SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=4)--Set Message To Return
								END
						END
				END
			ELSE--Error for Duplicate Class Name
				BEGIN
					EXEC SaveLog_SP 'Class Name Duplication',@UpdatedDate,'Class',@ClassID--Enter in Log Table
					IF (@@ROWCOUNT=1)
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=11)--Set Message To Return
						END
				END
		END
	ELSE
		BEGIN
			IF NOT EXISTS (SELECT @ClassID FROM [Class] Where ClassName=@ClassName AND ClassID <> @ClassID and BranchID = @BranchID and IsActive='True'  and IsDeleted='False')--Check Whether Subject Name Exist other Than SubjectID
				BEGIN
					IF NOT EXISTS (SELECT ClassID FROM [Class] Where ClassShortName=@ClassShortName AND ClassID <> @ClassID and BranchID =@BranchID and IsActive='True'  and IsDeleted='False')--Check Subject Short Name Available for other Than that subject ID
						BEGIN--UPDATE SP
							UPDATE [Class] SET ClassName=@ClassName,ClassShortName=@ClassShortName,Board=@Board,Color=@Color,BranchID=@BranchID,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate,IsActive=@IsActive,IsDeleted=@IsDeleted
							WHERE ClassID=@ClassID
							IF(@@ROWCOUNT=1)--Check Row Effected or Not
								BEGIN
									EXEC SaveLog_SP 'Class Updated Sucessfully',@UpdatedDate,'Class',@ClassID--Entry in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected Or Not
										BEGIN
											SET @msg =(SELECT [Message] FROM [Messages] Where MessageID=5)--Set message
										END
								END
					
						END
					ELSE--Short Name Duplicateion
						BEGIN
							EXEC SaveLog_SP 'Class Short Name Duplication',@UpdatedDate,'Subject',@ClassID--Entry in Log Table
							IF (@@ROWCOUNT=1)
								BEGIN
									SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=4)--Set Message
								END		
						END
				END
			ELSE
				BEGIN
					EXEC SaveLog_SP 'Class Name Duplication',@UpdatedDate,'Class',@ClassID--Entery In Log Table
					IF (@@ROWCOUNT=1)--Check row Effected
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=11)--set Message
						END
				END
			
			
		END
		
	SELECT @msg
	
END
GO
/****** Object:  StoredProcedure [dbo].[SaveBranchDistance_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Pranjali S Vidhate
-- Create date: 26/11/2015
-- Description: To Save Branch Distance
-- =============================================
CREATE PROCEDURE [dbo].[SaveBranchDistance_SP] 
(
  @BranchDistanceID int,
  @From_BranchID int,
  @To_BranchID int,
  @DistanceTime int,
  @UpdatedByUserID int,
  @UpdatedDate nvarchar (50),
  @IsActive int,
  @IsDeleted int
)
AS
DECLARE @msg nvarchar (MAX)
DECLARE @ID int
BEGIN
if not exists( select BranchDistanceID  from BranchDistance where (From_BranchID=@From_BranchID and To_BranchID=@To_BranchID) OR (From_BranchID=@To_BranchID and To_BranchID=@From_BranchID) AND IsDeleted=1)
Begin
if(@BranchDistanceID =0)--check for Save or update
  begin
   if not exists( select BranchDistanceID  from BranchDistance where (From_BranchID=@From_BranchID and To_BranchID=@To_BranchID) OR (From_BranchID=@To_BranchID and To_BranchID=@From_BranchID))
     begin-- insert data
       insert into BranchDistance (From_BranchID,To_BranchID,DistanceTime,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive,IsDeleted)
       values(@From_BranchID,@To_BranchID,@DistanceTime,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@UpdatedDate,@IsActive,@IsDeleted)
         if(@@ROWCOUNT=1)-- Check Row Effected
            begin
              exec SaveLog_SP 'BranchDistance Inserted Sucessfully',@UpdatedDate,'BranchDistance',@BranchDistanceID
              if(@@ROWCOUNT=1)
                 begin
                   set @msg = (SELECT [Message] FROM [Messages] where MessageID=1)
                 end
            end
        else 
           begin
              exec SaveLog_SP 'Error to Save Details', @UpdatedDate, 'BranchDistance',@BranchDistanceID
              if(@@ROWCOUNT=1)--check row effected
                  begin
                      set @msg = (select [Message]  from [Messages] where MessageID = 2)
                  end
           end 
      end
    else-- error for duplicare Distance
       begin
         exec SaveLog_SP 'Distance In Branch Duplication',@updatedDate,'BranchDistance',@BranchDistanceID
         if(@@ROWCOUNT=1)
             begin
                 set @msg =(select [Message] from [Messages] where MessageID =20)-- set msg to return
             end
       end     
  end
else-- update
  begin
  --  if not exists (select [DistanceTime] from BranchDistance where BranchDistanceID=@BranchDistanceID  )
     begin--update sp
        update BranchDistance set  DistanceTime=@DistanceTime,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate,IsActive=@IsActive,IsDeleted=@IsDeleted
        where BranchDistanceID = @BranchDistanceID
        if(@@ROWCOUNT=1)-- check row effected or not
          begin
             exec SaveLog_SP 'Distance Updated Sucessfully',@UpdatedDate,'BranchDistance', @BranchDistanceID
             if(@@ROWCOUNT=1)
                 begin
                   set @msg = (select [Message]  from [Messages] where MessageID = 5)
                 end
          end
     end
  /* else-- duplication
     begin
       exec SaveLog_SP 'Distance Duplication', @updatedDate, 'BranchDistance', @BranchDistanceID
        if(@@ROWCOUNT=1)--check row effected
            begin
               set @msg = (select [Message] from [Messages] where MessageID = 20) --set message to return
            end
     end  */
     
 end 
 END
 
 ELSE
 begin
 set @ID =( select BranchDistanceID  from BranchDistance where (From_BranchID=@From_BranchID and To_BranchID=@To_BranchID) OR (From_BranchID=@To_BranchID and To_BranchID=@From_BranchID) AND IsDeleted=1)
     UPDATE BranchDistance set DistanceTime=@DistanceTime,IsActive=@IsActive,IsDeleted=@IsDeleted,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate
     where BranchDistanceID=@ID
     
     if(@@ROWCOUNT=1)-- Check Row Effected
            begin
              exec SaveLog_SP 'BranchDistance Updated Sucessfully',@UpdatedDate,'BranchDistance',@ID
              if(@@ROWCOUNT=1)
                 begin
                   set @msg = (SELECT [Message] FROM [Messages] where MessageID=1)
                 end
            end

     
  END
  select @msg
END
GO
/****** Object:  StoredProcedure [dbo].[SaveBranch_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sameer A.Shinde
-- Create date: 04/11/2015
-- Description:	Save Institute Details
-- =============================================
CREATE PROCEDURE [dbo].[SaveBranch_SP] ---0,'Main','IIM001','Sarthak Education','Teratech-Favicon.png',1,1,'2015-11-05',1,0
	(
	@BranchID int,
	@BranchName nvarchar(MAX),
	@BranchCode nvarchar(MAX),
	@InstituteName nvarchar(MAX),
	@Logo nvarchar(MAX),
	@CreatedByUserID int,
	@UpdateByUserId int,
	@UpdatedDate nvarchar(40), 
	@IsActive int,
	@IsDelete int
	)
AS
Declare @msg nvarchar(MAX)
BEGIN
  IF(@BranchID=0)--Check for Edit Or Update 0 for new entry and onther no update
		BEGIN
			IF NOT EXISTS (SELECT BranchID FROM Branch Where BranchName=@BranchName)--Check Whether given name Already exist or not
				BEGIN
			        IF NOT EXISTS (SELECT BranchID FROM Branch Where BranchCode=@BranchCode)--Check Whether given Branch Code Already exist or not
			        	BEGIN
					        
							INSERT INTO Branch(BranchName,BranchCode,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive,IsDeleted,InstituteName,Logo) 
							values(@BranchName,@BranchCode,@CreatedByUserID,@UpdateByUserId,@UpdatedDate,@UpdatedDate,@IsActive,@IsDelete,@InstituteName,@Logo)
							
									
									IF (@@ROWCOUNT=1)--Check Row Effected or Not
										BEGIN
										EXEC SaveLog_SP 'Branch Inserted Sucessfully.',@UpdatedDate,'Branch',@BranchID --Enter in Log Table
											SET @msg=(SELECT [Message]	FROM [Messages] WHERE MessageID=1)--Set Message to return
											
										END
									ELSE
									BEGIN
									EXEC SaveLog_SP 'Error to Insert Branch',@UpdatedDate,'Branch',@BranchID --Enter in Log Table
										SET @msg=(SELECT [Message]	FROM [Messages] WHERE MessageID=2)--Set Message To Return
									END		
								
				END	
				--Duplicate Branch Code
				Else
				begin
				EXEC SaveLog_SP 'Branch Code Duplicate Record not insert',@UpdatedDate,'Branch',@BranchID --Enter in Log Table
					SET @msg= 'Duplicate Branch Code'--Set Message To Return
				end	
				End
			ELSE --Error for Duplicate Branch Name
				BEGIN
				EXEC SaveLog_SP 'Branch Name Duplicate Record not insert',@UpdatedDate,'Branch',@BranchID --Enter in Log Table
					SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=7)--Set Message To Return
				END
				
		END
	
	ELSE
		BEGIN
			IF NOT EXISTS (SELECT BranchID FROM Branch Where BranchName=@BranchName AND BranchID<>@BranchID)--Check Whether Branch Name Exists
				BEGIN
					
							UPDATE Branch SET BranchName=@BranchName,BranchCode=@BranchCode,UpdatedDate=@UpdatedDate,UpdatedByUserID=@UpdateByUserId,IsActive=@IsActive,IsDeleted=@IsDelete,InstituteName=@InstituteName,Logo=@Logo
							WHERE BranchID=@BranchID
							
									
									IF (@@ROWCOUNT=1)--Check Row Effected Or Not
										BEGIN
										EXEC SaveLog_SP 'Branch Update Sucessfully',@UpdatedDate,'Branch',@BranchID --Enter in Log Table
											SET @msg =(SELECT [Message] FROM [Messages] Where MessageID=5)--Set message
											--Select @msg
									    END
									ELSE
										BEGIN
										EXEC SaveLog_SP 'Error to Update Institute Name Already Exisits ',@UpdatedDate,'Branch',@BranchID --Enter in Log Table
											SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=7)--set Message
										END
								
			   END
								
			ELSE
				BEGIN
				EXEC SaveLog_SP 'Error to Update Institute Name Already Exisits ',@UpdatedDate,'Branch',@BranchID --Enter in Log Table
					SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=7)--set Message
					--Select @msg
	    		End	
	
	End	
	
	
	
	
	SELECT @msg
END
GO
/****** Object:  StoredProcedure [dbo].[SaveBoard_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 10 Dec 2015
-- Description:	Save Board
-- =============================================
CREATE PROCEDURE [dbo].[SaveBoard_SP] 
(
@BoardID int,
@BoardName nvarchar(50),
@IsActive int,
@IsDeleted int,
@UpdatedByUserID int,
@UpdatedDate nvarchar(50)
)
AS
DECLARE @msg NVARCHAR(MAX)
DECLARE @MaxID int
BEGIN
	IF (@BoardID=0)-- New Entry
		BEGIN
			IF NOT EXISTS(SELECT BoardID FROM Board WHERE BoardName=@BoardName)--CHeck For Duplicate Entry
				BEGIN
					INSERT INTO Board (BoardName,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive,IsDeleted)
					VALUES (@BoardName,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@UpdatedDate,@IsActive,@IsDeleted)
					IF (@@ROWCOUNT=1)
						BEGIN
							SET @MaxID= (SELECT MAX(BoardID) FROM Board)
							EXEC SaveLog_SP 'Board Save SucessFully',@UpdatedDate,'Board',@MaxID
							SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=1)
						END
					ELSE
						BEGIN
							SET @MaxID= (SELECT MAX(BoardID) FROM Board)
							EXEC SaveLog_SP 'Error To Save Board',@UpdatedDate,'Board',@MaxID
							SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=2)
						END
				END
			ELSE -- Name ALready EXisists
				BEGIN
					SET @msg= (SELECT [Message] FROM [Messages] WHERE MessageID=25)
				END
		END
	ELSE
		BEGIN
			IF NOT EXISTS(SELECT BoardID FROM Board WHERE BoardName=@BoardName AND BoardID<>@BoardID)--Chekc Duplication Name
				 BEGIN
					UPDATE Board SET BoardName=@BoardName,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate,IsActive=@IsActive,IsDeleted=@IsDeleted
					WHERE BoardID=@BoardID
					IF (@@ROWCOUNT=1)
						BEGIN
							
							EXEC SaveLog_SP 'Board Updated Sucessfully',@UpdatedDate,'Board',@BoardID
							SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=5)
						END
					ELSE
						BEGIN
							SET @MaxID= (SELECT MAX(BoardID) FROM Board)
							EXEC SaveLog_SP 'Error To Update Board',@UpdatedDate,'Board',@MaxID
							SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=2)
						END
				 END
			ELSE
				BEGIN
					SET @msg= (SELECT [Message] FROM [Messages] WHERE MessageID=25)
				END
		END
		SELECT @msg
END
GO
/****** Object:  StoredProcedure [dbo].[GetBranchClassCount_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Pranjali S. Vidhate
-- Create date: 27/11/2015
-- Description:	To Get No of Classes for Branch
-- =============================================
CREATE PROCEDURE [dbo].[GetBranchClassCount_SP]

AS
BEGIN
   select br.BranchName, count(cs.ClassID) as 'NoOfClass', br.BranchID from Class cs
   inner join Branch br
   on cs.BranchID = br.BranchID
   where cs.IsDeleted = 0  AND br.IsActive=1
   group by br.BranchName, br.BranchID 	
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetClassDetail_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 06-11-2015
-- Description:	Grid view cell click..to update data
-- =============================================
CREATE PROCEDURE [dbo].[GetClassDetail_SP] --'','','','',40
	(
	
	@ClassName nvarchar(50),
	@ShortName nvarchar(50),
	@Board nvarchar(50),
	@Color nvarchar(50),
	@BranchID int
	)
AS
BEGIN 
 select c.ClassID,c.ClassName,c.ClassShortName,c.Board,Color,b.BranchName,c.BranchID,c.IsActive,c.IsDeleted from [Class]c
 inner join Branch b
 on b.BranchID=c.BranchID
 where c.ClassName like case when @ClassName <>'' THEN '%'+ @ClassName +'%' else'%' end 
 and b.BranchID like case  when @branchID <>0 then @BranchID else convert(nvarchar(50),b.BranchID) end
END
GO
/****** Object:  StoredProcedure [dbo].[GetNoOfDaysTeacherAvailable_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 07 Nov 2015
-- Description:	Get NO of Days Teacher Available
-- =============================================
CREATE PROCEDURE [dbo].[GetNoOfDaysTeacherAvailable_SP] 
	
	
	
AS
BEGIN
	Select Tea.TeacherID,tea.TeacherName, COUNT (TeacherAvailableID) AS 'NoOfDaysAvailaible' From TeacherAvailable TeaAvail
	INNER JOIN Teacher tea
	ON Tea.TeacherID=TeaAvail.TeacherID
	Where TeaAvail.TeacherID=TeaAvail.TeacherID AND TeaAvail.IsActive ='True' AND TeaAvail.IsDeleted='False' AND tea.IsActive='True'
	GROUP BY Tea.TeacherID,tea.TeacherName
END
GO
/****** Object:  StoredProcedure [dbo].[GetUser_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kalpesh Katyare
-- Create date: 6 Nov 2015
-- Description:	Get User
-- =============================================
CREATE PROCEDURE [dbo].[GetUser_SP] --0, ''
	@UserID int,
	@UserName NVARCHAR(50)
AS
BEGIN
	SELECT [UserID] ,[FullName] ,[ContactNo] ,[Address] ,[EmailID] ,[UserName] ,[Password] ,[CreatedDate] ,[UpdatedDate] ,
	[UserTypeID], case when [UserTypeID] = 2  then 'User' 
	when [UserTypeID]  = 1 then 'Admin' end as [UserType],[IsActive] ,[IsDeleted],
	case when IsActive ='True'  then 'Active' 
	when IsActive ='False' then 'InActive' end as [Status] FROM [User]
	WHERE IsDeleted = 'False'
	AND [UserID] LIKE CASE WHEN @UserID<>0 THEN @UserID ELSE CONVERT (NVARCHAR(50),UserID) END
	AND FullName LIKE CASE WHEN @UserName<>'' THEN '%'+@UserName+'%' ELSE CONVERT (NVARCHAR(50),FullName) END
	ORDER BY FullName
END
GO
/****** Object:  StoredProcedure [dbo].[GetTeacherAvailableDetail_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 07 Nov 2015
-- Description:	Get Teacher Available Details
-- =============================================
CREATE PROCEDURE [dbo].[GetTeacherAvailableDetail_SP] 
	(
	@TeacherID int 
	)
AS
BEGIN
	SELECT TeacherAvailableID,TeacherID,[DAY],StartTime,EndTime FROM TeacherAvailable
	WHERE TeacherID LIKE CASE WHEN @TeacherID<>0 THEN @TeacherID ELSE CONVERT (NVARCHAR(50),TeacherID) END
	AND IsActive='True' AND IsDeleted='False'
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTeacher_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 07 Nov 2015
-- Description:	Delete Teacher
-- =============================================
CREATE PROCEDURE [dbo].[DeleteTeacher_SP] 
	(
	@TeacherID int,
	@UpdatedDate nvarchar(50),
	@UpdatedByUserID int
	)
AS
DECLARE @msg nvarchar(50)
BEGIN
	Update Teacher set IsActive=0 ,IsDeleted=1 ,UpdatedDate=CONVERT(datetime,@UpdatedDate),UpadatedByUserID=@UpdatedByUserID
	WHERE TeacherID=@TeacherID
	IF (@@ROWCOUNT=1)
		BEGIN
			
		       EXEC SaveLog_SP 'Delete Teacher Sucessfully.',@UpdatedDate,'Teacher',@TeacherID
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=12)
		END
	else
		BEGIN
			EXEC SaveLog_SP 'Error To Delete Teacher',@UpdatedDate,'Teacher',@TeacherID
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=13)
		END
	SELECT @msg
	
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSubject_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 5 Nov 2015
-- Description:	Delete Subject
-- =============================================
CREATE PROCEDURE [dbo].[DeleteSubject_SP] 
	(
	@SubjectID int,
	@UpdatedByUserID int,
	@UpdatedDate nvarchar(50) ) 
	
AS
DECLARE @msg NVARCHAR(50)
BEGIN
	UPDATE [Subject] SET IsActive=0  , IsDeleted=1 ,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate
	WHERE SubjectID= @SubjectID
	if (@@ROWCOUNT=1)
		BEGIN 
		       EXEC SaveLog_SP 'Delete Subject Sucessfully.',@UpdatedDate,'Subject',@SubjectID
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=12)
		END
	else
		BEGIN
			EXEC SaveLog_SP 'Error To Delete Record',@UpdatedDate,'Subject',@SubjectID
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=13)
		END
	SELECT @msg
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteRoom_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:Pranjali
-- Create date: 07/11/2015
-- Description:	To delete Room
-- =============================================
Create PROCEDURE [dbo].[DeleteRoom_SP] 
	(
	@RoomID int,
	@UpdatedByUserID int,
	@UpdatedDate nvarchar(50) ) 
	
AS
DECLARE @msg NVARCHAR(50)
BEGIN
	UPDATE [BranchesRooms]  SET IsActive=0  , IsDeleted=1 ,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate
	WHERE RoomID = @RoomID
	if (@@ROWCOUNT=1)
		BEGIN 
		       EXEC SaveLog_SP 'Delete Room Sucessfully.',@UpdatedDate,'Room',@RoomID 
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=12)
		END
	else
		BEGIN
			EXEC SaveLog_SP 'Error To Delete Record',@UpdatedDate,'Room',@RoomID 
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=13)
		END
	SELECT @msg
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteDistance_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Pranjali s Vidhate
-- Create date: 26/11/2015
-- Description:To Delete Distance in Branches
-- =============================================
CREATE PROCEDURE [dbo].[DeleteDistance_SP]
(
 @BranchDistanceID int,
 @UpdatedByUserID int,
 @UpdatedDate nvarchar (50)	
)	
AS
declare @msg nvarchar(50)
BEGIN
    update BranchDistance set IsActive=0, IsDeleted=1, UpdatedByUserID = @UpdatedByUserID, UpdatedDate =@UpdatedDate
    where BranchDistanceID =@BranchDistanceID
    if(@@ROWCOUNT=1)--check roe effected
        begin
           exec SaveLog_SP 'Delete Distance Sucessfully',@UpdatedDate,'BranchDistance', @BranchDistanceID
        
             begin
               set @msg =(select [Message]  from [Messages] where MessageID = 12)
             end
        end	
    else 
        begin
           exec SaveLog_SP 'Error to Delete Record',@UpdatedDate,'BranchDistance', @BranchDistanceID
             begin
                set @msg =(select [Message]  from [Messages] where MessageID = 13)
             end
        end
  select @msg
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteClass_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 06-11-2015
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[DeleteClass_SP] 
	(
	@ClassID int,
	@UpdatedByUserID int,
	@UpdatedDate nvarchar(50) ) 
	
AS
DECLARE @msg NVARCHAR(50)
BEGIN
	UPDATE [Class] SET IsActive=0  , IsDeleted=1 ,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate
	WHERE ClassID= @ClassID
	if (@@ROWCOUNT=1)
		BEGIN 
		       EXEC SaveLog_SP 'Class Deleted Sucessfully.',@UpdatedDate,'Class',@ClassID
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=12)
		END
	else
		BEGIN
			EXEC SaveLog_SP 'Error To Delete Record',@UpdatedDate,'Class',@ClassID
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=13)
		END
	SELECT @msg
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteBranch_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sameer Shinde
-- Create date: 5 Nov 2015
-- Description:	Delete Subject
-- =============================================
CREATE PROCEDURE [dbo].[DeleteBranch_SP] 
	(
	@BranchID int,
	@UpdatedByUserId int,
	@UpdatedDate nvarchar(50) ) 
	
AS
DECLARE @msg NVARCHAR(50)
BEGIN
	UPDATE Branch SET IsActive=0  , IsDeleted=1 ,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate
	WHERE BranchID= @BranchID
	if (@@ROWCOUNT=1)
		BEGIN 
		       EXEC SaveLog_SP 'Delete Branch Sucessfully.',@UpdatedDate,'Branch',@BranchID
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=9)
		END
	else
		BEGIN
			EXEC SaveLog_SP 'Error To Delete Record',@UpdatedDate,'Branch',@BranchID
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=10)
		END
	SELECT @msg
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteBoard_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 10 Dec 2015
-- Description:	Delete Board
-- =============================================
CREATE PROCEDURE [dbo].[DeleteBoard_SP] 
 (
 @BoardID int,
 @UpdatedDate nvarChar(50),
 @UpdatedByUserID int
 )
AS
DECLARE @msg NVARCHAR(MAX)
BEGIN
	UPDATE Board SET IsActive=0,IsDeleted=1,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate
	Where BoardID=@BoardID
	IF (@@ROWCOUNT=1)
	 BEGIN
		EXEC SaveLog_SP 'Delete Board SucessFully',@UpdatedDate,'Board',@BoardID
		SET @msg= (SELECT [Message] FROM [Messages] WHERE MessageID=12)
	 END
	 ELSE
		BEGIN
			EXEC SaveLog_SP 'Error To Delete Board',@UpdatedDate,'Board',@BoardID
		SET @msg= (SELECT [Message] FROM [Messages] WHERE MessageID=13)
		END
	SELECT @msg
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteUser_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Kalpesh Katyare
-- Create date: 6 Nov 2015
-- Description:	Delete User
-- =============================================
CREATE PROCEDURE [dbo].[DeleteUser_SP] 
	(
	@UserID int,
	@UpdatedDate nvarchar(50) 
	)
AS
DECLARE @msg NVARCHAR(50)
BEGIN
	UPDATE [User] SET IsActive=0, IsDeleted=1, UpdatedDate=@UpdatedDate
	WHERE UserID= @UserID
	if (@@ROWCOUNT=1)
		BEGIN 
		       EXEC SaveLog_SP 'Delete User Sucessfully.',@UpdatedDate,'User',@UserID
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=12)
		END
	else
		BEGIN
			EXEC SaveLog_SP 'Error To Delete Record',@UpdatedDate,'User',@UserID
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=13)
		END
	SELECT @msg
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteTimeSlot_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Pranjali
-- Create date: 2015/11/18
-- Description:	To Delete TimeSlot
-- =============================================
CREATE PROCEDURE [dbo].[DeleteTimeSlot_SP]
	(
	@BranchLectureDetailID int,
	@UpdatedByUserID int,
	@UpdatedDate nvarchar(50) ) 
	
AS
DECLARE @msg NVARCHAR(50)
BEGIN
	UPDATE [BranchLectureDetail]   SET IsActive=0  , IsDelete=1 ,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate
	WHERE BranchLectureDetailID  = @BranchLectureDetailID 
	if (@@ROWCOUNT=1)
		BEGIN 
		       EXEC SaveLog_SP 'Delete Time Slot Sucessfully.',@UpdatedDate,'Time Slot',@BranchLectureDetailID  
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=12)
		END
	else
		BEGIN
			EXEC SaveLog_SP 'Error To Delete Record',@UpdatedDate,'Time Slot',@BranchLectureDetailID  
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=13)
		END
	SELECT @msg
END
GO
/****** Object:  StoredProcedure [dbo].[GetBatchDetail_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 06-11-2015
-- Description:	Grid Cell Click event for Update or Edit
-- =============================================
CREATE PROCEDURE [dbo].[GetBatchDetail_SP] 
	(
		@BatchName nvarchar(50),
		@BatchCode nvarchar(50)		
	)
AS
BEGIN
		select c.ClassName,b.BatchID, b.BatchName,b.BatchCode,b.LectureDuration,b.IsLunchBreak,b.LunchBreakStartTime,
		b.LunchBreakEndTime,b.MaxNoLecturesDay,b.MaxNoLecturesWeek,b.IsAllowMoreThanOneLectInBatch,b.MaxNoOfLecureInRow,
		b.IsActive,b.IsDeleted from [Batches] b
		inner join Class c
		on c.ClassID= b.ClassID
		where BatchName=@BatchName and BatchCode=@BatchCode
		and b.IsDeleted <> 'True'
END
GO
/****** Object:  StoredProcedure [dbo].[loadBatchName_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 05-11-2015
-- Description:	To Bind BatchName using id
-- =============================================
CREATE PROCEDURE [dbo].[loadBatchName_SP] --98
	(
	@ClassID int	
 	)
AS
BEGIN
	SELECT 0 AS BatchID,'Select' AS BatchName
	Union
	SELECT b.BatchID,b.BatchName  from [Batches] b
	inner join Class c
	on c.ClassID = b.ClassID
	where
	
	c.ClassID like case when @ClassID <> 0 then @ClassID else CONVERT(nvarchar(50),@ClassID)end
	  and  b.IsActive=1
	   AND b.IsDeleted='False' AND C.IsActive=1

END
GO
/****** Object:  StoredProcedure [dbo].[GetRoomAvailableDetail_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Pranjali Vidhate
-- Create date: 20-11-2015
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetRoomAvailableDetail_SP] --2
	(
	   @RoomID int 
	)
AS
BEGIN
	SELECT RoomAvailableID,RoomID,[DAY],StartTime,EndTime FROM RoomAvailable
	WHERE RoomID LIKE CASE WHEN @RoomID<>0 THEN @RoomID ELSE CONVERT (NVARCHAR(50),RoomID) END
	AND IsActive='True' AND IsDeleted='False'
END
GO
/****** Object:  StoredProcedure [dbo].[GetMaxBatchID_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Sameer Shinde
-- Create date: 10 Dec 2015
-- Description:	Get Max Batch ID
-- =============================================
CREATE PROCEDURE [dbo].[GetMaxBatchID_SP]
	
AS
BEGIN
   
	SELECT MAX(BatchID) from [Batches]
END
GO
/****** Object:  StoredProcedure [dbo].[GetNoOfDaysRoomAvailable_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		pranjali Vidhate
-- Create date: 20-11-2015
-- Description:	To get no. of room available
-- =============================================
CREATE PROCEDURE [dbo].[GetNoOfDaysRoomAvailable_SP]  
	
AS
BEGIN
	Select br.RoomID,br.RoomName, COUNT (RoomAvailableID) AS 'NoOfDaysAvailaible' From RoomAvailable RoomAvail
	INNER JOIN BranchesRooms br
	ON br.RoomID=RoomAvail.RoomID
	Where RoomAvail.RoomID=RoomAvail.RoomID AND 
	RoomAvail.IsActive ='True' AND RoomAvail.IsDeleted='False' AND br.IsActive='True'
	GROUP BY br.RoomID,br.RoomName
END
GO
/****** Object:  StoredProcedure [dbo].[BindBatchName_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: BindBatchName
-- Description:	To bind batch Names on dropdown
-- =============================================
CREATE PROCEDURE [dbo].[BindBatchName_SP]
AS
BEGIN
	SELECT 0 AS BatchID,'Select' as BatchName
	Union
	SELECT BatchID,BatchName  from [Batches] where	
	  IsDeleted<>'True' AND IsActive=1	
	  ORDER BY BatchName
    
END
GO
/****** Object:  StoredProcedure [dbo].[BindBatch_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 05-11-2015
-- Description:	Get Details To bind Drop Down
-- =============================================
CREATE PROCEDURE [dbo].[BindBatch_SP] -- 0,''
(
	@BatchID int,
	@BatchName nvarchar(50)
) 
	
AS
BEGIN
SELECT c.ClassName,b.BatchID,b.BatchName,b.BatchCode,b.LectureDuration,
case when b.IsLunchBreak ='True' then 'Yes' when b.IsLunchBreak ='False' then 'No' end as IsLunchBreak ,
b.LunchBreakStartTime,b.LunchBreakEndTime,b.MaxNoLecturesDay,b.MaxNoLecturesWeek,
b.IsAllowMoreThanOneLectInBatch,b.MaxNoOfLecureInRow,case when b.IsActive ='True'  then 'Active' 
when b.IsActive ='False' then 'InActive' end as [Status]
from [Batches] b
inner join Class c
on c.ClassID=b.ClassID
	WHERE b.BatchID LIKE CASE WHEN @BatchID<>0 THEN @BatchID ELSE CONVERT (NVARCHAR(50),BatchID) END
	AND b.BatchName LIKE CASE WHEN @BatchName<>'' THEN '%'+@BatchName+'%' ELSE CONVERT (NVARCHAR(50),b.BatchName)END
	AND b.IsDeleted<>'True' 
	ORDER BY BatchName 
END
GO
/****** Object:  Table [dbo].[BatchSubject]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BatchSubject](
	[BatchSubjectID] [int] IDENTITY(1,1) NOT NULL,
	[SubjectID] [int] NOT NULL,
	[BatchID] [int] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[UpdatedByUserID] [int] NOT NULL,
	[FrequencyPerDay] [int] NOT NULL,
	[FrequencyPerWeek] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [BatchSubjectID] PRIMARY KEY CLUSTERED 
(
	[BatchSubjectID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BatchDays]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BatchDays](
	[BatchDayID] [int] IDENTITY(1,1) NOT NULL,
	[BatchID] [int] NOT NULL,
	[Days] [nvarchar](15) NOT NULL,
	[StartTime] [time](7) NOT NULL,
	[EndTime] [time](7) NOT NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [BatchDayID] PRIMARY KEY CLUSTERED 
(
	[BatchDayID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[BindRoom_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:Pranjali
-- Create date: 04/11/2015
-- Description:	To Bind Room
-- =============================================
CREATE PROCEDURE [dbo].[BindRoom_SP] --9,'Infosys','Room_Info'
	(
		@RoomID int,
		@BranchName nvarchar(50),
		@RoomName nvarchar(50)
		
	)
AS
--DECLARE @Output int =0
BEGIN
	SELECT br.RoomID,br.RoomName,br.RoomShortName,br.BranchID,b.BranchName,br.RoomColor,br.Capacity,br.IsActive,br.IsDeleted,
	br.MaxNoLecturesDay,br.MaxNoLecturesWeek,br.MaxNoOfLectureInRow,br.FreeTimeStart,br.FreeTimeEnd,br.IsAllowMoreThanOneLectInBatch,
	case when br.IsActive ='True'  then 'Active' 
	when br.IsActive ='False' then 'InActive' end as [Status] , COUNT (Case WHEN Roomava.IsActive=1 then 1 END) AS 'NoOfDaysAvailable' 
	from [BranchesRooms] br 
	inner join Branch b
	on b.BranchID=br.BranchID
	inner join RoomAvailable RoomAva
	on RoomAva.RoomID = br.RoomID
	
	WHERE br.RoomID LIKE CASE WHEN @RoomID<>0 THEN @RoomID ELSE CONVERT (NVARCHAR(50),br.RoomID) END
	AND b.BranchName LIKE CASE WHEN @BranchName<>'' THEN @BranchName ELSE CONVERT(NVARCHAR(50),b.BranchName)END
	AND br.RoomName LIKE CASE WHEN @RoomName<>'' THEN '%'+@RoomName+'%' ELSE CONVERT(NVARCHAR(50),br.RoomName)END
	AND br.IsDeleted<>'True'
	GROUP BY br.RoomID,br.RoomName,br.RoomShortName,br.BranchID,b.BranchName,br.RoomColor,br.Capacity,br.IsActive,br.IsDeleted,
	br.MaxNoLecturesDay,br.MaxNoLecturesWeek,br.MaxNoOfLectureInRow,br.FreeTimeStart,br.FreeTimeEnd,br.IsAllowMoreThanOneLectInBatch
	Order By br.RoomName
END
GO
/****** Object:  StoredProcedure [dbo].[BindClassBatch_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 19 Nov 2015
-- Description:	Get batch Details on ClassID
-- =============================================
CREATE PROCEDURE [dbo].[BindClassBatch_SP] 
	(
	@ClassID int = 0
	)
AS
BEGIN
	SELECT 0 AS BatchID,'Select' AS BatchName
	Union
	SELECT BatchID,BatchName FROM [Batches]
	WHERE ClassID LIKE CASE WHEN @ClassID<>0 THEN  @ClassID ELSE CONVERT (NVARCHAR(50),ClassID) END
	AND IsActive='True' AND IsDeleted='False'
	ORDER BY BatchName
END
GO
/****** Object:  StoredProcedure [dbo].[BindBranchBatch_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 20 Nov 2015
-- Description:	Bind Batches on Branch ID
-- =============================================
CREATE PROCEDURE [dbo].[BindBranchBatch_SP] 
(
	@BranchID int 
)
AS
BEGIN
	SELECT 0 AS BatchID,'Select' AS BatchName
	UNION
	SELECT ba.BatchID,ba.BatchName FROM [Batches] ba
	INNER JOIN Class cl
	ON cl.ClassID=ba.ClassID
	WHERE cl.BranchID LIKE CASE WHEN @BranchID <>0 THEN @BranchID ELSE CONVERT(NVARCHAR(50),cl.BranchID) END
	AND ba.IsActive='True' AND ba.IsDeleted='False' AND cl.IsActive='True' 
	ORDER BY BatchName
END
GO
/****** Object:  Table [dbo].[BatchAvailable]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BatchAvailable](
	[BatchAvailableID] [int] IDENTITY(1,1) NOT NULL,
	[Day] [nvarchar](15) NOT NULL,
	[StartTime] [time](7) NULL,
	[EndTime] [time](7) NULL,
	[BatchID] [int] NOT NULL,
	[CreatedByUserID] [int] NULL,
	[UpdatedByUserID] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdatedDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [PK_BatchAvailable] PRIMARY KEY CLUSTERED 
(
	[BatchAvailableID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[CheckTimeSlot_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 8 Dec 2015
-- Description:	To Check Time slot is already Aloctted or Free
-- =============================================
CREATE PROCEDURE [dbo].[CheckTimeSlot_SP] 
	(@BranchID int,
	@Day NVARCHAR(50),
	@SlotStartTime NVARCHAR(50),
	@SlotEndTime NVARCHAR(50))
AS
BEGIN
	DECLARE @ret int;
	--Duplicate Time Entry for same day Same Slot time Start time and End Time
	IF EXISTS (SELECT bld.BranchLectureDetailID FROM BranchLectureDetail bld INNER JOIN BranchLecture bl ON bl.BranchLectureID=bld.BranchLectureID where bl.BranchID=@BranchID AND bl.[DayName]=@Day AND LectureStartTime=@SlotStartTime AND LectureEndTime=@SlotEndTime and bld.IsDelete <> 1)
		BEGIN 
			SET @ret =1
		END
	--Check Whether entered time is in between existing time slot
	ELSE IF EXISTS (SELECT BranchLectureDetailID FROM BranchLectureDetail bld INNER JOIN BranchLecture bl ON bl.BranchLectureID=bld.BranchLectureID where bl.[DayName] =@Day AND bl.BranchID=@BranchID AND (CAST (@SlotStartTime AS TIME)  BETWEEN CAST (bld.LectureStartTime AS TIME) and CAST (bld.LectureEndTime AS TIME)OR CAST (@SlotEndTime AS TIME) BETWEEN CAST (bld.LectureStartTime AS TIME) and CAST (bld.LectureEndTime AS TIME))and bld.IsDelete <> 1)
	
		BEGIN
			SET @ret=2
		END 
	--no duplication or in between of time
	ELSE
		BEGIN
			SET @ret=0
		END
	SELECT @ret
END
GO
/****** Object:  StoredProcedure [dbo].[BindTimeSlot_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Pranajli S Vidhate
-- Create date: 2015/11/17
-- Description:	To Bind TimeSlot
-- =============================================
CREATE PROCEDURE [dbo].[BindTimeSlot_SP] --30,'j','w'
	(
		@BranchLectureDetailID int,
		@BranchName nvarchar(50),
		@DayName nvarchar(50)
		
	)
AS
BEGIN
	SELECT bld.BranchLectureDetailID,br.BranchID,bl.[DayName],br.BranchName,bl.StartTime,bl.EndTime,bld.IsActive,bld.IsDelete,
	bld.LectureStartTime,bld.LectureEndTime, CASE WHEN bld.IsActive='True' AND bld.IsDelete='False' THEN 'Active' 
	WHEN bld.IsActive='False' AND bld.IsDelete='False' THEN 'InActive' End AS [Status] 
	FROM BranchLectureDetail bld
	INNER JOIN  BranchLecture bl
	ON bl.BranchLectureID=bld.BranchLectureID
	INNER JOIN Branch br
	ON br.BranchID=bl.BranchID
	WHERE bld.BranchLectureDetailID LIKE CASE WHEN @BranchLectureDetailID <>0 THEN @BranchLectureDetailID ELSE CONVERT (NVARCHAR(50),bld.BranchLectureDetailID) END
	AND br.BranchName LIKE CASE WHEN @BranchName <>'' THEN @BranchName ELSE CONVERT (NVARCHAR(50),br.BranchName) END
	AND bl.[DayName] LIKE CASE WHEN @DayName <>'' THEN '%'+@DayName +'%' ELSE CONVERT(NVARCHAR(50),bl.[DayName])END
	AND bld.IsDelete<>'True'
	
	ORDER BY bl.[DayName]
	

END
GO
/****** Object:  StoredProcedure [dbo].[DeleteBatch_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 06-11-2015
-- Description:	Delete Batch
-- =============================================
create PROCEDURE [dbo].[DeleteBatch_SP] 
	(
	@BatchID int,
	@UpdatedByUserID int,
	@UpdatedDate nvarchar(50) ) 
	
AS
DECLARE @msg NVARCHAR(50)
BEGIN
	UPDATE [Batches] SET IsActive=0  , IsDeleted=1 ,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate
	WHERE BatchID= @BatchID
	if (@@ROWCOUNT=1)
		BEGIN 
		       EXEC SaveLog_SP 'Batch Deleted Sucessfully.',@UpdatedDate,'Batches',@BatchID
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=12)
		END
	else
		BEGIN
			EXEC SaveLog_SP 'Error To Delete Record',@UpdatedDate,'Batches',@BatchID
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=13)
		END
	SELECT @msg
END
GO
/****** Object:  StoredProcedure [dbo].[SearchBatch_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 06-11-2015
-- Description:	for Search Batch by batch Name
-- =============================================
CREATE PROCEDURE [dbo].[SearchBatch_SP] 	--batch
	@BatchName NVARCHAR(50)
AS
BEGIN
	SELECT c.ClassName,b.BatchName,BatchCode,LectureDuration,IsLunchBreak,LunchBreakStartTime,LunchBreakEndTime,b.IsActive,b.IsDeleted
	 MaxNoLecturesDay,MaxNoLecturesWeek,IsAllowMoreThanOneLectInBatch,MaxNoOfLecureInRow FROM [Batches] b
	 inner join Class c
	 on c.ClassID=b.ClassID
	WHERE b.IsDeleted = 'False'
	AND (b.BatchName Like '%'+@BatchName+'%' OR b.BatchCode LIKE '%'+@BatchName+'%' )
END
GO
/****** Object:  StoredProcedure [dbo].[SaveUpdateTimeSlot_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Pranjali S Vidhate
-- Create date: 2015/11/17
-- Description:	To SaveUpdate Timeslot
-- =============================================
CREATE PROCEDURE [dbo].[SaveUpdateTimeSlot_SP] --0,11,'Monday','07:00','12:00','08:00','09:00',1,0,'2015-11-17',1
(
     @BranchLectureDetailID int,
     @BranchID int,
	 @DayName nvarchar(50),
	 @STime nvarchar(50),
	 @ETime nvarchar(50),
	 @SSTime nvarchar(50),
	 @SETime nvarchar(50),
	 @IsActive int,
	 @IsDeleted int,
	 @UpdatedDate nvarchar(50),
	 @UpdatedByUserID int
 )
AS
DECLARE @msg NVARCHAR(50)
DECLARE @ID int
DECLARE @MAXID int
BEGIN
--if data not EXists New Entry
IF NOT  EXISTS (SELECT BranchLectureID FROM BranchLecture WHERE BranchID=@BranchID AND [DayName]=@DayName)
	BEGIN
		--Insert Data into branchLecture
		INSERT INTO BranchLecture(BranchID,[DayName],StartTime,EndTime,IsActive,IsDeleted,CreatedDate,UpdatedDate,CreatedByUserID,UpdatedByUserID)
		VALUES(@BranchID,@DayName,@STime,@ETime,1,0,@UpdatedDate,@UpdatedDate,@UpdatedByUserID,@UpdatedByUserID)
		IF (@@ROWCOUNT=1)
			BEGIN
				SET @ID = (SELECT MAX (BranchLectureID) FROM BranchLecture)
				exec SaveLog_SP 'Time Inserted Successfully',@UpdatedDate,'BranchLecture',@ID 
				
				INSERT INTO BranchLectureDetail (BranchLectureID,LectureStartTime,LectureEndTime,IsActive,IsDelete,CreatedDate,UpdatedDate,CreatedByUserID,UpdatedByUserID)
										VALUES (@ID,@SSTime,@SETime,@IsActive,@IsDeleted,@UpdatedDate,@UpdatedDate,@UpdatedByUserID,@UpdatedByUserID)
				SET @MAXID = (SELECT MAX(BranchLectureDetailID) FROM BranchLectureDetail)
				IF(@@ROWCOUNT=1)
					BEGIN
						exec SaveLog_SP 'TimeSlot Inserted Successfully',@UpdatedDate,'BranchLectureDetail',@MAXID 
						SET @msg = (SELECT [Message] FROM [Messages] where MessageID=1)
					END
				ELSE
					BEGIN
						exec SaveLog_SP 'Error To Save TimeSlot.',@UpdatedDate,'BranchLectureDetail',@MAXID 
						SET @msg = (SELECT [Message] FROM [Messages] where MessageID=2)
					END
					
			END	
		ELSE
			BEGIN
				exec SaveLog_SP 'Error to Save',@UpdatedDate,'BranchLecture',0
				SET @msg = (SELECT [Message] FROM [Messages] where MessageID=2)
			END
	END
ELSE-- Branch Lecture Have Data update it
	BEGIN
		UPDATE BranchLecture SET StartTime=@STime,EndTime=@ETime,UpdatedDate=@UpdatedDate,UpdatedByUserID=@UpdatedByUserID,IsActive=@IsActive,IsDeleted=@IsDeleted
		WHERE BranchID=@BranchID AND [DayName]=@DayName
		IF(@@ROWCOUNT=1)
			BEGIN
				SET @MAXID = (SELECT BranchLectureID FROM BranchLecture WHERE BranchID=@BranchID AND [DayName]=@DayName)
				EXEC SaveLog_SP 'Update Time Sucessfully',@UpdatedDate,'BranchLecture',@MAXID
				IF (@@ROWCOUNT=1)
					BEGIN
						IF NOT EXISTS(SELECT BranchLectureDetailID FROM BranchLectureDetail WHERE BranchLectureDetailID=@BranchLectureDetailID)
							BEGIN
								INSERT INTO BranchLectureDetail (BranchLectureID,LectureStartTime,LectureEndTime,IsActive,IsDelete,CreatedDate,UpdatedDate,CreatedByUserID,UpdatedByUserID)
										VALUES (@MAXID,@SSTime,@SETime,@IsActive,@IsDeleted,@UpdatedDate,@UpdatedDate,@UpdatedByUserID,@UpdatedByUserID)
										
										SET @MAXID=(SELECT MAX(BranchLectureDetailID) FROM BranchLectureDetail)
								IF(@@ROWCOUNT=1)
									BEGIN
										EXEC SaveLog_SP 'TimeSlot Inserted Successfully',@UpdatedDate,'BranchLectureDetail',@MAXID 
										SET @msg = (SELECT [Message] FROM [Messages] where MessageID=1)
									END
								ELSE
									BEGIN
										EXEC SaveLog_SP 'Error To Save TimeSlot.',@UpdatedDate,'BranchLectureDetail',@MAXID 
										SET @msg = (SELECT [Message] FROM [Messages] where MessageID=2)
									END
									
							END
						ELSE
						BEGIN
							UPDATE BranchLectureDetail SET LectureStartTime=@SSTime,LectureEndTime=@SETime,IsActive=@IsActive,IsDelete=@IsDeleted,UpdatedDate=@UpdatedDate,@UpdatedByUserID=@UpdatedByUserID
							WHERE BranchLectureDetailID=@BranchLectureDetailID
							IF (@@ROWCOUNT=1)
							BEGIN
								EXEC SaveLog_SP 'Time Slot Updated SucessFully.',@UpdatedDate,'BranchLectureDetail',@BranchLectureDetailID
								SET @msg= (SELECT [Message] FROM [Messages] WHERE MessageID=5)
								
							END
						ELSE
							BEGIN
							SET @MAXID = (SELECT MAX (BranchLectureDetailID) FROM BranchLectureDetail)
								EXEC SaveLog_SP 'Error To Update Time Slot',@UpdatedDate,'BranchLectureDetail',@MAXID
								SET @msg = (SELECT [Message] FROM [Messages] WHERE MessageID=2)
							END
						END	
					END
			END
		ELSE
			BEGIN
				SET @MAXID = (SELECT BranchLectureID FROM BranchLecture WHERE BranchID=@BranchID AND [DayName]=@DayName)
				EXEC SaveLog_SP 'Error To Update Time',@UpdatedDate,'BranchLecture',@MAXID
				SET @msg = (SELECT [Message] FROM [Messages] where MessageID=2)
			END
	END	
SELECT @msg
	
END
GO
/****** Object:  StoredProcedure [dbo].[SaveRoomAvailable_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:Pranjali Vidhate
-- Create date: 20-11-2015
-- Description:	To save room avilablie 
-- =============================================
CREATE PROCEDURE [dbo].[SaveRoomAvailable_SP]

(
	
	@RoomID int,
	@Day NVARCHAR(50),
	@StartTime NVARCHAR(50),
	@EndTime NVARCHAR(50),
	@UpdatedByUserID int,
	@UpdatedDate NVARCHAR(50),
	@IsActive int,
	@IsDeleted int
	)
AS
DECLARE @msg NVARCHAR(50)
DECLARE @MaxID int
BEGIN
	IF NOT EXISTS (SELECT RoomAvailableID FROM RoomAvailable WHERE RoomID=@RoomID AND [Day]=@Day)
		BEGIN
			INSERT INTO RoomAvailable(RoomID,[Day],StartTime,EndTime,CreatedByUserID,UpdatedByUserID,UpdatedDate,IsActive,IsDeleted)
			VALUES (@RoomID,@Day,@StartTime,@EndTime,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@IsActive,@IsDeleted)
			IF(@@ROWCOUNT=1)
				BEGIN
					SELECT @MaxID=(SELECT MAX(RoomAvailableID) FROM RoomAvailable)
					EXEC SaveLog_SP 'Save Room Availibility.',@UpdatedDate,'RoomAvailable',@MaxID 
					set @msg=(SELECT [Message] FROM [Messages] WHERE MessageID=1)
				END
			ELSE
				BEGIN
					SELECT @MaxID=(SELECT MAX(RoomAvailableID) FROM RoomAvailable)
					EXEC SaveLog_SP ' Error To Save Room Availibility.',@UpdatedDate,'RoomAvailable',@MaxID 
					set @msg=(SELECT [Message] FROM [Messages] WHERE MessageID=2)
				END
			
		END
	ELSE
		BEGIN
			UPDATE RoomAvailable SET StartTime=@StartTime,EndTime=@EndTime,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate,IsActive=@IsActive,IsDeleted=@IsDeleted
			WHERE [Day]=@Day AND RoomID=@RoomID
			IF(@@ROWCOUNT=1)
				BEGIN
					SELECT @MaxID=(SELECT RoomAvailableID  FROM RoomAvailable WHERE RoomID=@RoomID AND [DAY]=@Day)
					EXEC SaveLog_SP 'Update Room Availibility.',@UpdatedDate,'RoomAvailable',@MaxID 
					set @msg=(SELECT [Message] FROM [Messages] WHERE MessageID=5)
				END
			ELSE
				BEGIN
					SELECT @MaxID=(SELECT RoomAvailableID  FROM RoomAvailable WHERE RoomID=@RoomID AND [DAY]=@Day)
					EXEC SaveLog_SP 'Error To Update Room Availibility.',@UpdatedDate,'RoomAvailable',@MaxID 
					set @msg=(SELECT [Message] FROM [Messages] WHERE MessageID=2)
				END
			
		
		END
		SELECT @msg
		
END
GO
/****** Object:  StoredProcedure [dbo].[SaveBatch_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 05-11-2015
-- Description:	Save AND Update Code of Batch Form
-- =============================================
CREATE PROCEDURE [dbo].[SaveBatch_SP] --0,'kjkjk','fhg',4,5,1,'4:8','5:5',3,8,10,1,8,'2015-11-07',1,0
	(
	@BatchID int,
	@BatchName nvarchar(50),
	@BatchCode nvarchar(50),
	@ClassID int,
	@LectureDuration int,
	@IsLunchBreak int,
	@LunchBreakStartTime nvarchar(50),
	@LunchBreakEndTime nvarchar(50),
	@MaxNoLecturesDay int,
	@MaxNoLecturesWeek int,
	@IsAllowMoreThanOneLectInBatch int,
	@MaxNoOfLecureInRow int,
	@UpdatedByUserID int,
	@UpdatedDate nvarchar(50),
	@IsActive int,
	@IsDeleted int
	)
AS
DECLARE @msg nvarchar(MAX),@Output int =0
BEGIN
	IF(@BatchID=0)--Check for Edit Or Update 0 for new entry and onther no update
		BEGIN
			IF NOT EXISTS (SELECT @BatchID FROM [Batches] Where BatchName=@BatchName)--Check Whether given name Already exist or not
				BEGIN
					IF NOT EXISTS (SELECT BatchID FROM [Batches] Where BatchCode=@BatchCode) --Check Whether Batch code already Exists Or Not
						BEGIN-- Insert into Data into Batch Table
							INSERT INTO [Batches] (BatchName,BatchCode,ClassID,LectureDuration,IsLunchBreak,LunchBreakStartTime,LunchBreakEndTime,MaxNoLecturesDay,MaxNoLecturesWeek,IsAllowMoreThanOneLectInBatch,MaxNoOfLecureInRow,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive,IsDeleted)
							VALUES (@BatchName,@BatchCode,@ClassID,@LectureDuration,@IsLunchBreak,@LunchBreakStartTime,@LunchBreakEndTime,@MaxNoLecturesDay,@MaxNoLecturesWeek,@IsAllowMoreThanOneLectInBatch,@MaxNoOfLecureInRow,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@UpdatedDate,@IsActive,@IsDeleted)
							set @Output = (select (MAX(BatchID)) from [Batches])
							IF (@@ROWCOUNT=1)--Check Row effected Or not
								BEGIN
									EXEC SaveLog_SP 'Batch Inserted Sucessfully.',@UpdatedDate,'Batch',@BatchID --Enter in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected or Not
										BEGIN
											SET @msg=(SELECT [Message]	FROM [Messages] WHERE MessageID=1)--Set Message to return
										END
								END
							ELSE
								BEGIN
									EXEC SaveLog_SP 'Error To Save Details.',@UpdatedDate,'Batch',@BatchID --Enter in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected Or Not
										BEGIN
											SET @msg=(SELECT [Message]	FROM [Messages] WHERE MessageID=2)--Set Message To Return
										END
								END
						END
					ELSE--error for Duplicate Batch Code
						BEGIN
						EXEC SaveLog_SP 'Batch Code Duplication',@UpdatedDate,'Batch',@BatchID--Enter in Log Table
							IF (@@ROWCOUNT=1)
								BEGIN
									SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=15)--Set Message To Return
								END
						END
				END
			ELSE--Error for Duplicate Batch Name
				BEGIN
					EXEC SaveLog_SP 'Batch Name Duplication',@UpdatedDate,'Batch',@BatchID--Enter in Log Table
					IF (@@ROWCOUNT=1)
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=14)--Set Message To Return
						END
				END
		END
	ELSE
		BEGIN
			IF NOT EXISTS (SELECT BatchID FROM [Batches] Where BatchName=@BatchName AND BatchID <> @BatchID)--Check Whether Subject Name Exist other Than SubjectID
				BEGIN
					IF NOT EXISTS (SELECT BatchID FROM [Batches] Where BatchCode=@BatchCode AND BatchID <> @BatchID )--Check Subject Short Name Available for other Than that subject ID
						BEGIN--UPDATE SP
							UPDATE [Batches] SET BatchName=@BatchName,BatchCode=@BatchCode,ClassID=@ClassID,LectureDuration=@LectureDuration,IsLunchBreak=@IsLunchBreak,IsActive=@IsActive,IsDeleted=@IsDeleted,
							LunchBreakStartTime=@LunchBreakStartTime,LunchBreakEndTime=@LunchBreakEndTime,MaxNoLecturesDay=@MaxNoLecturesDay,MaxNoLecturesWeek=@MaxNoLecturesWeek,IsAllowMoreThanOneLectInBatch=@IsAllowMoreThanOneLectInBatch,MaxNoOfLecureInRow=@MaxNoOfLecureInRow,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate
							WHERE BatchID=@BatchID
							set @Output = @BatchID
							IF(@@ROWCOUNT=1)--Check Row Effected or Not
								BEGIN
									EXEC SaveLog_SP 'Batch Updated Sucessfully',@UpdatedDate,'Batches',@BatchID--Entry in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected Or Not
										BEGIN
											SET @msg =(SELECT [Message] FROM [Messages] Where MessageID=5)--Set message
										END
								END
					
						END
					ELSE--Batch Name Duplicateion
						BEGIN
							EXEC SaveLog_SP 'Batch Code Duplication',@UpdatedDate,'Batches',@BatchID--Entry in Log Table
							IF (@@ROWCOUNT=1)
								BEGIN
									SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=10)--Set Message
								END		
						END
				END
			ELSE
				BEGIN
					EXEC SaveLog_SP 'Batch Name Duplication',@UpdatedDate,'Batches',@BatchID--Entery In Log Table
					IF (@@ROWCOUNT=1)--Check row Effected
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=14)--set Message
						END
				END
			
			
		END
		
	SELECT @Output
	
END
GO
/****** Object:  Table [dbo].[TimeTable]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTable](
	[TimeTableID] [int] IDENTITY(1,1) NOT NULL,
	[TimeTableStartDate] [date] NOT NULL,
	[BatchID] [int] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[UpdatedByUserID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[IsActive] [int] NOT NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [TimeTableID] PRIMARY KEY CLUSTERED 
(
	[TimeTableID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Test_Sp]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 12 Dec 2015
-- Description:	Test_SP
-- =============================================
CREATE PROCEDURE [dbo].[Test_Sp] 
	
AS
BEGIN
	SELECT TimeTableID,TimeTableStartDate,BatchID,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive FROM TimeTable
END
GO
/****** Object:  Table [dbo].[TeacherSubject]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeacherSubject](
	[TeacherSubjectID] [int] IDENTITY(1,1) NOT NULL,
	[TeacherID] [int] NOT NULL,
	[BatchSubjectID] [int] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[UpdatedByUserID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[IsActive] [bit] NULL,
	[IsDeleted] [bit] NULL,
 CONSTRAINT [TeacherSubjectID] PRIMARY KEY CLUSTERED 
(
	[TeacherSubjectID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ProcedureName]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 30-11-2015
-- Description:	BindTimeSlot_SP
-- =============================================
CREATE PROCEDURE [dbo].[ProcedureName] 
	(
	@BatchAvailableID int	
 	)
AS
BEGIN
SELECT 0 AS BatchAvailableID,'Select' AS Day
	Union
	select BatchAvailableID,DAY from [BatchAvailable]
	where BatchAvailableID like case when @BatchAvailableID<>0 then @BatchAvailableID else CONVERT (nvarchar(50),@BatchAvailableID) end
	and IsActive = 'True' and IsDeleted ='False'
END
GO
/****** Object:  StoredProcedure [dbo].[BindDay_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 28-11-2015
-- Description:	Bind Day form three tables
-- =============================================
CREATE PROCEDURE [dbo].[BindDay_SP] 
(
	@BatchID int,
	@RoomID int,
	@TeacherID int
)
AS
BEGIN
if (@BatchID<>0 AND @RoomID=0 AND @TeacherID=0)
BEGin

select 0 as BatchAvailableID, 'Select' as [Day]
union
	
	select ba.BatchAvailableID, ba.[Day] from [BatchAvailable] ba 
inner join Batches b
on b.BatchID = ba.BatchID
where
b.BatchID like case when @BatchID <>0 then @BatchID else CONVERT(nvarchar(50),BA.BatchID)end
and b.IsActive=1 and b.IsDeleted = 'False' and ba.IsActive=1
END

ELSE if (@BatchID=0 AND @RoomID<>0 AND @TeacherID=0)
BEGin
select 0 as RoomAvailableID, 'Select' as [Day]
union
	
	select ra.RoomAvailableID, ra.[Day] from [RoomAvailable] ra 
	
where
RA.RoomID like case when @RoomID <>0 then @RoomID else CONVERT(nvarchar(50),RA.RoomID)end
and ra.IsActive=1 and ra.IsDeleted = 'False' 
END

if (@BatchID=0 AND @RoomID=0 AND @TeacherID<>0)
BEGin
select 0 as TeacherAvailableID, 'Select' as [Day]
union
	
	select TA.TeacherAvailableID, TA.[Day] from TeacherAvailable Ta 
	inner join Teacher t
	on t.TeacherID = Ta.TeacherID
where
TA.TeacherID like case when @TeacherID <>0 then @TeacherID else CONVERT(nvarchar(50),TA.TeacherID)end
and TA.IsActive=1 and TA.IsDeleted = 'False' 
END


END
GO
/****** Object:  StoredProcedure [dbo].[BindTimeSlotDropDown_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 30-11-2015
-- Description:	BindTimeSlot in timetable form
-- =============================================
CREATE PROCEDURE [dbo].[BindTimeSlotDropDown_SP] --0,0,0,0,0,0,3,1,3
	(
	@BatchAvailableID int,
	@BatchID int,
	@Day int,
	@RoomAvailableID int,
	@RoomID int,
	@Day1 int,
	@TeacherAvailableID int,
	@TeacherID int,
	@Day2 int
 	)
AS
BEGIN
if((@BatchAvailableID<>0 and @BatchID<>0 and @Day<>0)and(@RoomAvailableID =0 and @RoomId = 0 and @Day1 =0) and(@TeacherAvailableID =0 and @TeacherID = 0 and @Day2 =0))
Begin
    SELECT 0 AS BatchAvailableID,'Select' AS TimeSlot
	Union
	select BatchAvailableID,convert(NVARCHAR(8),StartTime)+' - '+convert(nvarchar(8),EndTime) AS 'TimeSlot' from [BatchAvailable] ba
	inner join Batches b
	on b.BatchID = ba.BatchID
	where BatchAvailableID like case when @BatchAvailableID<>0 then @BatchAvailableID else CONVERT (nvarchar(50),BatchAvailableID) end
	and b.BatchID like case when @BatchID <>0 then @BatchID else CONVERT(nvarchar(50),b.BatchID)end 
	and ba.BatchAvailableID like case when @Day <> 0 THEN @Day ELSE CONVERT (NVARCHAR(50),ba.BatchAvailableID) END
	and ba.IsActive = 'True' and ba.IsDeleted ='False'
End
else if((@BatchAvailableID=0 and @BatchID=0 and @Day=0)and(@RoomAvailableID <>0 and @RoomId <> 0 and @Day1<>0) and(@TeacherAvailableID =0 and @TeacherID = 0 and @Day2 =0))
Begin
    SELECT 0 AS RoomAvailableID,'Select' AS TimeSlot
	Union
	select RoomAvailableID,convert(NVARCHAR(8),StartTime)+' - '+convert(nvarchar(8),EndTime) AS 'TimeSlot' from [RoomAvailable] ra
	inner join BranchesRooms br
	on br.RoomID = ra.RoomID
	where RoomAvailableID like case when @RoomAvailableID<>0 then @RoomAvailableID else CONVERT (nvarchar(50),RoomAvailableID) end
	and br.RoomID like case when @RoomID <>0 then @RoomID else CONVERT(nvarchar(50),br.RoomID)end 
	and ra.RoomAvailableID like case when @Day1 <> 0 THEN @DAy1 ELSE CONVERT (NVARCHAR(50),ra.RoomAvailableID) END
	and ra.IsActive = 'True' and ra.IsDeleted ='False'
End	
if((@BatchAvailableID=0 and @BatchID=0 and @Day=0)and(@RoomAvailableID=0 and @RoomId = 0 and @Day1= 0) and(@TeacherAvailableID<>0 and @TeacherID <> 0 and @Day2 <> 0))
Begin
    SELECT 0 AS TeacherAvailableID,'Select' AS TimeSlot
	Union
	select TeacherAvailableID,convert(NVARCHAR(8),StartTime)+' - '+convert(nvarchar(8),EndTime) AS 'TimeSlot' from [TeacherAvailable] ta
	inner join Teacher t
	on t.TeacherID = ta.TeacherID
	where TeacherAvailableID like case when @TeacherAvailableID<>0 then @TeacherAvailableID else CONVERT (nvarchar(50),TeacherAvailableID) end
	and t.TeacherID like case when @TeacherID <>0 then @TeacherID else CONVERT(nvarchar(50),t.TeacherID)end 
	and ta.TeacherAvailableID like case when @Day2 <> 0 THEN @Day2 ELSE CONVERT (NVARCHAR(50),ta.TeacherAvailableID) END
	and ta.IsActive = 'True' and ta.IsDeleted ='False'
End	  
END
GO
/****** Object:  StoredProcedure [dbo].[SaveBatchSubject_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 20 Nov 2015
-- Description:	Save Batch Subject
-- =============================================
CREATE PROCEDURE [dbo].[SaveBatchSubject_SP] 
	(
	
	@SubjectID int,
	@BatchID int,
	@NoLectPerDay int,
	@NoLectPerWeek int,
	@UpdatedByUserID int,
	@UpdatedDate NVARCHAR(50),
	@IsActive int,
	@IsDeleted int
	)
AS
DECLARE @msg NVARCHAR(MAX)
DECLARE @MaxID int
BEGIN
	IF NOT EXISTS(SELECT BatchSubjectID FROM BatchSubject WHERE SubjectID=@SubjectID AND BatchID=@BatchID)
		BEGIN
			INSERT INTO BatchSubject (SubjectID,BatchID,FrequencyPerDay,FrequencyPerWeek,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive,IsDeleted)
			VALUES (@SubjectID,@BatchID,@NoLectPerDay,@NoLectPerWeek,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@UpdatedDate,@IsActive,@IsDeleted)
			
			If(@@ROWCOUNT=1)--Save sucessFull
				BEGIN
					SET @MaxID= (SELECT MAX(BatchSubjectID)FROM BatchSubject)
					EXEC SaveLog_SP 'Batch Subject Save Sucessfully.',@UpdatedDate,'BatchSubject',@MaxID
					SET @msg = (SELECT [Message] FROM [Messages] WHERE MessageID=1)
				END
			ELSE--Error to save
				BEGIN 
					SET @MaxID= (SELECT MAX(BatchSubjectID)FROM BatchSubject)
					EXEC SaveLog_SP 'Error To Save Batch Subject ',@UpdatedDate,'BatchSubject',@MaxID
					SET @msg = (SELECT [Message] FROM [Messages] WHERE MessageID=2)
				END
		END
	ELSE
		BEGIN
			UPDATE BatchSubject SET FrequencyPerDay=@NoLectPerDay, FrequencyPerWeek=@NoLectPerWeek,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate,IsActive=@IsActive,IsDeleted=@IsDeleted
			WHERE BatchID=@BatchID AND SubjectID=@SubjectID
			
			If(@@ROWCOUNT=1)--Update sucessFull
				BEGIN
					SET @MaxID= (SELECT MAX(BatchSubjectID)FROM BatchSubject WHERE BatchID=@BatchID AND SubjectID=SubjectID)
					EXEC SaveLog_SP 'Batch Subject Updated Sucessfully.',@UpdatedDate,'BatchSubject',@MaxID
					SET @msg = (SELECT [Message] FROM [Messages] WHERE MessageID=5)
				END
			ELSE--Error to Update
				BEGIN 
					SET @MaxID= (SELECT MAX(BatchSubjectID)FROM BatchSubject WHERE BatchID=@BatchID AND SubjectID=SubjectID)
					EXEC SaveLog_SP 'Error To Save Batch Subject ',@UpdatedDate,'BatchSubject',@MaxID
					SET @msg = (SELECT [Message] FROM [Messages] WHERE MessageID=2)
				END
		END	
		SELECT @msg
END
GO
/****** Object:  StoredProcedure [dbo].[SaveBatchAvailable_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:Pranjali Vidhate
-- Create date: 21-11-2015
-- Description:	To save batch availibility
-- =============================================
CREATE PROCEDURE [dbo].[SaveBatchAvailable_SP]

(
	
	@BatchID int,
	@Day NVARCHAR(50),
	@StartTime NVARCHAR(50),
	@EndTime NVARCHAR(50),
	@UpdatedByUserID int,
	@UpdatedDate NVARCHAR(50),
	@IsActive int,
	@IsDeleted int
	)
AS
DECLARE @msg NVARCHAR(50)
DECLARE @MaxID int
BEGIN
	IF NOT EXISTS (SELECT BatchAvailableID FROM BatchAvailable WHERE BatchID=@BatchID AND [Day]=@Day)
		BEGIN
			INSERT INTO BatchAvailable(BatchID,[Day],StartTime,EndTime,CreatedByUserID,UpdatedByUserID,UpdatedDate,IsActive,IsDeleted)
			VALUES (@BatchID,@Day,@StartTime,@EndTime,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@IsActive,@IsDeleted)
			IF(@@ROWCOUNT=1)
				BEGIN
					SELECT @MaxID=(SELECT MAX(BatchAvailableID) FROM BatchAvailable)
					EXEC SaveLog_SP 'Save Batch Availibility.',@UpdatedDate,'BatchAvailable',@MaxID 
					set @msg=(SELECT [Message] FROM [Messages] WHERE MessageID=1)
				END
			ELSE
				BEGIN
					SELECT @MaxID=(SELECT MAX(BatchAvailableID) FROM BatchAvailable)
					EXEC SaveLog_SP ' Error To Save Batch Availibility.',@UpdatedDate,'BatchAvailable',@MaxID 
					set @msg=(SELECT [Message] FROM [Messages] WHERE MessageID=2)
				END
			
		END
	ELSE
		BEGIN
			UPDATE BatchAvailable SET StartTime=@StartTime,EndTime=@EndTime,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate,IsActive=@IsActive,IsDeleted=@IsDeleted
			WHERE [Day]=@Day AND BatchID=@BatchID
			IF(@@ROWCOUNT=1)
				BEGIN
					SELECT @MaxID=(SELECT BatchAvailableID  FROM BatchAvailable WHERE BatchID=@BatchID AND [DAY]=@Day)
					EXEC SaveLog_SP 'Update Batch Availibility.',@UpdatedDate,'BatchAvailable',@MaxID 
					set @msg=(SELECT [Message] FROM [Messages] WHERE MessageID=5)
				END
			ELSE
				BEGIN
					SELECT @MaxID=(SELECT BatchAvailableID  FROM BatchAvailable WHERE BatchID=@BatchID AND [DAY]=@Day)
					EXEC SaveLog_SP 'Error To Update Batch Availibility.',@UpdatedDate,'BatchAvailable',@MaxID 
					set @msg=(SELECT [Message] FROM [Messages] WHERE MessageID=2)
				END
			
		
		END
		SELECT @msg
		
END
GO
/****** Object:  StoredProcedure [dbo].[loadSubjectName_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 28-11-2015
-- Description:	To Bind Subject using id
-- =============================================
CREATE PROCEDURE [dbo].[loadSubjectName_SP]-- 4
	(
	@BatchID int	
 	)
AS
BEGIN
	SELECT 0 AS SubjectID,'Select' AS SubjectName
	Union
	SELECT s.SubjectID,s.SubjectName  from [Subject] s
	inner join BatchSubject bs
	on bs.SubjectID = s.SubjectID
	INNER JOIN Batches b
	on b.BatchID = bs.BatchID
	where
	b.BatchID like case when @BatchID <> 0 then @BatchID else CONVERT(nvarchar(50),@BatchID)end
	  and b.IsActive=1 AND b.IsDeleted='False'

END
GO
/****** Object:  StoredProcedure [dbo].[GetNoOfDaysBatchAvailable_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 07 Nov 2015
-- Description:	Get NO of Days Batch Available	
-- =============================================
CREATE PROCEDURE [dbo].[GetNoOfDaysBatchAvailable_SP] 
			
AS
BEGIN
	Select b.BatchID,b.BatchName, COUNT (BatchAvailableID) AS 'NoOfDaysAvailaible' From BatchAvailable bAvail
	INNER JOIN Batches b
	ON b.BatchID=bAvail.BatchID
	Where bAvail.BatchID=bAvail.BatchID AND bAvail.IsActive ='True' AND bAvail.IsDeleted='False' AND b.IsActive='True'
	GROUP BY b.BatchID,b.BatchName
END
GO
/****** Object:  StoredProcedure [dbo].[GetBranchSubject_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D.Sortee
-- Create date: 02 Dec 2015
-- Description:	Get Subject list which is teach at batch on brancch id
-- =============================================
CREATE PROCEDURE [dbo].[GetBranchSubject_SP] 
	-- Add the parameters for the stored procedure here
	@BranchID int
AS
BEGIN
	SELECT 0 AS 'SubjectID','Select' AS 'SubjectName'
	UNION
	SELECT DISTINCT sub.SubjectID,sub.SubjectName FROM BatchSubject btsub
	INNER JOIN [Batches] bt
	ON bt.BatchID=btsub.BatchID
	INNER JOIN Class cl
	ON  cl.ClassID=bt.ClassID
	INNER JOIN Branch br
	ON br.BranchID=cl.BranchID
	INNER JOIN [Subject]  sub
	ON sub.SubjectID=btsub.SubjectID
	WHERE br.BranchID LIKE CASE WHEN @BranchID<>0 THEN @BranchID ELSE CONVERT(NVARCHAR(50),br.BranchID) END
	
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteBatchSubject_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 20 Nov 2015
-- Description:	Delete Batch Subject
-- =============================================
CREATE PROCEDURE [dbo].[DeleteBatchSubject_SP] 
	(
	@BatchID int,
	@SubjectID int,
	@UpdatedByUserID int,
	@UpdatedDate nvarchar(50)
	)
AS
Declare @msg NVARCHAR(MAX)
DECLARE @MaxID int
BEGIN
	UPDATE BatchSubject SET IsActive=0,IsDeleted=1,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate
	WHERE BatchID=@BatchID AND SubjectID=@SubjectID
	IF(@@ROWCOUNT=1)
		BEGIN
			SET @MaxID=(SELECT BatchSubjectID FROM BatchSubject WHERE BatchID=@BatchID AND SubjectID=@SubjectID)
			EXEC SaveLog_SP 'Batch Subject Deleted SucessFully',@UpdatedDate,'BatchSubject',@MaxID
			SET @msg= (Select [Message] FROM [Messages] WHERE MessageID=12 )
		END
	ELSE
		BEGIN
			SET @MaxID=(SELECT BatchSubjectID FROM BatchSubject WHERE BatchID=@BatchID AND SubjectID=@SubjectID)
			EXEC SaveLog_SP 'Error To Delete Batch Subject',@UpdatedDate,'BatchSubject',@MaxID
			SET @msg= (Select [Message] FROM [Messages] WHERE MessageID=13 )
		END
	
	SELECT @msg
END
GO
/****** Object:  StoredProcedure [dbo].[GetBatchAvailableDetail_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Pranajli Vidhate
-- Create date: 21-11-2015
-- Description:	To get Batch availability details
-- =============================================
CREATE PROCEDURE [dbo].[GetBatchAvailableDetail_SP] 
	(
	   @BatchID int 
	)
AS
BEGIN
	SELECT BatchAvailableID,BatchID,[DAY],StartTime,EndTime FROM BatchAvailable
	WHERE BatchID LIKE CASE WHEN @BatchID<>0 THEN @BatchID ELSE CONVERT (NVARCHAR(50),BatchID) END
	AND IsActive='True' AND IsDeleted='False'
END
GO
/****** Object:  StoredProcedure [dbo].[GetBatchSubjectCount_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 20 Nov 2015
-- Description:	Get Batch Subject Count
-- =============================================
CREATE PROCEDURE [dbo].[GetBatchSubjectCount_SP] 
 
   --@BatchID int,
   --@SubjectID int
 
AS
BEGIN

	SELECT br.BranchID,br.BranchName,bt.BatchID,bt.BatchName, COUNT(bs.BatchSubjectID) AS 'NoOfSubject'
	FROM BatchSubject bs
	
	INNER JOIN [Batches] bt
	ON bt.BatchID=bs.BatchID
	
	INNER JOIN [Subject] sub
	ON sub.SubjectID=bs.SubjectID
	
	INNER JOIN [Class] cl
	ON cl.ClassID=bt.ClassID
	
	INNER JOIN [Branch] br
	ON br.BranchID= cl.BranchID
	
	WHERE br.IsActive=1 AND bt.IsActive='True' AND sub.IsActive='True' AND cl.IsActive='True' AND bs.IsDeleted<>'True'
	--AND bs.BatchID LIKE CASE WHEN @BatchID<>0 THEN @BatchID ELSE CONVERT (NVARCHAR(50),@BatchID)END
	--AND bs.SubjectID LIKE CASE WHEN @SubjectID<>0 THEN @SubjectID ELSE CONVERT(NVARCHAR(50),@SubjectID) END
	
	GROUP BY br.BranchID,br.BranchName,bt.BatchID,bt.BatchName
	
END
GO
/****** Object:  StoredProcedure [dbo].[GetBatchSubject_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 20 Nov 2015
-- Description:	Get Subject List
-- =============================================
CREATE PROCEDURE [dbo].[GetBatchSubject_SP] 
(
	@BatchID int  ,
	@SubjectID int
)
AS
BEGIN
	SELECT bs.BatchSubjectID, sub.SubjectID,sub.SubjectName,bs.FrequencyPerDay,bs.FrequencyPerWeek,
	CASE bs.IsActive WHEN'True' THEN 'Active' ELSE 'InActive'END  AS 'Status' ,
	bs.IsActive
	  FROM [Subject] sub
	INNER JOIN BatchSubject bs
	On bs.SubjectID=sub.SubjectID
	INNER JOIN [Batches] bt
	ON bt.BatchID=bs.BatchID
	
	WHERE  bs.IsDeleted='False' AND bt.IsActive=1 AND sub.IsActive=1
	AND bs.BatchID LIKE CASE WHEN @BatchID <>0 THEN @BatchID ELSE CONVERT(NVARCHAR(50),bs.BatchID) END
	AND bs.SubjectID LIKE CASE WHEN @SubjectID <>0 THEN @SubjectID ELSE CONVERT(NVARCHAR(50),bs.SubjectID) END
END
GO
/****** Object:  StoredProcedure [dbo].[GetBatchOnSubject_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 21 Nov 2015
-- Description:	Get Batch list on Subject ID
-- =============================================
CREATE PROCEDURE [dbo].[GetBatchOnSubject_SP] --18,11,8
	(
	@TeacherID int,
	@BranchID int,
	@SubjectID int
	)
AS
BEGIN
	IF NOT EXISTS (SELECT TeacherSubjectID FROM TeacherSubject WHERE TeacherID=@TeacherID)
		BEGIN
			SELECT btsub.BatchSubjectID,bt.BatchName,br.BranchName,0 As mybool,cl.ClassName FROM  BatchSubject btsub
	
			INNER JOIN [Batches] bt
			ON bt.BatchID=btsub.BatchID
			INNER JOIN Class cl
			ON cl.ClassID=bt.ClassID
			INNER JOIN Branch br
			ON br.BranchID=cl.BranchID
	
			WHERE  btsub.IsActive='True'
			AND  br.BranchID LIKE CASE WHEN @BranchID <>0 THEN @BranchID ELSE CONVERT (NVARCHAR(50),br.BranchID) END
			AND btsub.SubjectID LIKE CASE WHEN @SubjectID <>0 THEN @SubjectID ELSE CONVERT (NVARCHAR(50),btsub.SubjectID) END
		END
	ELSE
		BEGIN
			SELECT btsub.BatchSubjectID,bt.BatchName,br.BranchName,teasub.IsActive As mybool,cl.ClassName FROM  TeacherSubject teasub
			
			INNER JOIN BatchSubject btsub
			ON btsub.BatchSubjectID=teasub.BatchSubjectID
			INNER JOIN [Batches] bt
			ON bt.BatchID=btsub.BatchID
			INNER JOIN Class cl
			ON cl.ClassID=bt.ClassID
			INNER JOIN Branch br
			ON br.BranchID=cl.BranchID
			Where teasub.TeacherID LIKE CASE WHEN @TeacherID <>0 Then @TeacherID ELSE CONVERT (NVARCHAR(50),teasub.TeacherID) END
			AND btsub.SubjectID LIKE CASE WHEN @SubjectID<> 0 THEN @SubjectID ELSE CONVERT(NVARCHAR(50),btsub.SubjectID) END
			AND  br.BranchID LIKE CASE WHEN @BranchID <>0 THEN @BranchID ELSE CONVERT (NVARCHAR(50),br.BranchID) END
			union
			SELECT btsub.BatchSubjectID,bt.BatchName,br.BranchName ,'False' As mybool,cl.ClassName FROM  BatchSubject btsub
	
			INNER JOIN [Batches] bt
			ON bt.BatchID=btsub.BatchID
			INNER JOIN Class cl
			ON cl.ClassID=bt.ClassID
			INNER JOIN Branch br
			ON br.BranchID=cl.BranchID
	
			WHERE  btsub.IsActive='True'
			AND  br.BranchID LIKE CASE WHEN @BranchID <>0 THEN @BranchID ELSE CONVERT (NVARCHAR(50),br.BranchID) END
			AND btsub.SubjectID LIKE CASE WHEN @SubjectID <>0 THEN @SubjectID ELSE CONVERT (NVARCHAR(50),btsub.SubjectID) END
			AND btsub.BatchSubjectID NOT IN (SELECT BatchSubjectID FROM TeacherSubject Where TeacherID=@TeacherID)
		END
	
END
GO
/****** Object:  StoredProcedure [dbo].[BindTeacherSubject_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 10 Dec 2015
-- Description:	Display Teacher Teaches Subject
-- =============================================
CREATE PROCEDURE [dbo].[BindTeacherSubject_SP] --1
	(
		@TeacherID int
	)
AS
BEGIN
	SELECT t.TeacherID,t.TeacherName +' ' +t.TeacherSurname + '['+t.TeacherShortName+']' AS TeacherName,sub.SubjectID,sub.SubjectName,br.BranchID,br.BranchName,bt.BatchID,bt.BatchName
	FROM TeacherSubject ts
	INNER JOIN Teacher t
	ON t.TeacherID =ts.TeacherID
	INNER JOIN BatchSubject bs
	ON bs.BatchSubjectID=ts.BatchSubjectID
	INNER JOIN [Subject] sub
	ON sub.SubjectID=bs.SubjectID
	INNER JOIN [Batches] bt
	ON bt.BatchID =bs.BatchID
	INNER JOIN Class cl
	On cl.ClassID=bt.ClassID
	INNER JOIN Branch br
	ON Br.BranchID=cl.BranchID
	where ts.IsActive='True' AND t.IsActive='True' AND sub.IsActive='True'AND bt.IsActive='True' AND br.IsActive=1
	AND ts.TeacherID LIKE CASE WHEN @TeacherID<>0 THEN @TeacherID ELSE CONVERT(NVARCHAR(50),ts.TeacherID) END
END
GO
/****** Object:  StoredProcedure [dbo].[BindSubjectName1_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: pranjali Vidhate
-- Create date: 2015-08-12
-- Description:	To Bind Subject in TimeTable Teacherwise
-- =============================================
CREATE PROCEDURE [dbo].[BindSubjectName1_SP] --5,5
(
	@BatchID int,
	@TeacherID int
 	)
AS
BEGIN
SELECT 0 AS TeacherSubjectID,'Select' AS SubjectName 
UNION
select ts.TeacherSubjectID,s.SubjectName  from TeacherSubject ts
inner join BatchSubject bs
on bs.BatchSubjectID = ts.BatchSubjectID
inner join Subject s
on s.SubjectID = bs.SubjectID
inner join Teacher t
on t.TeacherID = ts.TeacherID



where ts.TeacherID like case when @TeacherID<>0 then @TeacherID else CONVERT(nvarchar(50),ts.TeacherID) end
AND bs.BatchID LIKE CASE WHEN @BatchID<>0 THEN @BatchID ELSE CONVERT(NVARCHAR(50),bs.BatchID) END
AND ts.IsDeleted<>'True' AND ts.IsActive='True'
ORDER BY SubjectName
END
GO
/****** Object:  StoredProcedure [dbo].[BindTeacherDropDown_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 30-11-2015
-- Description:	bind teacher dropdown on timetable form depend on subject
-- =============================================
CREATE PROCEDURE [dbo].[BindTeacherDropDown_SP] --5,5
	(
	@SubjectID int,
	@BatchID int
 	)
AS
BEGIN
SELECT 0 AS TeacherSubjectID,'Select' AS TeacherName 
UNION
select ts.TeacherSubjectID, t.TeacherName+' '+t.TeacherSurname+'['+t.TeacherShortName+']' AS TeacherName from TeacherSubject ts
inner join Teacher t
on t.TeacherID = ts.TeacherID
inner join BatchSubject bs
on bs.BatchSubjectID = ts.BatchSubjectID



where bs.SubjectID like case when @SubjectID<>0 then @SubjectID else CONVERT(nvarchar(50),bs.SubjectID) end
AND bs.BatchID LIKE CASE WHEN @BatchID<>0 THEN @BatchID ELSE CONVERT(NVARCHAR(50),bs.BatchID) END
AND ts.IsDeleted<>'True' AND ts.IsActive='True'
ORDER BY TeacherName
END
GO
/****** Object:  StoredProcedure [dbo].[SaveTeacherBatchSubject_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 23 Nov 2015
-- Description:	save Teacher Batch Subjet
-- =============================================
CREATE PROCEDURE [dbo].[SaveTeacherBatchSubject_SP] --8,26,1,'2015-12-02',True,0
	(
	
	@TeacherID int,
	@BatchSubjectID int,
	@UpdatedByUserID int,
	@UpdatedDate nvarchar(50),
	@IsActive NVARCHAR(15),
	@IsDeleted int
	)
AS
DECLARE @msg nvarchar(MAX)
DECLARE @MaxID int
BEGIN
  IF NOT EXISTS(SELECT TeacherSubjectID FROM TeacherSubject WHERE TeacherID=@TeacherID AND BatchSubjectID=@BatchSubjectID)
  BEGIN
	INSERT INTO TeacherSubject (TeacherID,BatchSubjectID,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive,IsDeleted)
	VALUES (@TeacherID,@BatchSubjectID,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@UpdatedDate,@IsActive,@IsDeleted)
		IF (@@ROWCOUNT=1)
			BEGIN
				SET @MaxID =(SELECT MAX(TeacherSubjectID) FROM TeacherSubject)
				EXEC SaveLog_SP 'Teacher Batch Subject Save Sucessfully',@UpdatedDate,'TeacherSubject',@MaxID
				
				SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=1)
			END
		ELSE
			BEGIN
			SET @MaxID =(SELECT TeacherSubjectID FROM TeacherSubject)
				EXEC SaveLog_SP 'Error To Save Teacher Batch Subject',@UpdatedDate,'TeacherSubject',@MaxID
				
				SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=2)
			END
	END
	ELSE
		BEGIN
			UPDATE TeacherSubject SET BatchSubjectID=@BatchSubjectID,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate,IsActive=@IsActive,IsDeleted=@IsDeleted
			WHERE TeacherID=@TeacherID AND BatchSubjectID=@BatchSubjectID
			
			IF (@@ROWCOUNT=1)
			BEGIN
				SET @MaxID =(SELECT MAX(TeacherSubjectID) FROM TeacherSubject WHERE TeacherID=@TeacherID)
				EXEC SaveLog_SP 'Teacher Batch Subject Update Sucessfully',@UpdatedDate,'TeacherSubject',@MaxID
				
				SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=1)
			END
		ELSE
			BEGIN
			SET @MaxID =(SELECT TeacherSubjectID FROM TeacherSubject WHERE TeacherID=@TeacherID)
				EXEC SaveLog_SP 'Error To Update Teacher Batch Subject',@UpdatedDate,'TeacherSubject',@MaxID
				
				SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=2)
			END
		END
		
		SELECT @msg
	
END
GO
/****** Object:  Table [dbo].[TimeTableDetail]    Script Date: 12/16/2015 19:51:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TimeTableDetail](
	[TimeTableDetailID] [int] IDENTITY(1,1) NOT NULL,
	[RoomID] [int] NOT NULL,
	[Day] [nvarchar](15) NOT NULL,
	[LectStartTime] [time](7) NOT NULL,
	[LectEndTime] [time](7) NOT NULL,
	[TeacherSubjectID] [int] NOT NULL,
	[CreatedByUserID] [int] NOT NULL,
	[UpdatedByUserID] [int] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[UpdatedDate] [datetime] NOT NULL,
	[TimeTableID] [int] NOT NULL,
	[ViewType] [nvarchar](20) NULL,
 CONSTRAINT [PK_TimeTableDetail] PRIMARY KEY CLUSTERED 
(
	[TimeTableDetailID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[ValidateTimeTable_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 09 Dec 2015
-- Description:	Applying rules to the Timetable
-- =============================================
CREATE PROCEDURE [dbo].[ValidateTimeTable_SP] 
(
	@TeacherShortName nvarchar(20),
	@ClassRoomID int,
	@LectStartTime NVARCHAR(50),
	@LectEndTime NVARCHAR(50),
	@Day NVARCHAR(50),
	@BatchID int
)
AS
DECLARE @msg NVARCHAR(MAX)
BEGIN
	-- CHECK IF time slot for perticular time is already allocted to any room
	IF EXISTS (Select ttd.TimeTableDetailID FROM TimeTableDetail ttd INNER JOIN TimeTable tt ON tt.TimeTableID=ttd.TimeTableID WHERE ttd.[Day]=@Day AND ttd.LectStartTime=@LectStartTime AND ttd.LectEndTime=@LectEndTime AND ttd.RoomID =@ClassRoomID)
		BEGIN
			SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=21)
		END
	-- CHECK IF time slot for perticular time is already allocted to any Batch
	ELSE IF EXISTS (Select ttd.TimeTableDetailID FROM TimeTableDetail ttd INNER JOIN TimeTable tt ON tt.TimeTableID=ttd.TimeTableID WHERE ttd.[Day]=@Day AND ttd.LectStartTime=@LectStartTime AND ttd.LectEndTime=@LectEndTime AND tt.BatchID=@BatchID)
		BEGIN
			SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=23)
		END
	--check Teahcer overlap timing
	
	ELSE IF EXISTS(SELECT t.TeacherID, t.TeacherName FROM TimeTableDetail ttd
INNER JOIN  TeacherSubject ts
ON ts.TeacherSubjectID=ttd.TeacherSubjectID
INNER JOIN Teacher t
ON t.TeacherID=ts.TeacherID
INNER JOIN TimeTable tt
ON tt.TimeTableID =ttd.TimeTableID
WHERE ttd.[Day]=@Day AND ttd.LectStartTime=@LectStartTime AND ttd.LectEndTime=@LectEndTime
and BINARY_CHECKSUM(t.TeacherShortName)=BINARY_CHECKSUM(@TeacherShortName))
		BEGIN
			SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=23)
		END
	-- All things are ok to save Details
	ELSE 
		BEGIN
			SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=24)
		END
	SELECT @msg
END
GO
/****** Object:  StoredProcedure [dbo].[SaveTimeTableDetail_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 01-12-2015
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[SaveTimeTableDetail_SP]--1,1,Mon,02:10,03:15,1,1,1 
@TimeTableDetailID int,
@RoomID int,
@Day nvarchar(15),
@LectStartTime time(7),
@LectEndTime time(7),
@TeacherSubjectID int,
@UpdatedByUserID int,
@UpdatedDate nvarchar(50),
@TimeTableID int
	
AS
Declare @msg nvarchar(max)
BEGIN
		if(@TimeTableDetailID = 0)
		begin
		insert into TimeTableDetail(RoomID,Day,LectStartTime,LectEndTime,TeacherSubjectID,CreatedByUserID,UpdatedByUserID,TimeTableID,CreatedDate,UpdatedDate)
		VALUES (@RoomID,@Day,@LectStartTime,@LectEndTime,@TeacherSubjectID,@UpdatedByUserID,@UpdatedByUserID,@TimeTableID,CONVERT(datetime,GETDATE()),CONVERT (datetime,GETDATE()))
		if(@@ROWCOUNT=1)-- set msg to save
		  begin
		   exec SaveLog_SP 'TimeTable Save Sucessfully',@UpdatedDate,'TimeTable',@TimeTableID
		    begin 
		      set @msg = (select [Message] from [Messages] where MessageID = 1)
		    end
		 end
		else 
		   begin
		      exec SaveLog_SP 'Error to Save ',@UpdatedDate,'TimeTable',@TimeTableID
		       begin 
		            set @msg = (select [Message] from [Messages] where MessageID = 2)
		       end
		    end
		END
	ELSE
		BEGIN
		update TimeTableDetail set RoomID=@RoomID,Day=@Day,LectStartTime=@LectStartTime,LectEndTime=@LectEndTime,
		TeacherSubjectID=@TeacherSubjectID,UpdatedByUserID=@UpdatedByUserID,TimeTableID=@TimeTableID,UpdatedDate=convert(datetime, GETDATE())			
		if(@@ROWCOUNT=1)-- set msg to save
		  begin
		   exec SaveLog_SP 'TimeTable Updated Sucessfully',@UpdatedDate,'TimeTable',@TimeTableID
		    begin 
		      set @msg = (select [Message] from [Messages] where MessageID = 5)
		    end
		 end
		else 
		   begin
		      exec SaveLog_SP 'Error to Save ',@UpdatedDate,'TimeTable',@TimeTableID
		       begin 
		            set @msg = (select [Message] from [Messages] where MessageID = 2)
		       end
		    end
		
		END
END
GO
/****** Object:  StoredProcedure [dbo].[SaveTimeTable_SP]    Script Date: 12/16/2015 19:51:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 01-12-2015
-- Description:	Save TimeTable
-- =============================================
CREATE PROCEDURE [dbo].[SaveTimeTable_SP] --0,0,'2015-12-28',2,1,'mon','01:00:00','02:00:00',1,1,'05/12/2015',1,0
	@TimeTableID int,
	@TimeTableDetailID int,
	@TimeTableStartDate nvarchar(10),
	@BatchID int,
	@RoomID int,
	@Day nvarchar(50),
	@LectStartTime nvarchar(8),
	@LectEndTime nvarchar(8),
	@TeacherSubjectID int,
	@UpdatedByUserID int,
	@UpdatedDate nvarchar(50),
	@IsActive int,
	@IsDeleted int,
	@ViewType nvarchar(20)
AS
DECLARE @Output int=0, @msg nvarchar(max)
BEGIN
if(@TimeTableID=0 and @TimeTableDetailID = 0)
	BEGIN
		insert into TimeTable(TimeTableStartDate,BatchID,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive,IsDeleted)
		VALUES(@TimeTableStartDate,@BatchID,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@UpdatedDate,@IsActive,@IsDeleted)
		
    --if(@TimeTableDetailID = 0)
		begin
		Set @Output =( Select MAX(TimeTableID)  from TimeTable)
		insert into TimeTableDetail(RoomID,[Day],LectStartTime,LectEndTime,TeacherSubjectID,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,TimeTableID,ViewType)
		VALUES (@RoomID,@Day,@LectStartTime,@LectEndTime,@TeacherSubjectID,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@UpdatedDate,@Output,@ViewType)
		if(@@ROWCOUNT=1)-- set msg to save
		  begin
		   exec SaveLog_SP 'TimeTable Save Sucessfully',@UpdatedDate,'TimeTable',@TimeTableID
		    begin 
		      set @msg = (select [Message] from [Messages] where MessageID = 1)
		    end
		 end
		else 
		   begin
		      exec SaveLog_SP 'Error to Save ',@UpdatedDate,'TimeTable',@TimeTableID
		       begin 
		            set @msg = (select [Message] from [Messages] where MessageID = 2)
		       end
		   end
		END
     END
else
begin
		update TimeTable set TimeTableStartDate=@TimeTableStartDate,BatchID=@BatchID,UpdatedByUserID=@UpdatedByUserID,
		UpdatedDate= @UpdatedDate,IsActive=@IsActive,IsDeleted=@IsDeleted where TimeTableID= @TimeTableID
		BEGIN
		Set @Output= @TimeTableID
		update TimeTableDetail set RoomID=@RoomID,[Day]=@Day,LectStartTime=@LectStartTime,LectEndTime=@LectEndTime,
		TeacherSubjectID=@TeacherSubjectID,UpdatedByUserID=@UpdatedByUserID,TimeTableID=@Output,UpdatedDate=@UpdatedDate,ViewType=@ViewType where TimeTableDetailID =@TimeTableDetailID		
		if(@@ROWCOUNT=1)-- set msg to save
		  begin
		   exec SaveLog_SP 'TimeTable Updated Sucessfully',@UpdatedDate,'TimeTable',@TimeTableID
		    begin 
		      set @msg = (select [Message] from [Messages] where MessageID = 5)
		    end
		 end
		else 
		   begin
		      exec SaveLog_SP 'Error to Save ',@UpdatedDate,'TimeTable',@TimeTableID
		       begin 
		            set @msg = (select [Message] from [Messages] where MessageID = 2)
		       end
		    end
		
		END
end
		select @msg
END
GO
/****** Object:  StoredProcedure [dbo].[BindTable_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Pranjali Vidhate
-- Create date: 2015-12-05
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[BindTable_SP] --1,1

  -- @TimeTableID int
   --@TimeTableDetailID int	


AS
BEGIN
	select Distinct td.TimeTableID,b.BranchName,t.TimeTableStartDate,c.ClassName,ba.BatchName,br.RoomName,s.SubjectName, 
	te.TeacherName,t.IsActive,t.IsDeleted,t.UpdatedDate,
	case when t.IsActive =1  then 'Active' when t.IsActive =0 then 'InActive' end as [Status],
	td.TimeTableDetailID,t.BatchID,td.RoomID,td.[Day],td.LectStartTime,td.LectEndTime,td.TeacherSubjectID from TimeTable t
	inner join Batches ba
	on ba.BatchID =t.BatchID
	
	inner join class c
	on c.classID = ba.ClassID
	
	inner join  Branch b
	on b.BranchID =c.BranchID
	
	inner join TimeTableDetail td
	on t.TimeTableID =td.TimeTableID
	
	inner join BranchesRooms br
	on br.RoomID = td.RoomID
	
	inner join BatchSubject bs
	on bs.BatchID = ba.BatchID 
	 
	inner join [Subject] s
	on s.SubjectID = bs.BatchSubjectID
	
	inner join TeacherSubject ts
	on ts.BatchSubjectID =bs.BatchSubjectID
	
	inner join Teacher te
	on te.TeacherID = ts.TeacherID	
	
	where --t.TimeTableID LIKE CASE WHEN @TimeTableID<>0 THEN @TimeTableID ELSE CONVERT (NVARCHAR(50),t.TimeTableID) END
	--AND td.TimeTableDetailID LIKE CASE WHEN @TimeTableDetailID <> 0  THEN @TimeTableDetailID ELSE CONVERT(NVARCHAR(50),td.TimeTableDetailID)END
	 t.IsDeleted = 0
END
GO
/****** Object:  StoredProcedure [dbo].[BindTimeTable_SP]    Script Date: 12/16/2015 19:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Pranjali Vidhate
-- Create date: 2015-12-05
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[BindTimeTable_SP] 


AS
BEGIN
	select Distinct td.TimeTableID,b.BranchName,t.TimeTableStartDate,c.ClassName,ba.BatchName,br.RoomName,s.SubjectName, 
	te.TeacherName,case when t.IsActive =1  then 'Active' when t.IsActive =0 then 'InActive' end as [Status],
	t.IsActive,t.IsDeleted,td.[Day],convert(NVARCHAR(8),td.LectStartTime)+' - '+convert(nvarchar(8),td.LectEndTime) AS 'TimeSlot',td.LectStartTime,td.LectEndTime,td.ViewType,t.UpdatedDate,
	td.TimeTableDetailID,t.BatchID,td.RoomID,td.TeacherSubjectID from TimeTable t
	inner join Batches ba
	on ba.BatchID =t.BatchID
	
	inner join class c
	on c.classID = ba.ClassID
	
	inner join  Branch b
	on b.BranchID =c.BranchID
	
	inner join TimeTableDetail td
	on t.TimeTableID =td.TimeTableID
	
	inner join BranchesRooms br
	on br.RoomID = td.RoomID
	
	inner join BatchSubject bs
	on bs.BatchID = ba.BatchID 
	 
	inner join [Subject] s
	on s.SubjectID = bs.SubjectID
	
	inner join TeacherSubject ts
	on ts.BatchSubjectID =bs.BatchSubjectID
	
	inner join Teacher te
	on te.TeacherID = ts.TeacherID	
	
	where --t.TimeTableID LIKE CASE WHEN @TimeTableID<>0 THEN @TimeTableID ELSE CONVERT (NVARCHAR(50),t.TimeTableID) END
	--AND td.TimeTableDetailID LIKE CASE WHEN @TimeTableDetailID <> 0  THEN @TimeTableDetailID ELSE CONVERT(NVARCHAR(50),td.TimeTableDetailID)END
	 t.IsDeleted = 0
END
GO
/****** Object:  ForeignKey [FK_BatchAvailable_Batches]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[BatchAvailable]  WITH CHECK ADD  CONSTRAINT [FK_BatchAvailable_Batches] FOREIGN KEY([BatchID])
REFERENCES [dbo].[Batches] ([BatchID])
GO
ALTER TABLE [dbo].[BatchAvailable] CHECK CONSTRAINT [FK_BatchAvailable_Batches]
GO
/****** Object:  ForeignKey [Batches_BatchDays]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[BatchDays]  WITH CHECK ADD  CONSTRAINT [Batches_BatchDays] FOREIGN KEY([BatchID])
REFERENCES [dbo].[Batches] ([BatchID])
GO
ALTER TABLE [dbo].[BatchDays] CHECK CONSTRAINT [Batches_BatchDays]
GO
/****** Object:  ForeignKey [FK_Batches_Class]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[Batches]  WITH CHECK ADD  CONSTRAINT [FK_Batches_Class] FOREIGN KEY([ClassID])
REFERENCES [dbo].[Class] ([ClassID])
GO
ALTER TABLE [dbo].[Batches] CHECK CONSTRAINT [FK_Batches_Class]
GO
/****** Object:  ForeignKey [Batches_BatchSubject]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[BatchSubject]  WITH CHECK ADD  CONSTRAINT [Batches_BatchSubject] FOREIGN KEY([BatchID])
REFERENCES [dbo].[Batches] ([BatchID])
GO
ALTER TABLE [dbo].[BatchSubject] CHECK CONSTRAINT [Batches_BatchSubject]
GO
/****** Object:  ForeignKey [FK_BatchSubject_BatchSubject]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[BatchSubject]  WITH CHECK ADD  CONSTRAINT [FK_BatchSubject_BatchSubject] FOREIGN KEY([SubjectID])
REFERENCES [dbo].[Subject] ([SubjectID])
GO
ALTER TABLE [dbo].[BatchSubject] CHECK CONSTRAINT [FK_BatchSubject_BatchSubject]
GO
/****** Object:  ForeignKey [Branch_BranchAcadamicYear]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[BranchAcadamicYear]  WITH CHECK ADD  CONSTRAINT [Branch_BranchAcadamicYear] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branch] ([BranchID])
GO
ALTER TABLE [dbo].[BranchAcadamicYear] CHECK CONSTRAINT [Branch_BranchAcadamicYear]
GO
/****** Object:  ForeignKey [FK_BranchDistance_Branch_from]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[BranchDistance]  WITH CHECK ADD  CONSTRAINT [FK_BranchDistance_Branch_from] FOREIGN KEY([From_BranchID])
REFERENCES [dbo].[Branch] ([BranchID])
GO
ALTER TABLE [dbo].[BranchDistance] CHECK CONSTRAINT [FK_BranchDistance_Branch_from]
GO
/****** Object:  ForeignKey [FK_BranchDistance_Branch_to]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[BranchDistance]  WITH CHECK ADD  CONSTRAINT [FK_BranchDistance_Branch_to] FOREIGN KEY([To_BranchID])
REFERENCES [dbo].[Branch] ([BranchID])
GO
ALTER TABLE [dbo].[BranchDistance] CHECK CONSTRAINT [FK_BranchDistance_Branch_to]
GO
/****** Object:  ForeignKey [FK_BranchesRooms_Branch]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[BranchesRooms]  WITH CHECK ADD  CONSTRAINT [FK_BranchesRooms_Branch] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branch] ([BranchID])
GO
ALTER TABLE [dbo].[BranchesRooms] CHECK CONSTRAINT [FK_BranchesRooms_Branch]
GO
/****** Object:  ForeignKey [FK_BranchLecture_Branch]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[BranchLecture]  WITH CHECK ADD  CONSTRAINT [FK_BranchLecture_Branch] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branch] ([BranchID])
GO
ALTER TABLE [dbo].[BranchLecture] CHECK CONSTRAINT [FK_BranchLecture_Branch]
GO
/****** Object:  ForeignKey [FK_BranchLectureDetail_BranchLecture]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[BranchLectureDetail]  WITH CHECK ADD  CONSTRAINT [FK_BranchLectureDetail_BranchLecture] FOREIGN KEY([BranchLectureID])
REFERENCES [dbo].[BranchLecture] ([BranchLectureID])
GO
ALTER TABLE [dbo].[BranchLectureDetail] CHECK CONSTRAINT [FK_BranchLectureDetail_BranchLecture]
GO
/****** Object:  ForeignKey [Branch_Class]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[Class]  WITH CHECK ADD  CONSTRAINT [Branch_Class] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branch] ([BranchID])
GO
ALTER TABLE [dbo].[Class] CHECK CONSTRAINT [Branch_Class]
GO
/****** Object:  ForeignKey [FK_RoomAvailable_BranchesRooms]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[RoomAvailable]  WITH CHECK ADD  CONSTRAINT [FK_RoomAvailable_BranchesRooms] FOREIGN KEY([RoomID])
REFERENCES [dbo].[BranchesRooms] ([RoomID])
GO
ALTER TABLE [dbo].[RoomAvailable] CHECK CONSTRAINT [FK_RoomAvailable_BranchesRooms]
GO
/****** Object:  ForeignKey [Teacher_TeacherAvailable]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[TeacherAvailable]  WITH CHECK ADD  CONSTRAINT [Teacher_TeacherAvailable] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([TeacherID])
GO
ALTER TABLE [dbo].[TeacherAvailable] CHECK CONSTRAINT [Teacher_TeacherAvailable]
GO
/****** Object:  ForeignKey [Branch_TeacherBranch]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[TeacherBranch]  WITH CHECK ADD  CONSTRAINT [Branch_TeacherBranch] FOREIGN KEY([BranchID])
REFERENCES [dbo].[Branch] ([BranchID])
GO
ALTER TABLE [dbo].[TeacherBranch] CHECK CONSTRAINT [Branch_TeacherBranch]
GO
/****** Object:  ForeignKey [Teacher_TeacherBranch]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[TeacherBranch]  WITH CHECK ADD  CONSTRAINT [Teacher_TeacherBranch] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([TeacherID])
GO
ALTER TABLE [dbo].[TeacherBranch] CHECK CONSTRAINT [Teacher_TeacherBranch]
GO
/****** Object:  ForeignKey [BatchSubject_TeacherSubject]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[TeacherSubject]  WITH CHECK ADD  CONSTRAINT [BatchSubject_TeacherSubject] FOREIGN KEY([BatchSubjectID])
REFERENCES [dbo].[BatchSubject] ([BatchSubjectID])
GO
ALTER TABLE [dbo].[TeacherSubject] CHECK CONSTRAINT [BatchSubject_TeacherSubject]
GO
/****** Object:  ForeignKey [FK_TeacherSubject_Teacher]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[TeacherSubject]  WITH CHECK ADD  CONSTRAINT [FK_TeacherSubject_Teacher] FOREIGN KEY([TeacherID])
REFERENCES [dbo].[Teacher] ([TeacherID])
GO
ALTER TABLE [dbo].[TeacherSubject] CHECK CONSTRAINT [FK_TeacherSubject_Teacher]
GO
/****** Object:  ForeignKey [Batches_TimeTable]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[TimeTable]  WITH CHECK ADD  CONSTRAINT [Batches_TimeTable] FOREIGN KEY([BatchID])
REFERENCES [dbo].[Batches] ([BatchID])
GO
ALTER TABLE [dbo].[TimeTable] CHECK CONSTRAINT [Batches_TimeTable]
GO
/****** Object:  ForeignKey [FK_TimeTableDetail_BranchesRooms]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[TimeTableDetail]  WITH CHECK ADD  CONSTRAINT [FK_TimeTableDetail_BranchesRooms] FOREIGN KEY([RoomID])
REFERENCES [dbo].[BranchesRooms] ([RoomID])
GO
ALTER TABLE [dbo].[TimeTableDetail] CHECK CONSTRAINT [FK_TimeTableDetail_BranchesRooms]
GO
/****** Object:  ForeignKey [FK_TimeTableDetail_TeacherSubject]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[TimeTableDetail]  WITH CHECK ADD  CONSTRAINT [FK_TimeTableDetail_TeacherSubject] FOREIGN KEY([TeacherSubjectID])
REFERENCES [dbo].[TeacherSubject] ([TeacherSubjectID])
GO
ALTER TABLE [dbo].[TimeTableDetail] CHECK CONSTRAINT [FK_TimeTableDetail_TeacherSubject]
GO
/****** Object:  ForeignKey [FK_TimeTableDetail_TimeTable]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[TimeTableDetail]  WITH CHECK ADD  CONSTRAINT [FK_TimeTableDetail_TimeTable] FOREIGN KEY([TimeTableID])
REFERENCES [dbo].[TimeTable] ([TimeTableID])
GO
ALTER TABLE [dbo].[TimeTableDetail] CHECK CONSTRAINT [FK_TimeTableDetail_TimeTable]
GO
/****** Object:  ForeignKey [UserType_User]    Script Date: 12/16/2015 19:51:27 ******/
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [UserType_User] FOREIGN KEY([UserTypeID])
REFERENCES [dbo].[UserType] ([UserTypeID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [UserType_User]
GO




/****** Object:  Table [dbo].[UserType]    Script Date: 12/16/2015 19:52:47 ******/
SET IDENTITY_INSERT [dbo].[UserType] ON
INSERT [dbo].[UserType] ([UserTypeID], [UserTypeName], [IsActive], [IsDeleted]) VALUES (1, N'Admin', 1, 0)
INSERT [dbo].[UserType] ([UserTypeID], [UserTypeName], [IsActive], [IsDeleted]) VALUES (2, N'User', 1, 0)
SET IDENTITY_INSERT [dbo].[UserType] OFF
/****** Object:  Table [dbo].[Messages]    Script Date: 12/16/2015 19:52:47 ******/
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
/****** Object:  Table [dbo].[Login]    Script Date: 12/16/2015 19:52:47 ******/
INSERT [dbo].[Login] ([LoginuserId], [LoginUserName], [Password], [LoginType], [ExpiryDate]) VALUES (1, N'Admin', N'123', N'Admin', CAST(0x2D3C0B00 AS Date))
