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
-- Author:		PriTesh D.Sortee
-- Create date: 02 Dec 2015
-- Description:	Get Subject list which is teach at batch on brancch id
-- =============================================
ALTER PROCEDURE GetBranchSubject_SP 
	-- Add the parameters for the stored procedure here
	@BranchID int
AS
BEGIN
	SELECT 0 AS 'SubjectID','Select' AS 'SubjectName'
	UNION
	SELECT DISTINCT sub.SubjectID,sub.SubjectName FROM BatchSubject btsub
	INNER JOIN [Batches] bt
	ON bt.BatchID=btsub.BatchID
	INNER JOIN Class cl
	ON  cl.ClassID=bt.ClassID
	INNER JOIN Branch br
	ON br.BranchID=cl.BranchID
	INNER JOIN [Subject]  sub
	ON sub.SubjectID=btsub.SubjectID
	WHERE br.BranchID LIKE CASE WHEN @BranchID<>0 THEN @BranchID ELSE CONVERT(NVARCHAR(50),br.BranchID) END
	
END
GO
