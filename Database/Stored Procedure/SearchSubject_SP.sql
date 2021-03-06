
/****** Object:  StoredProcedure [dbo].[SearchSubject_SP]    Script Date: 11/06/2015 09:51:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 5 Nov 2015
-- Description:	search subject
-- =============================================
ALTER PROCEDURE [dbo].[SearchSubject_SP] 
	-- Add the parameters for the stored procedure here
	@SubjectName NVARCHAR(50)
AS
BEGIN
	SELECT SubjectName,SubjectShortName FROM [Subject]
	WHERE SubjectName Like '%'+@SubjectName+'%' OR SubjectShortName LIKE '%'+@SubjectName+'%' 
	AND IsDeleted<>'True'
END
