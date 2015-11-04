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
-- Create date: 11 Nov 2015
-- Description:	Save Log Table Detials
-- =============================================
CREATE PROCEDURE SaveLog_SP 
	(
	@LogDescription nvarchar(50),
	@Timing nvarchar(50),
	@TableName nvarchar(50),
	@TableRowID nvarchar(50)
	)
AS
BEGIN
INSERT INTO [Log]
    (LogDescription,Timing,TableName,TableRowID)
    VALUES (@LogDescription,@Timing,@TableName,@TableRowID)
END
GO
