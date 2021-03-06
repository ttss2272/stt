USE [TimeTableDB]
GO
/****** Object:  StoredProcedure [dbo].[GetSubject_SP]    Script Date: 11/05/2015 19:49:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 4 Nov 2015
-- Description:	Get  Subject To bind DropDown
-- =============================================
ALTER PROCEDURE [dbo].[GetSubject_SP] 
	(
	@SubjectID int
	)
AS
BEGIN
	SELECT SubjectID,SubjectName,SubjectShortName  from [Subject]
	WHERE SubjectID LIKE CASE WHEN @SubjectID<>0 THEN @SubjectID ELSE CONVERT (NVARCHAR(50),SubjectID) END
	AND IsActive = 'True'
	ORDER BY SubjectName
END
