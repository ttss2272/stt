
/****** Object:  StoredProcedure [dbo].[DeleteTeacher_SP]    Script Date: 11/17/2015 15:24:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 07 Nov 2015
-- Description:	Delete Teacher
-- =============================================
ALTER PROCEDURE [dbo].[DeleteTeacher_SP] 
	(
	@TeacherID int,
	@UpdatedDate nvarchar(50),
	@UpdatedByUserID int
	)
AS
DECLARE @msg nvarchar(50)
BEGIN
	Update Teacher set IsActive=0 ,IsDeleted=1 ,UpdatedDate=CONVERT(datetime,@UpdatedDate,103),UpadatedByUserID=@UpdatedByUserID
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
