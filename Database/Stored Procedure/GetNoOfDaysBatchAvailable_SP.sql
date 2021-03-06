USE [NewTimeTableDB]
GO
/****** Object:  StoredProcedure [dbo].[GetNoOfDaysBatchAvailable_SP]    Script Date: 12/11/2015 16:50:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 07 Nov 2015
-- Description:	Get NO of Days Batch Available	
-- =============================================
ALTER PROCEDURE [dbo].[GetNoOfDaysBatchAvailable_SP] 
			
AS
BEGIN
	Select b.BatchID,b.BatchName, COUNT (BatchAvailableID) AS 'NoOfDaysAvailaible' From BatchAvailable bAvail
	INNER JOIN Batches b
	ON b.BatchID=bAvail.BatchID
	Where bAvail.BatchID=bAvail.BatchID AND bAvail.IsActive ='True' AND bAvail.IsDeleted='False' AND b.IsActive='True'
	GROUP BY b.BatchID,b.BatchName
END
