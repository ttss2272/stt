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
-- Create date: 20 Nov 2015
-- Description:	Save Batch Subject
-- =============================================
ALTER PROCEDURE SaveBatchSubject_SP 
	(
	
	@SubjectID int,
	@BatchID int,
	@NoLectPerDay int,
	@NoLectPerWeek int,
	@UpdatedByUserID int,
	@UpdatedDate NVARCHAR(50),
	@IsActive int,
	@IsDeleted int
	)
AS
DECLARE @msg NVARCHAR(MAX)
DECLARE @MaxID int
BEGIN
	IF NOT EXISTS(SELECT BatchSubjectID FROM BatchSubject WHERE SubjectID=@SubjectID AND BatchID=@BatchID)
		BEGIN
			INSERT INTO BatchSubject (SubjectID,BatchID,FrequencyPerDay,FrequencyPerWeek,CreatedByUserID,UpdatedByUserID,CreatedDate,UpdatedDate,IsActive,IsDeleted)
			VALUES (@SubjectID,@BatchID,@NoLectPerDay,@NoLectPerWeek,@UpdatedByUserID,@UpdatedByUserID,@UpdatedDate,@UpdatedDate,@IsActive,@IsDeleted)
			
			If(@@ROWCOUNT=1)--Save sucessFull
				BEGIN
					SET @MaxID= (SELECT MAX(BatchSubjectID)FROM BatchSubject)
					EXEC SaveLog_SP 'Batch Subject Save Sucessfully.',@UpdatedDate,'BatchSubject',@MaxID
					SET @msg = (SELECT [Message] FROM [Messages] WHERE MessageID=1)
				END
			ELSE--Error to save
				BEGIN 
					SET @MaxID= (SELECT MAX(BatchSubjectID)FROM BatchSubject)
					EXEC SaveLog_SP 'Error To Save Batch Subject ',@UpdatedDate,'BatchSubject',@MaxID
					SET @msg = (SELECT [Message] FROM [Messages] WHERE MessageID=2)
				END
		END
	ELSE
		BEGIN
			UPDATE BatchSubject SET FrequencyPerDay=@NoLectPerDay, FrequencyPerWeek=@NoLectPerWeek,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate,IsActive=@IsActive,IsDeleted=@IsDeleted
			WHERE BatchID=@BatchID AND SubjectID=@SubjectID
			
			If(@@ROWCOUNT=1)--Update sucessFull
				BEGIN
					SET @MaxID= (SELECT MAX(BatchSubjectID)FROM BatchSubject WHERE BatchID=@BatchID AND SubjectID=SubjectID)
					EXEC SaveLog_SP 'Batch Subject Updated Sucessfully.',@UpdatedDate,'BatchSubject',@MaxID
					SET @msg = (SELECT [Message] FROM [Messages] WHERE MessageID=5)
				END
			ELSE--Error to Update
				BEGIN 
					SET @MaxID= (SELECT MAX(BatchSubjectID)FROM BatchSubject WHERE BatchID=@BatchID AND SubjectID=SubjectID)
					EXEC SaveLog_SP 'Error To Save Batch Subject ',@UpdatedDate,'BatchSubject',@MaxID
					SET @msg = (SELECT [Message] FROM [Messages] WHERE MessageID=2)
				END
		END	
		SELECT @msg
END
GO
