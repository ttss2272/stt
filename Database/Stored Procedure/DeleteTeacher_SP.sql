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
-- Description:	Delete Teacher
-- =============================================
ALTER PROCEDURE DeleteTeacher_SP 
	(
	@TeacherID int,
	@UpdatedDate nvarchar(50),
	@UpdatedByUserID int
	)
AS
DECLARE @msg nvarchar(50)
BEGIN
	Update Teacher set IsActive=0 ,IsDeleted=1 ,UpdatedDate=@UpdatedDate,UpadatedByUserID=@UpdatedByUserID
	WHERE TeacherID=@TeacherID
	IF (@@ROWCOUNT=1)
		BEGIN
			
		       EXEC SaveLog_SP 'Delete Teacher Sucessfully.',@UpdatedDate,'Teacher',@TeacherID
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=12)
		END
	else
		BEGIN
			EXEC SaveLog_SP 'Error To Delete Teacher',@UpdatedDate,'Teacher',@TeacherID
		       SET @msg = (SELECT [Message] from [messages] WHERE MessageID=13)
		END
	SELECT @msg
	
END
GO
