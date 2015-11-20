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
-- Description:	Delete Batch Subject
-- =============================================
CREATE PROCEDURE DeleteBatchSubject_SP 
	(
	@BatchID int,
	@SubjectID int,
	@UpdatedByUserID int,
	@UpdatedDate nvarchar(50)
	)
AS
Declare @msg NVARCHAR(MAX)
DECLARE @MaxID int
BEGIN
	UPDATE BatchSubject SET IsActive=0,IsDeleted=1,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate
	WHERE BatchID=@BatchID AND SubjectID=@SubjectID
	IF(@@ROWCOUNT=1)
		BEGIN
			SET @MaxID=(SELECT BatchSubjectID FROM BatchSubject WHERE BatchID=@BatchID AND SubjectID=@SubjectID)
			EXEC SaveLog_SP 'Batch Subject Deleted SucessFully',@UpdatedDate,'BatchSubject',@MaxID
			SET @msg= (Select [Message] FROM [Messages] WHERE MessageID=12 )
		END
	ELSE
		BEGIN
			SET @MaxID=(SELECT BatchSubjectID FROM BatchSubject WHERE BatchID=@BatchID AND SubjectID=@SubjectID)
			EXEC SaveLog_SP 'Error To Delete Batch Subject',@UpdatedDate,'BatchSubject',@MaxID
			SET @msg= (Select [Message] FROM [Messages] WHERE MessageID=13 )
		END
	
	SELECT @msg
END
GO
