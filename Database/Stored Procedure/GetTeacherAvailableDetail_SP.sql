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
-- Description:	Get Teacher Available Details
-- =============================================
CREATE PROCEDURE GetTeacherAvailableDetail_SP 
	
	@TeacherID int 
	
AS
BEGIN
	SELECT TeacherAvailableID,TeacherID,[DAY],StartTime,EndTime FROM TeacherAvailable
	WHERE TeacherID LIKE CASE WHEN @TeacherID<>0 THEN TeacherID ELSE CONVERT (NVARCHAR(50),TeacherID) END
END
GO
