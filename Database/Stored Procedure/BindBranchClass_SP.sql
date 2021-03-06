/****** Object:  StoredProcedure [dbo].[BindBranchClass_SP]    Script Date: 12/16/2015 15:32:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		PriTesh D. Sortee
-- Create date: 19 nov 2015
-- Description:	Bind Class name on brach
-- =============================================
ALTER PROCEDURE [dbo].[BindBranchClass_SP] ---1
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
	ORDER BY ClassName
END
