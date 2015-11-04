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
-- Create date: 04 Nov 2015
-- Description:	Get Details To bind Drop Down
-- =============================================
CREATE PROCEDURE BindSubject_SP 
	(
		@SubjectID int
	)
AS
BEGIN
	SELECT SubjectID,SubjectName,SubjectShortName  from [Subject]
	WHERE SubjectID LIKE CASE WHEN @SubjectID<>0 THEN @SubjectID ELSE CONVERT (NVARCHAR(50),SubjectID) END
END
GO
