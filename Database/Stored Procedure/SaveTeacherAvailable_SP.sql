-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 07 Nov 2015
-- Description:	Save Teacher Availibility Details
-- =============================================
CREATE PROCEDURE SaveTeacherAvailable_SP 
	(
	
	@Day nvarchar(50),
	@TeacherID NVARCHAR(50),
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
	IF NOT Exists(SELECT TeacherAvalilableID FROM TeacherAvailable WHERE TeacherID=@TeacherID)
		BEGIN
			INSERT INTO TeacherAvailable(TeacherID,Day,StartTime,EndTime,UpdatedByUserID,UpdatedDate,IsActive,IsDeleted)
			VALUES (@TeacherID,@Day,@StartTime,@EndTime,@UpdatedByUserID,@UpdatedDate,@IsActive,@IsDeleted)
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
			UPDATE TeacherAvailable SET StartTime=@StartTime,Day=@Day,EndTime=@EndTime,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate,IsActive=@IsActive,IsDeleted=@IsDeleted
			WHERE  TeacherID=@TeacherID
			IF(@@ROWCOUNT=1)
				BEGIN
					SELECT @MaxID=@TeacherAvailableID
					EXEC SaveLog_SP 'Update Teacher Availibility.',@UpdatedDate,'TeacherAvailable',@MaxID 
					set @msg=(SELECT [Message] FROM [Messages] WHERE MessageID=5)
				END
			ELSE
				BEGIN
					SELECT @MaxID=@TeacherAvailableID
					EXEC SaveLog_SP 'Error To Update Teacher Availibility.',@UpdatedDate,'TeacherAvailable',@MaxID 
					set @msg=(SELECT [Message] FROM [Messages] WHERE MessageID=2)
				END
			
		
		END
		
		
END
GO
