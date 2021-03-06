USE [NewTimeTableDB]
GO
/****** Object:  StoredProcedure [dbo].[SaveLog_SP]    Script Date: 11/17/2015 15:48:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 11 Nov 2015
-- Description:	Save Log Table Detials
-- =============================================
ALTER PROCEDURE [dbo].[SaveLog_SP] 
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
    VALUES (@LogDescription,CONVERT(datetime,@Timing),@TableName,@TableRowID)
END
