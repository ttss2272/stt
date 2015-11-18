use [NewTimeTableDB] 
-- ================================================
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
