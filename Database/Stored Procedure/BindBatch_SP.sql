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
-- Author:		Pravin
-- Create date: 05-11-2015
-- Description:	Get Details To bind Drop Down
-- =============================================
CREATE PROCEDURE [dbo].[BindBatch_SP]
(
	@BatchID int
) 
	
AS
BEGIN
SELECT BatchID,BatchName,BatchCode  from [Batches]
	WHERE BatchID LIKE CASE WHEN @BatchID<>0 THEN @BatchID ELSE CONVERT (NVARCHAR(50),BatchID) END
END

