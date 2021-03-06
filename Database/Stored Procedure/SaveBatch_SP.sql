USE [NewTimeTableDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveBatch_SP]    Script Date: 11/07/2015 11:30:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 05-11-2015
-- Description:	Save AND Update Code of Batch Form
-- =============================================
ALTER PROCEDURE [dbo].[SaveBatch_SP] 
	(
	@BatchID int,
	@BatchName nvarchar(50),
	@BatchCode nvarchar(50),
	@ClassID int,
	@LectureDuration int,
	@IsLunchBreak int,
	@LunchBreakStartTime int,
	@LunchBreakEndTime int,
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
DECLARE @msg nvarchar(MAX)
BEGIN
	IF(@BatchID=0)--Check for Edit Or Update 0 for new entry and onther no update
		BEGIN
			IF NOT EXISTS (SELECT @BatchID FROM [Batches] Where BatchName=@BatchName)--Check Whether given name Already exist or not
				BEGIN
					IF NOT EXISTS (SELECT BatchID FROM [Batches] Where BatchCode=@BatchCode) --Check Whether Batch code already Exists Or Not
						BEGIN-- Insert into Data into Batch Table
							INSERT INTO [Batches] (BatchName,BatchCode,ClassID,IsLunchBreak,LunchBreakStartTime,LunchBreakEndTime,MaxNoLecturesDay,MaxNoLecturesWeek,IsAllowMoreThanOneLectInBatch,MaxNoOfLecureInRow,LectureDuration,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive,IsDeleted)
							VALUES (@BatchName,@BatchCode,@ClassID,@LectureDuration,@IsLunchBreak,@LunchBreakStartTime,@LunchBreakEndTime,@MaxNoLecturesDay,@MaxNoLecturesWeek,@IsAllowMoreThanOneLectInBatch,@MaxNoOfLecureInRow,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@UpdatedDate,@IsActive,@IsDeleted)
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
									EXEC SaveLog_SP 'Error To Save Details.',@UpdatedDate,'Subject',@BatchID --Enter in Log Table
									IF (@@ROWCOUNT=1)--Check Row Effected Or Not
										BEGIN
											SET @msg=(SELECT [Message]	FROM [Messages] WHERE MessageID=2)--Set Message To Return
										END
								END
						END
					ELSE--error for Duplicate Batch Code
						BEGIN
						EXEC SaveLog_SP 'Batch Code Duplication',@UpdatedDate,'Subject',@BatchID--Enter in Log Table
							IF (@@ROWCOUNT=1)
								BEGIN
									SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=10)--Set Message To Return
								END
						END
				END
			ELSE--Error for Duplicate Batch Name
				BEGIN
					EXEC SaveLog_SP 'Batch Name Duplication',@UpdatedDate,'Subject',@BatchID--Enter in Log Table
					IF (@@ROWCOUNT=1)
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=11)--Set Message To Return
						END
				END
		END
	ELSE
		BEGIN
			IF NOT EXISTS (SELECT BatchID FROM [Batches] Where BatchName=@BatchName AND BatchID <> @BatchID)--Check Whether Subject Name Exist other Than SubjectID
				BEGIN
					IF NOT EXISTS (SELECT BatchID FROM [Batches] Where BatchCode=@BatchCode AND BatchID <> @BatchID )--Check Subject Short Name Available for other Than that subject ID
						BEGIN--UPDATE SP
							UPDATE [Batches] SET BatchName=@BatchName,BatchCode=@BatchCode,ClassID=@ClassID,LectureDuration=@LectureDuration,IsLunchBreak=@IsLunchBreak,
							LunchBreakStartTime=@LunchBreakStartTime,LunchBreakEndTime=@LunchBreakEndTime,MaxNoLecturesDay=@MaxNoLecturesDay,MaxNoLecturesWeek=@MaxNoLecturesWeek,IsAllowMoreThanOneLectInBatch=@IsAllowMoreThanOneLectInBatch,MaxNoOfLecureInRow=@MaxNoOfLecureInRow,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate
							WHERE BatchID=@BatchID
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
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=11)--set Message
						END
				END
			
			
		END
		
	SELECT @msg
	
END
