USE [NewTimeTableDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveRoom_SP]    Script Date: 11/17/2015 12:30:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Pranjali
-- Create date: 05/11/2015
-- Description:	To save Room Details 
-- =============================================
ALTER PROCEDURE [dbo].[SaveRoom_SP]
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
DECLARE @msg NVARCHAR(50)
BEGIN

if(@RoomID=0)--Check for Edit Or Update 0 for new entry and onther no update
	begin
		if not exists(select RoomName from BranchesRooms where RoomName=@RoomName)
		  BEGIN
			 IF NOT EXISTS (select RoomID FROM [BranchesRooms]  Where RoomShortName =@RoomShortName)
			   BEGIN-- insert data
				  insert into BranchesRooms(RoomName,RoomShortName,RoomColor,Capacity,BranchID,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive,MaxNoLecturesDay,MaxNoLecturesWeek,IsAllowMoreThanOneLectInBatch,MaxNoOfLectureInRow,FreeTimeStart,FreeTimeEnd,IsDeleted)
				  values(@RoomName,@RoomShortName,@Color,@Capacity,@BranchID,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@UpdatedDate,@IsActive,@MaxLectDay,@MaxLectWeek,@IsAllow,@MaxLectRow,@STime,@ETime,@IsDeleted)
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
	if not exists(select RoomName from BranchesRooms where RoomName=@RoomName  AND RoomID <> @RoomID)
	   BEGIN
		  IF NOT EXISTS (SELECT RoomID FROM [BranchesRooms]  Where RoomShortName=@RoomShortName AND RoomID <> @RoomID )--Check Room Short Name Available for other Than that RoomID	
		     BEGIN --Update SP
		         update BranchesRooms set RoomName = @RoomName,RoomShortName = @RoomShortName,RoomColor=@Color,Capacity=@Capacity,BranchID=@BranchID,UpdatedByUserID=@UpdatedByUserID,UpdatedDate= @UpdatedDate,IsActive=@IsActive,IsDeleted =@IsDeleted,MaxNoLecturesDay=@MaxLectDay,MaxNoLecturesWeek=@MaxLectWeek,IsAllowMoreThanOneLectInBatch=@IsAllow,MaxNoOfLectureInRow=@MaxLectRow,FreeTimeStart=@STime,FreeTimeEnd=@ETime 
		         where RoomID = @RoomID
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
		
SELECT @msg
	
END
					
	
	

