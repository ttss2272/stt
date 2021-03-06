/****** Object:  StoredProcedure [dbo].[SaveTeacherAvailable_SP]    Script Date: 11/17/2015 18:09:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 07 Nov 2015
-- Description:	Save Teacher Availibility Details
-- =============================================
ALTER PROCEDURE [dbo].[SaveTeacherAvailable_SP]-- 5,Mon,'9:00:00','16:00:00',1,'2015-11-17',1,0
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
