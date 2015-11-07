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
-- Description:	
-- =============================================
CREATE PROCEDURE BindTeacher_SP 
	
	@TeacherID int = 0
	
AS
BEGIN
Select 0 AS'TeacherID','Select'AS TeacherName
Union
	SELECT TeacherID,TeacherName  FROM Teacher where IsActive='True'
END
GO
