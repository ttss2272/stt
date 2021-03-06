/****** Object:  StoredProcedure [dbo].[BindBranchBatch_SP]    Script Date: 12/16/2015 15:31:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 20 Nov 2015
-- Description:	Bind Batches on Branch ID
-- =============================================
ALTER PROCEDURE [dbo].[BindBranchBatch_SP] 
(
	@BranchID int 
)
AS
BEGIN
	SELECT 0 AS BatchID,'Select' AS BatchName
	UNION
	SELECT ba.BatchID,ba.BatchName FROM [Batches] ba
	INNER JOIN Class cl
	ON cl.ClassID=ba.ClassID
	WHERE cl.BranchID LIKE CASE WHEN @BranchID <>0 THEN @BranchID ELSE CONVERT(NVARCHAR(50),cl.BranchID) END
	AND ba.IsActive='True' AND ba.IsDeleted='False' AND cl.IsActive='True' 
	ORDER BY BatchName
END
