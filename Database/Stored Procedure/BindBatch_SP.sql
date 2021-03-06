USE [NewTimeTableDB]
GO
/****** Object:  StoredProcedure [dbo].[BindBatch_SP]    Script Date: 11/07/2015 11:20:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 05-11-2015
-- Description:	Get Details To bind Grid view of Batch fORM
-- =============================================
ALTER PROCEDURE [dbo].[BindBatch_SP]
(
	@BatchID int,
	@BatchName nvarchar(50)
) 
	
AS
BEGIN
SELECT c.ClassName,BatchID,BatchName,BatchCode,LectureDuration,IsLunchBreak,MaxNoLecturesDay,MaxNoLecturesWeek,
IsAllowMoreThanOneLectInBatch,MaxNoOfLecureInRow  from [Batches] b
inner join Class c
on c.ClassID=b.ClassID
	WHERE b.BatchID LIKE CASE WHEN @BatchID<>0 THEN @BatchID ELSE CONVERT (NVARCHAR(50),BatchID) END
	AND b.BatchName LIKE CASE WHEN @BatchName<>'' THEN '%'+@BatchName+'%' ELSE CONVERT (NVARCHAR(50),b.BatchName)END
	AND b.IsDeleted<>'True' AND b.IsActive=1
	ORDER BY BatchName 
END
