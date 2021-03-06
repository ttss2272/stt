/****** Object:  StoredProcedure [dbo].[BindTeacherName_SP]    Script Date: 12/16/2015 15:40:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 09-11-2015
-- Description:	to bind Teacher name on dropdown
-- =============================================
ALTER PROCEDURE [dbo].[BindTeacherName_SP]
	(
	@TeacherID int
 	)
AS
BEGIN
	
	SELECT 0 AS TeacherID,'Select' AS TeacherName 
UNION
 SELECT TeacherID,TeacherName+' '+TeacherSurname+'['+TeacherShortName+']' FROM [Teacher] WHERE 
 TeacherID LIKE CASE WHEN @TeacherID<>0 Then @TeacherID ELSE CONVERT(NVARCHAR(50),TeacherID) END
AND IsActive='True' AND IsDeleted='False'
ORDER BY TeacherName	
    
END
