/****** Object:  StoredProcedure [dbo].[BindTeacherDropDown_SP]    Script Date: 12/09/2015 17:00:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 30-11-2015
-- Description:	bind teacher dropdown on timetable form depend on subject
-- =============================================
ALTER PROCEDURE [dbo].[BindTeacherDropDown_SP] --5,5
	(
	@SubjectID int,
	@BatchID int
 	)
AS
BEGIN
SELECT 0 AS TeacherSubjectID,'Select' AS TeacherName 
UNION
select ts.TeacherSubjectID, t.TeacherName+' '+t.TeacherSurname+'['+t.TeacherShortName+']' AS TeacherName from TeacherSubject ts
inner join Teacher t
on t.TeacherID = ts.TeacherID
inner join BatchSubject bs
on bs.BatchSubjectID = ts.BatchSubjectID



where bs.SubjectID like case when @SubjectID<>0 then @SubjectID else CONVERT(nvarchar(50),bs.SubjectID) end
AND bs.BatchID LIKE CASE WHEN @BatchID<>0 THEN @BatchID ELSE CONVERT(NVARCHAR(50),bs.BatchID) END
AND ts.IsDeleted<>'True' AND ts.IsActive='True'
END


