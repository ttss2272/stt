USE [NewTimeTableDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveUpdateTimeSlot_SP]    Script Date: 11/18/2015 13:29:56 ******/
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
BEGIN

if(@BranchLectureDetailID =0)--Check for Edit Or Update 0 for new entry and onther no update
	BEGIN
		IF not exists(select [LectureStartTime],[LectureEndTime] from BranchLectureDetail where LectureStartTime = @SSTime AND LectureEndTime = @SETime and [DayName] = @DayName )
			 BEGIN-- insert data
				 insert into BranchLectureDetail (BranchID,[DayName],StartTime,EndTime,LectureStartTime,LectureEndTime,IsActive,IsDelete,CreatedDate,UpdatedDate,CreatedByUserID,UpdatedByUserID)
				 values(@BranchID,@DayName,@STime,@ETime,@SSTime,@SETime,@IsActive,@IsDeleted,@UpdatedDate,@UpdatedDate,@UpdatedByUserID,@UpdatedByUserID)
				  IF(@@ROWCOUNT=1)-- check row effected or not
					 BEGIN
					    exec SaveLog_SP 'TimeSlot Inserted Successfully',@UpdatedDate,'TimeSlot',@BranchLectureDetailID 
					    IF (@@ROWCOUNT=1)--Check Row Effected or Not
					      begin
						     set @msg= (SELECT [Message] FROM [Messages] where MessageID=1)
						  end
				     END
				  ELSE
				     BEGIN
						exec SaveLog_SP 'Error To Save Details.',@UpdatedDate,'TimeSlot',@BranchLectureDetailID  --Enter in Log Table
						IF (@@ROWCOUNT=1)--Check Row Effected Or Not
					       BEGIN
						       SET @msg = (SELECT [Message] FROM [Messages] where MessageID=2)
					       END
			         END
			    END     
	  ELSE--Error for Duplicate Time Slot
				BEGIN
					EXEC SaveLog_SP 'Time Slot Duplication',@UpdatedDate,'Time Slot',@BranchLectureDetailID --Enter in Log Table
					IF (@@ROWCOUNT=1)
						BEGIN
							SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=19)--Set Message To Return
						END
				END
	END
ELSE
	BEGIN
	     IF not exists(select [LectureStartTime],[LectureEndTime] from BranchLectureDetail where LectureStartTime = @SSTime AND LectureEndTime = @SETime and [DayName] = @DayName)
		     BEGIN --Update SP
		         update BranchLectureDetail  set [DayName] = @DayName,BranchID=@BranchID,UpdatedByUserID=@UpdatedByUserID,UpdatedDate= @UpdatedDate,IsActive=@IsActive,IsDelete =@IsDeleted,StartTime=@STime,EndTime =@ETime,LectureStartTime=@SSTime,LectureEndTime=@SETime  
		         where BranchLectureDetailID  = @BranchLectureDetailID 
			     IF(@@ROWCOUNT=1)-- Check Row Effected or Not
			         BEGIN
						EXEC SaveLog_SP 'Time Slot Updated Sucessfully',@UpdatedDate,'Time Slot',@BranchLectureDetailID  --Entry in Log Table
						IF (@@ROWCOUNT=1)--Check Row Effected Or Not
					          BEGIN
						          set @msg= (SELECT [Message] FROM [Messages] where MessageID=5)
					          END
					 END  
			  END       
	    ELSE
		    BEGIN
			   EXEC SaveLog_SP 'Time Slot Duplication',@UpdatedDate,'Time Slot',@BranchLectureDetailID  --Entery In Log Table
			   IF (@@ROWCOUNT=1)--Check row Effected
				 BEGIN
					  SET @msg= (SELECT [Message] FROM [Messages] Where MessageID=19)--set Message
				 END
		END
			
			
  END
		
SELECT @msg
	
END
					
		
