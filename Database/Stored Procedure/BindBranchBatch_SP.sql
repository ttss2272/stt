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
-- Create date: 20 Nov 2015
-- Description:	Bind Batches on Branch ID
-- =============================================
ALTER PROCEDURE BindBranchBatch_SP 
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
	AND ba.IsActive='True' AND ba.IsDeleted='False' 
END
GO
