USE [NewTimeTableDB]
GO
/****** Object:  StoredProcedure [dbo].[BindTimeSlot_SP]    Script Date: 12/08/2015 18:22:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author: Pranajli S Vidhate
-- Create date: 2015/11/17
-- Description:	To Bind TimeSlot
-- =============================================
ALTER PROCEDURE [dbo].[BindTimeSlot_SP] --30,'j','w'
	(
		@BranchLectureDetailID int,
		@BranchName nvarchar(50),
		@DayName nvarchar(50)
		
	)
AS
BEGIN
	SELECT bld.BranchLectureDetailID,br.BranchID,bl.[DayName],br.BranchName,bl.StartTime,bl.EndTime,bld.IsActive,bld.IsDelete,
	bld.LectureStartTime,bld.LectureEndTime, CASE WHEN bld.IsActive='True' AND bld.IsDelete='False' THEN 'Active' 
	WHEN bld.IsActive='False' AND bld.IsDelete='False' THEN 'InActive' End AS [Status] 
	FROM BranchLectureDetail bld
	INNER JOIN  BranchLecture bl
	ON bl.BranchLectureID=bld.BranchLectureID
	INNER JOIN Branch br
	ON br.BranchID=bl.BranchID
	WHERE bld.BranchLectureDetailID LIKE CASE WHEN @BranchLectureDetailID <>0 THEN @BranchLectureDetailID ELSE CONVERT (NVARCHAR(50),bld.BranchLectureDetailID) END
	AND br.BranchName LIKE CASE WHEN @BranchName <>'' THEN @BranchName ELSE CONVERT (NVARCHAR(50),br.BranchName) END
	AND bl.[DayName] LIKE CASE WHEN @DayName <>'' THEN '%'+@DayName +'%' ELSE CONVERT(NVARCHAR(50),bl.[DayName])END
	AND bld.IsDelete<>'True'
	
	ORDER BY bl.[DayName]
	

END
