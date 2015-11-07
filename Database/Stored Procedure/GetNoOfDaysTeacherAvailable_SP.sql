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
-- Description:	Get NO of Days Teacher Available
-- =============================================
CREATE PROCEDURE GetNoOfDaysTeacherAvailable_SP 
	
	
	
AS
BEGIN
	Select Tea.TeacherID,tea.TeacherName, COUNT (TeacherAvailableID) AS 'NoOfDaysAvailaible' From TeacherAvailable TeaAvail
	INNER JOIN Teacher tea
	ON Tea.TeacherID=TeaAvail.TeacherID
	Where TeaAvail.TeacherID=TeaAvail.TeacherID
	GROUP BY Tea.TeacherID,tea.TeacherName
END
GO
