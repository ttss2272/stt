USE [NewTimeTableDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveTeacherBatchSubject_SP]    Script Date: 12/02/2015 12:27:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 23 Nov 2015
-- Description:	save Teacher Batch Subjet
-- =============================================
ALTER PROCEDURE [dbo].[SaveTeacherBatchSubject_SP] --8,26,1,'2015-12-02',True,0
	(
	
	@TeacherID int,
	@BatchSubjectID int,
	@UpdatedByUserID int,
	@UpdatedDate nvarchar(50),
	@IsActive NVARCHAR(15),
	@IsDeleted int
	)
AS
DECLARE @msg nvarchar(MAX)
DECLARE @MaxID int
BEGIN
  IF NOT EXISTS(SELECT TeacherSubjectID FROM TeacherSubject WHERE TeacherID=@TeacherID AND BatchSubjectID=@BatchSubjectID)
  BEGIN
	INSERT INTO TeacherSubject (TeacherID,BatchSubjectID,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive,IsDeleted)
	VALUES (@TeacherID,@BatchSubjectID,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@UpdatedDate,@IsActive,@IsDeleted)
		IF (@@ROWCOUNT=1)
			BEGIN
				SET @MaxID =(SELECT MAX(TeacherSubjectID) FROM TeacherSubject)
				EXEC SaveLog_SP 'Teacher Batch Subject Save Sucessfully',@UpdatedDate,'TeacherSubject',@MaxID
				
				SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=1)
			END
		ELSE
			BEGIN
			SET @MaxID =(SELECT TeacherSubjectID FROM TeacherSubject)
				EXEC SaveLog_SP 'Error To Save Teacher Batch Subject',@UpdatedDate,'TeacherSubject',@MaxID
				
				SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=2)
			END
	END
	ELSE
		BEGIN
			UPDATE TeacherSubject SET BatchSubjectID=@BatchSubjectID,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate,IsActive=@IsActive,IsDeleted=@IsDeleted
			WHERE TeacherID=@TeacherID AND BatchSubjectID=@BatchSubjectID
			
			IF (@@ROWCOUNT=1)
			BEGIN
				SET @MaxID =(SELECT MAX(TeacherSubjectID) FROM TeacherSubject WHERE TeacherID=@TeacherID)
				EXEC SaveLog_SP 'Teacher Batch Subject Update Sucessfully',@UpdatedDate,'TeacherSubject',@MaxID
				
				SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=1)
			END
		ELSE
			BEGIN
			SET @MaxID =(SELECT TeacherSubjectID FROM TeacherSubject WHERE TeacherID=@TeacherID)
				EXEC SaveLog_SP 'Error To Update Teacher Batch Subject',@UpdatedDate,'TeacherSubject',@MaxID
				
				SET @msg =(SELECT [Message] FROM [Messages] WHERE MessageID=2)
			END
		END
		
		SELECT @msg
	
END
