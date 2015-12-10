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
-- Create date: 10 Dec 2015
-- Description:	Delete Board
-- =============================================
CREATE PROCEDURE DeleteBoard_SP 
 (
 @BoardID int,
 @UpdatedDate nvarChar(50),
 @UpdatedByUserID int
 )
AS
DECLARE @msg NVARCHAR(MAX)
BEGIN
	UPDATE Board SET IsActive=0,IsDeleted=1,UpdatedByUserID=@UpdatedByUserID,UpdatedDate=@UpdatedDate
	Where BoardID=@BoardID
	IF (@@ROWCOUNT=1)
	 BEGIN
		EXEC SaveLog_SP 'Delete Board SucessFully',@UpdatedDate,'Board',@BoardID
		SET @msg= (SELECT [Message] FROM [Messages] WHERE MessageID=12)
	 END
	 ELSE
		BEGIN
			EXEC SaveLog_SP 'Error To Delete Board',@UpdatedDate,'Board',@BoardID
		SET @msg= (SELECT [Message] FROM [Messages] WHERE MessageID=13)
		END
	SELECT @msg
END
GO
