USE [NewTimeTableDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveTeacher_SP]    Script Date: 11/17/2015 15:53:56 ******/
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
ALTER PROCEDURE [dbo].[SaveTeacher_SP]-- 0,'PriTesh','Sortee','PDS',2,1,10,3,1,1,'11:30','12:30',1,'2015-07-12',1,0
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
DECLARE @MAXTeacherID int
BEGIN
	IF (@TeacherID =0)
		BEGIN
			IF NOT EXISTS(SELECT TeacherID From Teacher Where TeacherShortName=@TeacherShortName)--Teacher Short Name Exists Or NOt
				BEGIN
					INSERT INTO Teacher (TeacherName,TeacherSurname,TeacherShortName,NoOfMovesInBranch,MaxNoLecturesDay,MaxNoLectureWeek,IsAllowMoreThanOneLectInBatch,MaxNoOfLectureInRow,IsFirstLect,IsLastLect,FreeTimeStart,FreeTimeEnd,IsActive,IsDeleted,CreatedByUserID,UpadatedByUserID,CreatedDate,UpdatedDate)
					VALUES (@TeacherName,@TeacherSurname,@TeacherShortName,@MaxNoOfMovesInBranch,@MaxLecturePerDay,@MaxLectPerWeek,@IsMoreThanOneLecture,@MaxNoOfLectInRow,@IsFirstLecture,@IsLastLecture,@FreeTimeStart,@FreeTimeEnd,@Active,@IsDeleted,@UpdatedByUserID,@UpdatedByUserID,Convert(datetime,@UpdatedDate),CONVERT(datetime,@UpdatedDate))
					IF(@@ROWCOUNT=1)--Chaeck whether Value Inserted SucessfullyOrNot in Table
						BEGIN
							SET @MAXTeacherID=(Select MAX(TeacherID) From Teacher)
							EXEC SaveLog_SP 'Teacher Inserted SucessFully',@UpdatedDate,'Teacher',@MAXTeacherID
							IF(@@ROWCOUNT=1)--Chaeck whether Value Inserted SucessfullyOrNot in Table
								BEGIN
									SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=1 )
								END		
						END
					ELSE--Not Inserted values
						BEGIN
							SET @MAXTeacherID=(Select MAX(TeacherID) From Teacher)
							EXEC SaveLog_SP 'Error To Insert Teacher',@UpdatedDate,'Teacher',@MAXTeacherID
							IF(@@ROWCOUNT=1)--Chaeck whether Value Inserted SucessfullyOrNot in Table
								BEGIN
									SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=2 )
								END		
						END
					
					
				END
			ELSE--Short Name Duplicate
				BEGIN
				SET @MAXTeacherID=(Select MAX(TeacherID) From Teacher)
					EXEC SaveLog_SP 'Teacher Short Name Duplication',@UpdatedDate,'Teacher',@MAXTeacherID
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
					IF(@@ROWCOUNT=1)
						BEGIN
							SET @MAXTeacherID=@TeacherID
							EXEC SaveLog_SP 'Teacher Updated SucessFully',@UpdatedDate,'Teacher',@MAXTeacherID
							IF(@@ROWCOUNT=1)
								BEGIN
									SET @msg=(SELECT [Message] FROM [Messages] Where MessageID=5)--Set message
								END
							END
							ELSE
								BEGIN
									SET @MAXTeacherID=@TeacherID
									EXEC SaveLog_SP 'Error To Update',@UpdatedDate,'Teacher',@MAXTeacherID
									IF(@@ROWCOUNT=1)
										BEGIN
											SET @msg=(SELECT [Message] FROM [Messages] Where MessageID=4)--Set message
										END
								END		
							
						
					
			END
			ELSE--Short Name Duplication
				BEGIN
					SET @MAXTeacherID=@TeacherID
					EXEC SaveLog_SP 'Teacher Short Name Duplication',@UpdatedDate,'Teacher',@MAXTeacherID
					IF(@@ROWCOUNT=1)
						BEGIN
							SET @msg='Teacher Short Name Already Exists.'
						END
				END
			
		END
		SELECT @msg
END
