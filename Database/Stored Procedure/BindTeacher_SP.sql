
/****** Object:  StoredProcedure [dbo].[BindTeacher_SP]    Script Date: 11/18/2015 17:48:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 07 Nov 2015
-- Description:	
-- =============================================
ALTER PROCEDURE [dbo].[BindTeacher_SP] 
	
	@TeacherID int = 0
	
AS
BEGIN
--Select 0 AS'TeacherID','Select'AS TeacherName,'' AS TeacherSurname,'' AS TeacherShortName,'' AS FreeTimeStart,'' AS FreeTimeEnd,'' AS NoOfMovesInBranch,'' AS MaxNoLecturesDay,'' AS MaxNoLectureWeek,'' AS IsAllowMoreThanOneLectInBatch,'' AS MaxNoOfLectureInRow,
	 --'' AS IsFirstLect,'' AS  IsLastLect, '' AS IsActive 
--Union 
	SELECT TeacherID,TeacherName,TeacherSurname,TeacherShortName,FreeTimeStart,FreeTimeEnd,NoOfMovesInBranch,MaxNoLecturesDay,MaxNoLectureWeek,IsAllowMoreThanOneLectInBatch,MaxNoOfLectureInRow,
	 IsFirstLect,IsLastLect,IsActive FROM Teacher where IsActive='True'
END
