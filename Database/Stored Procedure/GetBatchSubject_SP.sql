/****** Object:  StoredProcedure [dbo].[GetBatchSubject_SP]    Script Date: 12/16/2015 16:36:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 20 Nov 2015
-- Description:	Get Subject List
-- =============================================
ALTER PROCEDURE [dbo].[GetBatchSubject_SP] 
(
	@BatchID int  ,
	@SubjectID int
)
AS
BEGIN
	SELECT bs.BatchSubjectID, sub.SubjectID,sub.SubjectName,bs.FrequencyPerDay,bs.FrequencyPerWeek,
	CASE bs.IsActive WHEN'True' THEN 'Active' ELSE 'InActive'END  AS 'Status' ,
	bs.IsActive
	  FROM [Subject] sub
	INNER JOIN BatchSubject bs
	On bs.SubjectID=sub.SubjectID
	INNER JOIN [Batches] bt
	ON bt.BatchID=bs.BatchID
	
	WHERE  bs.IsDeleted='False' AND bt.IsActive=1 AND sub.IsActive=1
	AND bs.BatchID LIKE CASE WHEN @BatchID <>0 THEN @BatchID ELSE CONVERT(NVARCHAR(50),bs.BatchID) END
	AND bs.SubjectID LIKE CASE WHEN @SubjectID <>0 THEN @SubjectID ELSE CONVERT(NVARCHAR(50),bs.SubjectID) END
END
