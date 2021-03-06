USE [NewTimeTableDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveUpdateTimeSlot_SP]    Script Date: 12/08/2015 19:28:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:	Pranjali S Vidhate
-- Create date: 2015/11/17
-- Description:	To SaveUpdate Timeslot
-- =============================================
ALTER PROCEDURE [dbo].[SaveUpdateTimeSlot_SP] --0,11,'Monday','07:00','12:00','08:00','09:00',1,0,'2015-11-17',1
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
		UPDATE BranchLecture SET StartTime=@STime,EndTime=@ETime,UpdatedDate=@UpdatedDate,UpdatedByUserID=@UpdatedByUserID
		WHERE BranchID=@BranchID AND [DayName]=@DayName
		IF(@@ROWCOUNT=1)
			BEGIN
				SET @MAXID = (SELECT BranchLectureID FROM BranchLecture WHERE BranchID=@BranchID AND [DayName]=@DayName)
				EXEC SaveLog_SP 'Update Time Sucessfully',@UpdatedDate,'BranchLecture',@MAXID
				IF (@@ROWCOUNT=1)
					BEGIN
						IF NOT EXISTS(SELECT BranchLectureDetailID FROM BranchLectureDetail WHERE LectureStartTime=@SSTime AND LectureEndTime=@SETime)
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
					
		
