
/****** Object:  StoredProcedure [dbo].[BindSubject_SP]    Script Date: 11/05/2015 19:42:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 04 Nov 2015
-- Description:	Get Details To bind Drop Down
-- =============================================
ALTER PROCEDURE [dbo].[BindSubject_SP] 
	(
		@SubjectID int
	)
AS
BEGIN
	SELECT SubjectID,SubjectName,SubjectShortName  from [Subject]
	WHERE SubjectID LIKE CASE WHEN @SubjectID<>0 THEN @SubjectID ELSE CONVERT (NVARCHAR(50),SubjectID) END
	AND IsDeleted<>'False'
END
