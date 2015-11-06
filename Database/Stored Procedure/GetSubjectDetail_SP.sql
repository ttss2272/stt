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
-- Author:		PriTesh D.Sortee
-- Create date: 5 Nov 2015
-- Description:	get all details of subject
-- =============================================
CREATE PROCEDURE GetSubjectDetail_SP 
(
	@SubjectName NVARCHAR(50),
	@ShortName NVARCHAR(50)	
	
)
AS
BEGIN
SELECT SubjectID,SubjectName,SubjectShortName,IsActive,IsDeleted FROM [Subject]
WHERE SubjectName = @SubjectName AND SubjectShortName=@ShortName
END
GO
