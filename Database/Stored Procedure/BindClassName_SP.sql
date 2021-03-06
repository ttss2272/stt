/****** Object:  StoredProcedure [dbo].[BindClassName_SP]    Script Date: 12/16/2015 15:34:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 05-11-2015
-- Description:	To Bind ClassName
-- =============================================
ALTER PROCEDURE [dbo].[BindClassName_SP] 
	(
	@BranchID int	
 	)
AS
BEGIN
	SELECT 0 AS ClassID,'Select' AS ClassName
	Union
	SELECT c.ClassID,c.ClassName  from [Class] c
	inner join Branch br
	on br.BranchID = c.BranchID
	where
	br.BranchID like case when @BranchID <> 0 then @BranchID else CONVERT(nvarchar(50),@BranchID)end
	  and c.IsActive=1 AND c.IsDeleted='False'
	  ORDER BY ClassName

END
