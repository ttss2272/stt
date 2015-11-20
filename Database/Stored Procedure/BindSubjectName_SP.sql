/****** Object:  StoredProcedure [dbo].[BindSubjectName_SP]    Script Date: 11/20/2015 12:19:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 09-11-2015
-- Description:	Bind Subject Name
-- =============================================
ALTER PROCEDURE [dbo].[BindSubjectName_SP]
	
AS
BEGIN
	SELECT 0 AS SubjectID,'Select' AS SubjectName
	UNION
	SELECT SubjectID,SubjectName  from [Subject]
	WHERE IsDeleted<>'True' AND IsActive='True'
	Order By 'SubjectName'
	
    
END