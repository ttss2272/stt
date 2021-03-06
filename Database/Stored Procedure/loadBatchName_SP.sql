/****** Object:  StoredProcedure [dbo].[loadBatchName_SP]    Script Date: 12/11/2015 11:52:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Pravin
-- Create date: 05-11-2015
-- Description:	To Bind BatchName using id
-- =============================================
ALTER PROCEDURE [dbo].[loadBatchName_SP] --98
	(
	@ClassID int	
 	)
AS
BEGIN
	SELECT 0 AS BatchID,'Select' AS BatchName
	Union
	SELECT b.BatchID,b.BatchName  from [Batches] b
	inner join Class c
	on c.ClassID = b.ClassID
	where
	
	c.ClassID like case when @ClassID <> 0 then @ClassID else CONVERT(nvarchar(50),@ClassID)end
	  and  b.IsActive=1
	   AND b.IsDeleted='False' AND C.IsActive=1

END
