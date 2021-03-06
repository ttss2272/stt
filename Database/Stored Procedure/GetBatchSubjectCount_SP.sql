/****** Object:  StoredProcedure [dbo].[GetBatchSubjectCount_SP]    Script Date: 12/16/2015 16:30:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 20 Nov 2015
-- Description:	Get Batch Subject Count
-- =============================================
ALTER PROCEDURE [dbo].[GetBatchSubjectCount_SP] 
 
   --@BatchID int,
   --@SubjectID int
 
AS
BEGIN

	SELECT br.BranchID,br.BranchName,bt.BatchID,bt.BatchName, COUNT(bs.BatchSubjectID) AS 'NoOfSubject'
	FROM BatchSubject bs
	
	INNER JOIN [Batches] bt
	ON bt.BatchID=bs.BatchID
	
	INNER JOIN [Subject] sub
	ON sub.SubjectID=bs.SubjectID
	
	INNER JOIN [Class] cl
	ON cl.ClassID=bt.ClassID
	
	INNER JOIN [Branch] br
	ON br.BranchID= cl.BranchID
	
	WHERE br.IsActive=1 AND bt.IsActive='True' AND sub.IsActive='True' AND cl.IsActive='True' AND bs.IsDeleted<>'True' AND BS.IsActive='True'
	--AND bs.BatchID LIKE CASE WHEN @BatchID<>0 THEN @BatchID ELSE CONVERT (NVARCHAR(50),@BatchID)END
	--AND bs.SubjectID LIKE CASE WHEN @SubjectID<>0 THEN @SubjectID ELSE CONVERT(NVARCHAR(50),@SubjectID) END
	
	GROUP BY br.BranchID,br.BranchName,bt.BatchID,bt.BatchName,BS.IsActive
	
END
