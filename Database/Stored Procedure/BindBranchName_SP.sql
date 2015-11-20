
/****** Object:  StoredProcedure [dbo].[BindBranchName_SP]    Script Date: 11/19/2015 15:47:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:Pranjali
-- Create date: 05/11/2015
-- Description:	To Bind BranchName
-- =============================================
ALTER PROCEDURE [dbo].[BindBranchName_SP]
	
AS
BEGIN
   
	Select 0 AS BranchID ,'Select' AS Branchname
	Union
	SELECT BranchID,BranchName  from [Branch]
	WHERE IsDeleted<>'True' AND IsActive=1
	
    
END
