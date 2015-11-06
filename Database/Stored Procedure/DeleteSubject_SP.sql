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
-- Create date: 5 Nov 2015
-- Description:	Delete Subject
-- =============================================
ALTER PROCEDURE DeleteSubject_SP 
	(
	@SubjectID int,
	@UpdatedByUserID int,
	@UpdatedDate nvarchar(50) ) 
	
AS
DECLARE @msg NVARCHAR(50)
BEGIN
	UPDATE [Subject] SET IsActive=0  , IsDeleted=1 ,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate
	WHERE SubjectID= @SubjectID
	if (@@ROWCOUNT=1)
		BEGIN 
		       EXEC SaveLog_SP 'Delete Subject Sucessfully.',@UpdatedDate,'Subject',@SubjectID
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=12)
		END
	else
		BEGIN
			EXEC SaveLog_SP 'Error To Delete Record',@UpdatedDate,'Subject',@SubjectID
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=13)
		END
	SELECT @msg
END
GO
