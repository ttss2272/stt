
-- =============================================
-- Author:		Sameer Shinde
-- Create date: 10 Dec 2015
-- Description:	Get Max Batch ID
-- =============================================
ALTER PROCEDURE GetMaxBatchID_SP
	
AS
BEGIN
   
	SELECT MAX(BatchID) from [Batches]	
END
GO
