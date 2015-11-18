
/****** Object:  StoredProcedure [dbo].[GetTeacherAvailableDetail_SP]    Script Date: 11/17/2015 18:33:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 07 Nov 2015
-- Description:	Get Teacher Available Details
-- =============================================
ALTER PROCEDURE [dbo].[GetTeacherAvailableDetail_SP] 
	(
	@TeacherID int 
	)
AS
BEGIN
	SELECT TeacherAvailableID,TeacherID,[DAY],StartTime,EndTime FROM TeacherAvailable
	WHERE TeacherID LIKE CASE WHEN @TeacherID<>0 THEN @TeacherID ELSE CONVERT (NVARCHAR(50),TeacherID) END
END
