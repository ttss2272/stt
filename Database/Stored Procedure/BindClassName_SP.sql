/****** Object:  StoredProcedure [dbo].[BindClassName_SP]    Script Date: 11/19/2015 16:51:18 ******/
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
	
AS
BEGIN
	SELECT 0 AS ClassID,'Select' AS ClassName
	Union
	SELECT ClassID,ClassName  from [Class] where IsActive=1 AND IsDeleted<>'True'

END
