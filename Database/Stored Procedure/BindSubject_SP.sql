
/****** Object:  StoredProcedure [dbo].[BindSubject_SP]    Script Date: 11/06/2015 16:04:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 04 Nov 2015
-- Description:	Get Details To bind Drop Down
-- =============================================
ALTER PROCEDURE [dbo].[BindSubject_SP] --3
	(
		@SubjectID int
	)
AS
BEGIN
	SELECT SubjectID,SubjectName,SubjectShortName,
	 CASE IsActive When 'True' Then 'Active'
	 WHEN 'False' Then 'InActive' END
	 AS [Status]
	 FROM [Subject]
	WHERE SubjectID LIKE CASE WHEN @SubjectID<>0 THEN @SubjectID ELSE CONVERT (NVARCHAR(50),SubjectID) END
	AND IsDeleted<>'True'
END
