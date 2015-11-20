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
-- Create date: 19 nov 2015
-- Description:	Bind Class name on brach
-- =============================================
Alter PROCEDURE BindBranchClass_SP ---1
	(
	@BranchID int = 0
	)
	
AS
BEGIN
SELECT 0 AS ClassID,'Select' AS ClassName
UNION
	SELECT ClassID,ClassName FROM [Class]
	WHERE BranchID LIKE CASE WHEN @BranchID<>0 THEN @BranchID ELSE CONVERT (NVARCHAR(50),BranchID)END
	AND IsActive='True' AND IsDeleted='False'
END
GO
