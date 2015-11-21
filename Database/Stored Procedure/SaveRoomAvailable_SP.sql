
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:Pranjali Vidhate
-- Create date: 20-11-2015
-- Description:	To save room avilablie 
-- =============================================
ALTER PROCEDURE [dbo].[SaveRoomAvailable_SP]

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
