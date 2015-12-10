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
-- Create date: 10 DEC 2015
-- Description:	Bind Grid For Board
-- =============================================
CREATE PROCEDURE BindBoard_SP 
	(
	@BoardID int,
	@BoardName nvarchar(MAX)
	)
AS
BEGIN
	SELECT BoardID,BoardName,IsActive,IsDeleted, CASE WHEN IsActive='True' AND IsDeleted='False' THEN 'Active'
	WHEN IsActive='False' AND IsDeleted='False' THEN 'InActive' END FROM Board 
	WHERE IsDeleted<>'False'
	AND BoardID Like CASE WHEN @BoardID<> 0 THEN @BoardID ELSE CONVERT(NVARCHAR(50),BoardID) END
	AND BoardName LIKE CASE WHEN @BoardName<>'' THEN '%'+@BoardName+'%' ELSE '%' END
END
GO
