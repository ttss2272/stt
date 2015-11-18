
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:	Pranjali
-- Create date: 2015/11/18
-- Description:	To Delete TimeSlot
-- =============================================
ALTER PROCEDURE [dbo].[DeleteTimeSlot_SP]
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
