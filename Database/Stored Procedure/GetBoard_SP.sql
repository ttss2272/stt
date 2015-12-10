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
-- Create date: 10 Dec 2015
-- Description:	Get Board Name to Bind Dorpdown
-- =============================================
CREATE PROCEDURE GetBoard_SP 
	
AS
BEGIN
	SELECT 0 AS BoardID,'SELECT' AS BoardName
	UNION
	SELECT BoardID,BoardName FROM Board
	WHERE IsActive='True' AND IsDeleted<>'True'
END
GO
