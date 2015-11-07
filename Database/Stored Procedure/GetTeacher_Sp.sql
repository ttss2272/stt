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
-- Description:	Get Details of Teacher
-- =============================================
ALTER PROCEDURE GetTeacher_Sp --2
(
	@TeacherID int
)
AS
BEGIN
	SELECT TeacherID,TeacherName,TeacherSurname,TeacherShortName,NoOfMovesInBranch,MaxNoLecturesDay,MaxNoLectureWeek,MaxNoOfLectureInRow,
	CASE IsFirstLect WHEN 'True' THEN 'Yes' ELSE 'No' END AS IsFirstLect,
	CASE ISLastLect  WHEN 'True' THEN 'Yes' ELSE 'No' END As IsLastLect,
	FreeTimeStart,FreeTimeEnd,Convert(NVARCHAR(7),FreeTimeStart)+' To '+ CONVERT(NVARCHAR(7),FreeTimeEnd) AS 'FreeTime',
	--CASE IsActive  WHEN 'True' Then 1  ELSE 0 END AS IsActive,IsAllowMoreThanOneLectInBatch
	IsActive, 
	CASE IsAllowMoreThanOneLectInBatch WHEN 'True' THEN 'Yes' ELSE 'No' END AS IsAllowMoreThanOneLectInBatch,
    
	 FROM Teacher
	 WHERE IsDeleted='False' AND
	 TeacherID LIKE CASE WHEN @TeacherID<>0 THEN @TeacherID ELSE CONVERT(NVARCHAR(50),TeacherID) END
END
GO
