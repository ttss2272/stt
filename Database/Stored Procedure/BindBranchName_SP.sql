
/****** Object:  StoredProcedure [dbo].[BindBranchName_SP]    Script Date: 12/11/2015 09:50:07 ******/
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
   
	Select 0 AS BranchID ,'Select' AS BranchName
	Union
	SELECT BranchID,BranchName  from [Branch]
	WHERE IsDeleted<>'True' AND IsActive=1
	
    
END
