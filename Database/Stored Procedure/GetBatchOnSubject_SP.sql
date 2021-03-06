USE [NewTimeTableDB]
GO
/****** Object:  StoredProcedure [dbo].[GetBatchOnSubject_SP]    Script Date: 12/02/2015 12:03:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 21 Nov 2015
-- Description:	Get Batch list on Subject ID
-- =============================================
ALTER PROCEDURE [dbo].[GetBatchOnSubject_SP] --18,11,8
	(
	@TeacherID int,
	@BranchID int,
	@SubjectID int
	)
AS
BEGIN
	IF NOT EXISTS (SELECT TeacherSubjectID FROM TeacherSubject WHERE TeacherID=@TeacherID)
		BEGIN
			SELECT btsub.BatchSubjectID,bt.BatchName,br.BranchName,0 As mybool,cl.ClassName FROM  BatchSubject btsub
	
			INNER JOIN [Batches] bt
			ON bt.BatchID=btsub.BatchID
			INNER JOIN Class cl
			ON cl.ClassID=bt.ClassID
			INNER JOIN Branch br
			ON br.BranchID=cl.BranchID
	
			WHERE  btsub.IsActive='True'
			AND  br.BranchID LIKE CASE WHEN @BranchID <>0 THEN @BranchID ELSE CONVERT (NVARCHAR(50),br.BranchID) END
			AND btsub.SubjectID LIKE CASE WHEN @SubjectID <>0 THEN @SubjectID ELSE CONVERT (NVARCHAR(50),btsub.SubjectID) END
		END
	ELSE
		BEGIN
			SELECT btsub.BatchSubjectID,bt.BatchName,br.BranchName,teasub.IsActive As mybool,cl.ClassName FROM  TeacherSubject teasub
			
			INNER JOIN BatchSubject btsub
			ON btsub.BatchSubjectID=teasub.BatchSubjectID
			INNER JOIN [Batches] bt
			ON bt.BatchID=btsub.BatchID
			INNER JOIN Class cl
			ON cl.ClassID=bt.ClassID
			INNER JOIN Branch br
			ON br.BranchID=cl.BranchID
			Where teasub.TeacherID LIKE CASE WHEN @TeacherID <>0 Then @TeacherID ELSE CONVERT (NVARCHAR(50),teasub.TeacherID) END
			AND btsub.SubjectID LIKE CASE WHEN @SubjectID<> 0 THEN @SubjectID ELSE CONVERT(NVARCHAR(50),btsub.SubjectID) END
			AND  br.BranchID LIKE CASE WHEN @BranchID <>0 THEN @BranchID ELSE CONVERT (NVARCHAR(50),br.BranchID) END
			union
			SELECT btsub.BatchSubjectID,bt.BatchName,br.BranchName ,'False' As mybool,cl.ClassName FROM  BatchSubject btsub
	
			INNER JOIN [Batches] bt
			ON bt.BatchID=btsub.BatchID
			INNER JOIN Class cl
			ON cl.ClassID=bt.ClassID
			INNER JOIN Branch br
			ON br.BranchID=cl.BranchID
	
			WHERE  btsub.IsActive='True'
			AND  br.BranchID LIKE CASE WHEN @BranchID <>0 THEN @BranchID ELSE CONVERT (NVARCHAR(50),br.BranchID) END
			AND btsub.SubjectID LIKE CASE WHEN @SubjectID <>0 THEN @SubjectID ELSE CONVERT (NVARCHAR(50),btsub.SubjectID) END
			AND btsub.BatchSubjectID NOT IN (SELECT BatchSubjectID FROM TeacherSubject Where TeacherID=@TeacherID)
		END
	
END
